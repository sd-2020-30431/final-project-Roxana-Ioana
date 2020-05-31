using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Model;

namespace WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubcommandsController : ControllerBase
    {
        private readonly ProductContext _context;

        public SubcommandsController(ProductContext context)
        {
            _context = context;
        }

        // GET: api/Subcommands
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Subcommand>>> GetSubcommands()
        {
            return await _context.Subcommands.ToListAsync();
        }

        // GET: api/Subcommands/Command/5
        [HttpGet("Command/{idCommand}")]
        public async Task<ActionResult<IEnumerable<Subcommand>>> GetSubcommandsForCommand(int idCommand)
        {
            return await _context.Subcommands.Where(s => s.Command.Id_command == idCommand).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subcommand>> GetSubcommand(int id)
        {
            var subcommand = await _context.Subcommands.FindAsync(id);

            if (subcommand == null)
            {
                return NotFound();
            }

            return subcommand;
        }

        // PUT: api/Subcommands/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSubcommand(int id, Subcommand subcommand)
        {
            if (id != subcommand.Id_subcommand)
            {
                return BadRequest();
            }

            _context.Entry(subcommand).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SubcommandExists(id))
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

        // POST: api/Subcommands
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Subcommand>> PostSubcommand(Subcommand subcommand)
        {
            _context.Subcommands.Add(subcommand);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSubcommand", new { id = subcommand.Id_subcommand }, subcommand);
        }

        // DELETE: api/Subcommands/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Subcommand>> DeleteSubcommand(int id)
        {
            var subcommand = await _context.Subcommands.FindAsync(id);
            if (subcommand == null)
            {
                return NotFound();
            }

            _context.Subcommands.Remove(subcommand);
            await _context.SaveChangesAsync();

            return subcommand;
        }

        private bool SubcommandExists(int id)
        {
            return _context.Subcommands.Any(e => e.Id_subcommand == id);
        }
    }
}
