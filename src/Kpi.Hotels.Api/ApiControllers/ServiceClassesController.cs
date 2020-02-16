using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Kpi.Hotels.Dataclient.Context;
using Kpi.Hotels.Dataclient.Context.Models;
using Microsoft.AspNetCore.Cors;

namespace kpi_hotels_api.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsPolicy")]
    public class ServiceClassesController : ControllerBase
    {
        private readonly HotelsContext _context;

        public ServiceClassesController(HotelsContext context)
        {
            _context = context;
        }

        // GET: api/ServiceClasses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceClass>>> GetServiceClasses()
        {
            return await _context.ServiceClasses.ToListAsync();
        }

        // GET: api/ServiceClasses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceClass>> GetServiceClass(Guid id)
        {
            var serviceClass = await _context.ServiceClasses.FindAsync(id);

            if (serviceClass == null)
            {
                return NotFound();
            }

            return serviceClass;
        }

        // PUT: api/ServiceClasses/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutServiceClass(Guid id, ServiceClass serviceClass)
        {
            if (id != serviceClass.Id)
            {
                return BadRequest();
            }

            _context.Entry(serviceClass).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiceClassExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ServiceClasses
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        [HttpPost]
        public async Task<ActionResult<ServiceClass>> PostServiceClass(ServiceClass serviceClass)
        {
            _context.ServiceClasses.Add(serviceClass);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetServiceClass", new { id = serviceClass.Id }, serviceClass);
        }

        // DELETE: api/ServiceClasses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ServiceClass>> DeleteServiceClass(Guid id)
        {
            var serviceClass = await _context.ServiceClasses.FindAsync(id);
            if (serviceClass == null)
            {
                return NotFound();
            }

            _context.ServiceClasses.Remove(serviceClass);
            await _context.SaveChangesAsync();

            return serviceClass;
        }

        private bool ServiceClassExists(Guid id)
        {
            return _context.ServiceClasses.Any(e => e.Id == id);
        }
    }
}
