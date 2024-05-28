using cron.Api.Models;
using cron.Application.Repositories.Blog;
using cron.Domain.Entities;
using cron.Persistance.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
           
            return Ok();
        }
    }
}
