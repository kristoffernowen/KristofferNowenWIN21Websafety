
using System.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebSafeExam1.Entities;



namespace WebSafeExam1.Controllers
{
    public class BlogEntitiesController : Controller
    {
        private readonly SqlContext _context;

        public BlogEntitiesController(SqlContext context)
        {
            _context = context;
        }

        // GET: BlogEntities
        public async Task<IActionResult> Index()
        {
              return View(await _context.Blog.Select(blog => blog.EncodeEntity()).ToListAsync());
        }

        // GET: BlogEntities/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogEntity = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogEntity == null)
            {
                return NotFound();
            }

            return View(blogEntity);
        }

        // GET: BlogEntities/Create
        [Authorize(Roles = "Employed")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: BlogEntities/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Message,UserId")] BlogEntity blogEntity)
        {


            //  Inputen ska också saneras i uppgiften
            //Däremot finns det best practice råd att endast sanera output


            if (User.Identity.IsAuthenticated)
            {
                if (ModelState.IsValid)
                {

                    // blogEntity.Title = HttpUtility.HtmlEncode(blogEntity.Title);


                    _context.Add(blogEntity);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }


            return Unauthorized();
        }

        // GET: BlogEntities/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogEntity = await _context.Blog.FindAsync(id);
            if (blogEntity == null)
            {
                return NotFound();
            }
            return View(blogEntity);
        }

        // POST: BlogEntities/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Message,UserId")] BlogEntity blogEntity)
        {
            if (id != blogEntity.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(blogEntity);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BlogEntityExists(blogEntity.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(blogEntity);
        }

        // GET: BlogEntities/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Blog == null)
            {
                return NotFound();
            }

            var blogEntity = await _context.Blog
                .FirstOrDefaultAsync(m => m.Id == id);
            if (blogEntity == null)
            {
                return NotFound();
            }

            return View(blogEntity);
        }

        // POST: BlogEntities/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Blog == null)
            {
                return Problem("Entity set 'SqlContext.Blog'  is null.");
            }
            var blogEntity = await _context.Blog.FindAsync(id);
            if (blogEntity != null)
            {
                _context.Blog.Remove(blogEntity);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BlogEntityExists(int id)
        {
          return _context.Blog.Any(e => e.Id == id);
        }
    }
}
