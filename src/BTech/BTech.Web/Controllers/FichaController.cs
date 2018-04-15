using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BTech.DataAccess.Context;
using BTech.DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BTech.Web.Controllers
{
    [Produces("application/json")]
    [Route("api/Ficha")]
	[Authorize("Bearer")]
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
			return _context.Fichas
				.Include(f => f.Professor)
				.Include(f => f.Cliente)
				.Include(f => f.Series);
        }

        // GET: api/Ficha/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetFicha([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ficha = await _context.Fichas
				.Include(f => f.Professor)
				.Include(f => f.Cliente)
				.Include(f => f.Series)
				.SingleOrDefaultAsync(m => m.Id == id);

            if (ficha == null)
            {
                return NotFound();
            }

			ficha.Series = ficha.Series.OrderBy(s => s.TipoSerie).ToList();

			return Ok(ficha);
        }

		// GET: api/FichaCliente/5
		[HttpGet(), Route("GetFichaCliente/{id}")]
		public async Task<IActionResult> GetFichaCliente([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var ficha = await _context.Fichas
				.Include(f => f.Professor)
				.Include(f => f.Cliente)
				.Include(f => f.Series)
				.SingleOrDefaultAsync(m => m.Cliente.Id == id);

			if (ficha == null)
			{
				return NotFound();
			}

			ficha.Series = ficha.Series.OrderBy(s => s.TipoSerie).ToList();
			
			return Ok(ficha);
		}

		// GET: api/FichaCliente/5
		[HttpGet(), Route("GetFichasProfessor/{id}")]
		public async Task<IActionResult> GetFichasProfessor([FromRoute] int id)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var ficha = _context.Fichas
				.Include(f => f.Professor)
				.Include(f => f.Cliente)
				.Include(f => f.Series)
				.Where(m => m.Professor.Id == id);

			if (ficha == null)
			{
				return NotFound();
			}

			foreach(Ficha f in ficha)
			{
				f.Series = f.Series.OrderBy(s => s.TipoSerie).ToList();
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

			if (ficha.Cliente.ContratoAtivo.HasValue && !ficha.Cliente.ContratoAtivo.Value)
			{
				return BadRequest(new Exception("Contrato do cliente encontra-se inativo"));
			}

			if (ficha.Series.Count == 0)
			{
				return BadRequest(new Exception("Ficha deve conter pelo menos uma série"));
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