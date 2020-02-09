using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Kpi.Hotels.Dataclient.Context;
using Kpi.Hotels.Dataclient.Context.Models;

namespace kpi_hotels_api.Controllers
{
    [Route("gui/[controller]")]
    public class RoomsController : Controller
    {
        private readonly HotelsContext _context;

        public RoomsController(HotelsContext context)
        {
            _context = context;
        }

        // GET: Rooms
        [Route("/")]
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var hotelsContext = _context.Rooms.Include(r => r.ServiceClass);
            return View(await hotelsContext.ToListAsync());
        }

        // GET: Rooms/Details/5
        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.ServiceClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        [Route("Create")]
        public IActionResult Create()
        {
            ViewData["ServiceClassId"] = new SelectList(_context.ServiceClasses, "Id", "Id");
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ServiceClassId,Floor,RoomNumber,FridgeIncluded")] Room room)
        {
            if (ModelState.IsValid)
            {
                room.Id = Guid.NewGuid();
                _context.Add(room);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceClassId"] = new SelectList(_context.ServiceClasses, "Id", "Id", room.ServiceClassId);
            return View(room);
        }

        // GET: Rooms/Edit/5
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            ViewData["ServiceClassId"] = new SelectList(_context.ServiceClasses, "Id", "Id", room.ServiceClassId);
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ServiceClassId,Floor,RoomNumber,FridgeIncluded")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(room);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RoomExists(room.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ServiceClassId"] = new SelectList(_context.ServiceClasses, "Id", "Id", room.ServiceClassId);
            return View(room);
        }

        // GET: Rooms/Delete/5
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var room = await _context.Rooms
                .Include(r => r.ServiceClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var room = await _context.Rooms.FindAsync(id);
            _context.Rooms.Remove(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(Guid id)
        {
            return _context.Rooms.Any(e => e.Id == id);
        }
    }
}
