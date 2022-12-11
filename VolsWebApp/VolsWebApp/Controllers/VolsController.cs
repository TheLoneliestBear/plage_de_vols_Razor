using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VolsWebApp.Data;
using VolsWebApp.Models;

namespace VolsWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VolsController : ControllerBase
    {
        private readonly VolContext _context;

        public VolsController(VolContext context)
        {
            _context = context;
        }

        // GET: api/Vols
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
        {
            return await _context.Vols.ToListAsync();
        }

        // GET: api/Vols/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Vol>> GetProduit(int id)
        {
            var vol = await _context.Vols.FindAsync(id);

            if (vol == null)
            {
                return NotFound();
            }

            return vol;
        }

        // PUT: api/Produits/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduit(int id, Vol vol)
        {
            if (id != vol.Id)
            {
                return BadRequest();
            }

            _context.Entry(vol).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            //return NoContent();
            return CreatedAtAction("GetChat", new { id = vol.Id }, vol);
        }

        // POST: api/Produits
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Vol>> PostVol(Vol vol)
        {
            _context.Vols.Add(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVol", new { id = vol.Id }, vol);
        }

        // DELETE: api/Produits/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVol(int id)
        {
            var vol = await _context.Vols.FindAsync(id);
            if (vol == null)
            {
                return NotFound();
            }

            _context.Vols.Remove(vol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetChat", new { id = vol.Id }, vol);
        }

        private bool VolExists(int id)
        {
            return _context.Vols.Any(e => e.Id == id);
        }
    }
}

//    [Route("api/[controller]")]
//    [ApiController]
//    public class VolsController : ControllerBase
//    {
//        private readonly VolContext _context;

//        public VolsController(VolContext context)
//        {
//            _context = context;
//        }

//        // GET: api/Vols
//        [HttpGet]
//        public async Task<ActionResult<IEnumerable<Vol>>> GetVols()
//        {
//            return await _context.Vols.ToListAsync();
//        }

//        // GET: api/Vols/5
//        [HttpGet("{id}")]
//        public async Task<ActionResult<Vol>> GetVol(int id)
//        {
//            var vol = await _context.Vols.FindAsync(id);

//            if (vol == null)
//            {
//                return NotFound();
//            }

//            return vol;
//        }

//        // PUT: api/Vols/5
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPut("{id}")]
//        public async Task<IActionResult> PutVol(int id, Vol vol)
//        {
//            if (id != vol.Id)
//            {
//                return BadRequest();
//            }

//            _context.Entry(vol).State = EntityState.Modified;

//            try
//            {
//                await _context.SaveChangesAsync();
//            }
//            catch (DbUpdateConcurrencyException)
//            {
//                if (!VolExists(id))
//                {
//                    return NotFound();
//                }
//                else
//                {
//                    throw;
//                }
//            }

//            return NoContent();
//        }

//        // POST: api/Vols
//        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
//        [HttpPost]
//        public async Task<ActionResult<Vol>> PostVol(Vol vol)
//        {
//            _context.Vols.Add(vol);
//            await _context.SaveChangesAsync();

//            return CreatedAtAction("GetVol", new { id = vol.Id }, vol);
//        }

//        // DELETE: api/Vols/5
//        [HttpDelete("{id}")]
//        public async Task<IActionResult> DeleteVol(int id)
//        {
//            var vol = await _context.Vols.FindAsync(id);
//            if (vol == null)
//            {
//                return NotFound();
//            }

//            _context.Vols.Remove(vol);
//            await _context.SaveChangesAsync();

//            return NoContent();
//        }

//        private bool VolExists(int id)
//        {
//            return _context.Vols.Any(e => e.Id == id);
//        }
//    }
//}
