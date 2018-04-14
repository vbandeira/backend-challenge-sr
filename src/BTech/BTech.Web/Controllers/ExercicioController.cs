﻿using System;
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
    [Route("api/Exercicio")]
    public class ExercicioController : Controller
    {
        private readonly BTContext _context;

        public ExercicioController(BTContext context)
        {
            _context = context;
        }

        // GET: api/Exercicio
        [HttpGet]
        public IEnumerable<Exercicio> GetExercicios()
        {
            return _context.Exercicios;
        }

        // GET: api/Exercicio/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetExercicio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercicio = await _context.Exercicios.SingleOrDefaultAsync(m => m.Id == id);

            if (exercicio == null)
            {
                return NotFound();
            }

            return Ok(exercicio);
        }

        // PUT: api/Exercicio/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutExercicio([FromRoute] int id, [FromBody] Exercicio exercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != exercicio.Id)
            {
                return BadRequest();
            }

            _context.Entry(exercicio).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExercicioExists(id))
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

        // POST: api/Exercicio
        [HttpPost]
        public async Task<IActionResult> PostExercicio([FromBody] Exercicio exercicio)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Exercicios.Add(exercicio);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetExercicio", new { id = exercicio.Id }, exercicio);
        }

        // DELETE: api/Exercicio/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExercicio([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exercicio = await _context.Exercicios.SingleOrDefaultAsync(m => m.Id == id);
            if (exercicio == null)
            {
                return NotFound();
            }

            _context.Exercicios.Remove(exercicio);
            await _context.SaveChangesAsync();

            return Ok(exercicio);
        }

        private bool ExercicioExists(int id)
        {
            return _context.Exercicios.Any(e => e.Id == id);
        }
    }
}