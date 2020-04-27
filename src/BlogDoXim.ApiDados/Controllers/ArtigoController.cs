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
    public class ArtigoController : ControllerBase
    {
        private readonly BlogDoXimContext _context;

        public ArtigoController(BlogDoXimContext context)
        {
            _context = context;
        }

        // GET: api/Artigo
        [HttpGet]
        [AllowAnonymous]
        public async Task<ActionResult<IEnumerable<Artigo>>> GetArtigos()
        {
            return await _context.Artigos.ToListAsync();
        }

        // GET: api/Artigo/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<ActionResult<Artigo>> GetArtigo(int id)
        {
            var artigo = await _context.Artigos.FindAsync(id);

            if (artigo == null)
            {
                return NotFound();
            }

            return artigo;
        }

        // PUT: api/Artigo/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtigo(int id, Artigo artigo)
        {
            if (id != artigo.ArtigoId)
            {
                return BadRequest();
            }

            _context.Entry(artigo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtigoExists(id))
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

        // POST: api/Artigo
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<Artigo>> PostArtigo(Artigo artigo)
        {
            _context.Artigos.Add(artigo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetArtigo", new { id = artigo.ArtigoId }, artigo);
        }

        // DELETE: api/Artigo/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Artigo>> DeleteArtigo(int id)
        {
            var artigo = await _context.Artigos.FindAsync(id);
            if (artigo == null)
            {
                return NotFound();
            }

            _context.Artigos.Remove(artigo);
            await _context.SaveChangesAsync();

            return artigo;
        }

        private bool ArtigoExists(int id)
        {
            return _context.Artigos.Any(e => e.ArtigoId == id);
        }
    }
}
