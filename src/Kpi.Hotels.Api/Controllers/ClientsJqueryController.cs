using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kpi.Hotels.Dataclient.Context;

namespace kpi_hotels_api.Controllers
{
    [Route("gui/[controller]")]
    public class ClientsJqueryController : Controller
    {
        private readonly HotelsContext _context;

        public ClientsJqueryController(HotelsContext context)
        {
            _context = context;
        }

        // GET: ClientsJquery
        [Route("/")]
        [Route("Index")]
        [Route("")]
        public async Task<IActionResult> Index()
        {
            return View(await _context.Clients.ToListAsync());
        }

        // GET: ClientsJquery/Details/5
        [Route("Details")]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        // GET: ClientsJquery/Create
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        // GET: ClientsJquery/Edit/5
        [Route("Edit")]
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }
            return View(client);
        }

        // GET: ClientsJquery/Delete/5
        [Route("Delete")]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var client = await _context.Clients
                .FirstOrDefaultAsync(m => m.Id == id);
            if (client == null)
            {
                return NotFound();
            }

            return View(client);
        }

        private bool ClientExists(Guid id)
        {
            return _context.Clients.Any(e => e.Id == id);
        }
    }
}
