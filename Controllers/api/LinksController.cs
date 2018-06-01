﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AngularApp.Models;
using AngularApp.Persistence;

namespace AngularApp.Controllers.api
{
    [Produces("application/json")]
    [Route("api/Links")]
    public class LinksController : Controller
    {
        private readonly AppDbContext _context;

        public LinksController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Links
        [HttpGet]
        public IEnumerable<Links> GetLinks()
        {
            return _context.Links;
        }

        // GET: api/Links/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetLinks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var links = await _context.Links.SingleOrDefaultAsync(m => m.Id == id);

            if (links == null)
            {
                return NotFound();
            }

            return Ok(links);
        }

        // PUT: api/Links/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLinks([FromRoute] int id, [FromBody] Links links)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != links.Id)
            {
                return BadRequest();
            }

            _context.Entry(links).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LinksExists(id))
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

        // POST: api/Links
        [HttpPost]
        public async Task<IActionResult> PostLinks([FromBody] Links links)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Links.Add(links);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLinks", new { id = links.Id }, links);
        }

        // DELETE: api/Links/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLinks([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var links = await _context.Links.SingleOrDefaultAsync(m => m.Id == id);
            if (links == null)
            {
                return NotFound();
            }

            _context.Links.Remove(links);
            await _context.SaveChangesAsync();

            return Ok(links);
        }

        private bool LinksExists(int id)
        {
            return _context.Links.Any(e => e.Id == id);
        }
    }
}