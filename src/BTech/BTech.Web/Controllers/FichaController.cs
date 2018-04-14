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
    [Route("api/Ficha")]
    public class FichaController : Controller
    {
        private readonly BTContext _context;

        public FichaController(BTContext context)
        {
            _context = context;
        }

        // GET: api/Ficha
        [HttpGet]
        public IEnumerable<Ficha> GetFichas()
        {
            return _context.Fichas;
        }

        // GET: api/Ficha/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFicha([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ficha = await _context.Fichas.SingleOrDefaultAsync(m => m.Id == id);

            if (ficha == null)
            {
                return NotFound();
            }

            return Ok(ficha);
        }

        // PUT: api/Ficha/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFicha([FromRoute] int id, [FromBody] Ficha ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ficha.Id)
            {
                return BadRequest();
            }

            _context.Entry(ficha).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FichaExists(id))
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

        // POST: api/Ficha
        [HttpPost]
        public async Task<IActionResult> PostFicha([FromBody] Ficha ficha)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Fichas.Add(ficha);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFicha", new { id = ficha.Id }, ficha);
        }

        // DELETE: api/Ficha/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFicha([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ficha = await _context.Fichas.SingleOrDefaultAsync(m => m.Id == id);
            if (ficha == null)
            {
                return NotFound();
            }

            _context.Fichas.Remove(ficha);
            await _context.SaveChangesAsync();

            return Ok(ficha);
        }

        private bool FichaExists(int id)
        {
            return _context.Fichas.Any(e => e.Id == id);
        }
    }
}