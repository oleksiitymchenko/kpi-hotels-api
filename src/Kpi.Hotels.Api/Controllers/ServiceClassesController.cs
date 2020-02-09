using System;
using System.Collections.Generic;
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
    public class ServiceClassesController : Controller
    {
        private readonly HotelsContext _context;

        public ServiceClassesController(HotelsContext context)
        {
            _context = context;
        }

        // GET: ServiceClasses
        [Route("/")]
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.ServiceClasses.ToListAsync());
        }

        // GET: ServiceClasses/Details/5
        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceClass = await _context.ServiceClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceClass == null)
            {
                return NotFound();
            }

            return View(serviceClass);
        }

        // GET: ServiceClasses/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ServiceClasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RoomKind,RoomPrice")] ServiceClass serviceClass)
        {
            if (ModelState.IsValid)
            {
                serviceClass.Id = Guid.NewGuid();
                _context.Add(serviceClass);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(serviceClass);
        }

        // GET: ServiceClasses/Edit/5
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceClass = await _context.ServiceClasses.FindAsync(id);
            if (serviceClass == null)
            {
                return NotFound();
            }
            return View(serviceClass);
        }

        // POST: ServiceClasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [Route("Edit")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,RoomKind,RoomPrice")] ServiceClass serviceClass)
        {
            if (id != serviceClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(serviceClass);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceClassExists(serviceClass.Id))
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
            return View(serviceClass);
        }

        // GET: ServiceClasses/Delete/5
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var serviceClass = await _context.ServiceClasses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (serviceClass == null)
            {
                return NotFound();
            }

            return View(serviceClass);
        }

        // POST: ServiceClasses/Delete/5
        [Route("Delete")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var serviceClass = await _context.ServiceClasses.FindAsync(id);
            _context.ServiceClasses.Remove(serviceClass);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ServiceClassExists(Guid id)
        {
            return _context.ServiceClasses.Any(e => e.Id == id);
        }
    }
}
