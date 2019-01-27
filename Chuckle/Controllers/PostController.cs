using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Chuckle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
// https://stackoverflow.com/questions/49374448/asp-net-core-webapi-routing

namespace Chuckle.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly PostContext _context;

        public PostController(PostContext context)
        {
            _context = context;

            if(_context.Posts.Count() == 0)
            {
                _context.Posts.Add(new Post { Text = "Text1" });
                _context.SaveChanges();
            }
        }

        // GET: api/Post
        [HttpGet("[action]")]
        public async Task<ActionResult<IEnumerable<Post>>> GetPosts()
        {
            return await _context.Posts.ToListAsync();
        }

        // GET: api/Post/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetPost(long id)
        {
            var post = await _context.Posts.FindAsync(id);
            if(post == null)
            {
                return NotFound();
            }

            return post;
        }

        // POST: api/Post
        [HttpPost]
        public async Task<ActionResult<string>> Create(Post post)
        {
            
            _context.Posts.Add(post);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }


    }
}
