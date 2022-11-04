using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSafetyExam2;
using WebSafetyExam2.Entities;

namespace WebSafetyExam2.Controllers
{
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
            return await _context.Blog.Select(blog => blog.EncodeEntity().DecodeAllowedTags()).ToListAsync();
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
            _context.Blog.Add(blogEntity.EncodeEntity());
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
