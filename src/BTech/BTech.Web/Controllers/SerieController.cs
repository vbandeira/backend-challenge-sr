using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTech.DataAccess.Context;
using BTech.DataAccess.Entities;

namespace BTech.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Serie")]
    public class SerieController : Controller
    {
        private readonly BTContext _context;

        public SerieController(BTContext context)
        {
            _context = context;
        }

        // GET: api/Serie
        [HttpGet]
        public IEnumerable<Serie> GetSeries()
        {
            return _context.Series.Include(s => s.Conclusoes);
        }

        // GET: api/Serie/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetSerie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serie = await _context.Series.Include(s => s.Conclusoes).SingleOrDefaultAsync(m => m.Id == id);

            if (serie == null)
            {
                return NotFound();
            }

            return Ok(serie);
        }

        // PUT: api/Serie/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSerie([FromRoute] int id, [FromBody] Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != serie.Id)
            {
                return BadRequest();
            }

            _context.Entry(serie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SerieExists(id))
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

        // POST: api/Serie
        [HttpPost]
        public async Task<IActionResult> PostSerie([FromBody] Serie serie)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Series.Add(serie);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSerie", new { id = serie.Id }, serie);
        }

        // DELETE: api/Serie/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSerie([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var serie = await _context.Series.SingleOrDefaultAsync(m => m.Id == id);
            if (serie == null)
            {
                return NotFound();
            }

            _context.Series.Remove(serie);
            await _context.SaveChangesAsync();

            return Ok(serie);
        }

        private bool SerieExists(int id)
        {
            return _context.Series.Any(e => e.Id == id);
        }
    }
}