using Application.Dto;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {

        // poniżej został wstrzyknięty obiekt PostService i przypisany do prywatnej klasy  zmiennej kontrolera
        private readonly IPostService _postService;
        public PostsController(IPostService postService)
        {
            _postService = postService;
            
        }
       

        /// <summary>
        /// zwraca listę wszystkich postów - json
        /// </summary>
        /// <returns></returns>


        [SwaggerOperation(Summary = "Retrives all posts")]
        [HttpGet]
        public IActionResult Get() 
        {

            var posts = _postService.GetAllPosts();
           

            return Ok(posts);
        }
        [SwaggerOperation(Summary = "Retrives a specific post by uniquw id")]
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
        [SwaggerOperation(Summary = "Create a new post")]
        [HttpPost]

        public IActionResult Create (CreatePostDto newPost)
        {
            var post = _postService.AddNewPost(newPost);
            return Created($"api/posts/{post.Id}", post);
        }

        // jeśli zostanie wysłane żądanie HTTP typu Post pod adres api/posts/{post.Id}  to wywoła się metoda Create z klasy PostController 
        // zwracany kod 201

        [SwaggerOperation(Summary ="Update a existing post")]
        [HttpPut]
        public IActionResult Update (UpdatePostDto updatePost)
        {
            _postService.UpdatePost(updatePost);
            return NoContent();
            //kod odpowiedzi 204
        }

        [SwaggerOperation(Summary = "Delete a specific post")]
        [HttpDelete("{id}")]
        public IActionResult Delete (int id)
        {
            _postService.DeletePost(id);
            return NoContent();
            // zwracamy kod 204 no conntent
        }

    }
}
