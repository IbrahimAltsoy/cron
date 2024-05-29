using cron.Api.Models;
using cron.Application.Repositories.Blog;
using cron.Domain.Entities;
using cron.Persistance.Context;
using Microsoft.AspNetCore.Mvc;

namespace cron.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ControllerBase
    {
        readonly CronAppDbContext _context;
        readonly IBlogReadRepository _blogReadRepository;
        readonly IBlogWriteRepository _blogWriteRepository;

        public BlogController(CronAppDbContext context, IBlogReadRepository blogReadRepository, IBlogWriteRepository blogWriteRepository)
        {
            _context = context;
            _blogReadRepository = blogReadRepository;
            _blogWriteRepository = blogWriteRepository;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] BlogViewModel model)
        {
            if (ModelState.IsValid)
            {
                var blog = new Blog()
                {
                    Content = model.Content,
                    ImageUrl = model.ImageUrl,
                    CreatedDate = DateTime.Now,
                };
                await _blogWriteRepository.AddAsync(blog);
                await _blogWriteRepository.SaveChangesAsync();
                return Ok(blog);
            }
            return BadRequest(ModelState);           
        }
        [HttpGet]
        public async Task<IActionResult> Get(int page = 1, int pageSize = 6)
        {
            var query = await _blogReadRepository.GetAllAsync(true);
            var totalBlogCount = query.Count();

            var blogs = query
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .Select(b => new BlogViewModel
                {
                    Content = b.Content,
                    ImageUrl = b.ImageUrl,
                    CreatedDate = b.CreatedDate,
                })
                .ToList();

            var result = new
            {
                TotalBlogCount = totalBlogCount,
                Blogs = blogs
            };

            return Ok(result);
        }
    }
}
