using cron.Api.Models;
using cron.Domain.Entities;
using cron.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace cron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        readonly CronAppDbContext _context;
        public BlogController(CronAppDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = new Blog
                {                   
                    Content = model.Content,
                    ImageUrl = model.ImageUrl,
                };
                                
                _context.Blogs.Add(blog);
                await _context.SaveChangesAsync();

                return Ok(blog);
            }

            return BadRequest(ModelState);
        }
    }
}
