using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BlogDoXim.Data;
using BlogDoXim.Domain;
using Microsoft.AspNetCore.Authorization;

namespace BlogDoXim.ApiDados.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AcessoArtigoController : ControllerBase
    {
        private readonly BlogDoXimContext _context;

        public AcessoArtigoController(BlogDoXimContext context)
        {
            _context = context;
        }

        // GET: api/AcessoArtigo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AcessoArtigo>>> GetAcessosArtigo()
        {
            return await _context.AcessosArtigo.ToListAsync();
        }

        // GET: api/AcessoArtigo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AcessoArtigo>> GetAcessoArtigo(int id)
        {
            var acessoArtigo = await _context.AcessosArtigo.FindAsync(id);

            if (acessoArtigo == null)
            {
                return NotFound();
            }

            return acessoArtigo;
        }

        // PUT: api/AcessoArtigo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAcessoArtigo(int id, AcessoArtigo acessoArtigo)
        {
            if (id != acessoArtigo.AcessoArtigoId)
            {
                return BadRequest();
            }

            _context.Entry(acessoArtigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AcessoArtigoExists(id))
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

        // POST: api/AcessoArtigo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<AcessoArtigo>> PostAcessoArtigo(AcessoArtigo acessoArtigo)
        {
            _context.AcessosArtigo.Add(acessoArtigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAcessoArtigo", new { id = acessoArtigo.AcessoArtigoId }, acessoArtigo);
        }

        // DELETE: api/AcessoArtigo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<AcessoArtigo>> DeleteAcessoArtigo(int id)
        {
            var acessoArtigo = await _context.AcessosArtigo.FindAsync(id);
            if (acessoArtigo == null)
            {
                return NotFound();
            }

            _context.AcessosArtigo.Remove(acessoArtigo);
            await _context.SaveChangesAsync();

            return acessoArtigo;
        }

        private bool AcessoArtigoExists(int id)
        {
            return _context.AcessosArtigo.Any(e => e.AcessoArtigoId == id);
        }
    }
}
