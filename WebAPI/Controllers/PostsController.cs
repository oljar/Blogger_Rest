using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
        }
        

        /// <summary>
        /// zwraca listę wszystkich postów - json
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get() 
        {

            var posts = _postService.GetAllPosts();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var post = _postService.GetPostById(id);
            if (post == null)   //jeśli post nie istnieje dla id
            {
                return NotFound(); // kod 404
            }
            return Ok(post);
        }




    }
}
