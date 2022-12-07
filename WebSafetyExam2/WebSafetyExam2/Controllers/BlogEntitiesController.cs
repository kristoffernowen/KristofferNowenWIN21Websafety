
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSafetyExam2.Entities;

namespace WebSafetyExam2.Controllers
{
    [EnableCors("react")]
    [Route("api/[controller]")]
    [ApiController]
    public class BlogEntitiesController : ControllerBase
    {
        private readonly SqlContext _context;

        public BlogEntitiesController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/BlogEntities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BlogEntity>>> GetBlog()
        {
            var returnThis = await _context.Blog.Select(blog => blog.EncodeEntity().DecodeAllowedTags()).ToListAsync();
            //var returnThis = await _context.Blog.ToListAsync();

            return returnThis;
        }

        // GET: api/BlogEntities/5
        [HttpGet("{id}")]
        public async Task<ActionResult<BlogEntity>> GetBlogEntity(int id)
        {
            var blogEntity = await _context.Blog.FindAsync(id);

            if (blogEntity == null)
            {
                return NotFound();
            }

            return blogEntity;
        }

        // PUT: api/BlogEntities/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBlogEntity(int id, BlogEntity blogEntity)
        {
            if (id != blogEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(blogEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogEntityExists(id))
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

        // POST: api/BlogEntities
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<BlogEntity>> PostBlogEntity(BlogEntity blogEntity)
        {
            _context.Blog.Add(blogEntity.EncodeEntity());   // removed encode to get pass & becoming amp; Reinserted encode and then added encodedAllowedTags in BlogEntityExtension
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBlogEntity", new { id = blogEntity.Id }, blogEntity);
        }

        // DELETE: api/BlogEntities/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBlogEntity(int id)
        {
            var blogEntity = await _context.Blog.FindAsync(id);
            if (blogEntity == null)
            {
                return NotFound();
            }

            _context.Blog.Remove(blogEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BlogEntityExists(int id)
        {
            return _context.Blog.Any(e => e.Id == id);
        }
    }
}
