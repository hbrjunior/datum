using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleBlog.Domain.Entidades;
using SimpleBlog.Domain.Interfaces;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleBlog.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // Garante que os endpoints exijam autenticação
    public class PostsController : ControllerBase
    {
        private readonly IPostRepository _postRepository;
        private readonly IUserService _userService;

        public PostsController(IPostRepository postRepository, IUserService userService)
        {
            _postRepository = postRepository;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Post>>> GetAll()
        {
            var posts = await _postRepository.GetAllAsync();
            return Ok(posts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Post>> GetById(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound($"Post with ID {id} not found.");

            return Ok(post);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] Post post)
        {
            if (post == null)
                return BadRequest("Invalid post data.");

            // Aqui podemos pegar o ID do usuário autenticado
            var userId = _userService.GetUserIdFromClaim(User);
            post.Author = userId; // Assumindo que 'Author' seja o ID do usuário (não o nome)

            await _postRepository.AddAsync(post);
            return CreatedAtAction(nameof(GetById), new { id = post.Id }, post);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] Post updatedPost)
        {
            var existingPost = await _postRepository.GetByIdAsync(id);
            if (existingPost == null)
                return NotFound($"Post with ID {id} not found.");

            // Verificando se o usuário autenticado é o autor da postagem
            var userId = _userService.GetUserIdFromClaim(User);
            if (existingPost.Author != userId)
                return Unauthorized("You are not authorized to edit this post.");

            existingPost.Title = updatedPost.Title;
            existingPost.Content = updatedPost.Content;

            await _postRepository.UpdateAsync(existingPost); // Atualiza no repositório
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var post = await _postRepository.GetByIdAsync(id);
            if (post == null)
                return NotFound($"Post with ID {id} not found.");

            // Verificando se o usuário autenticado é o autor da postagem
            var userId = _userService.GetUserIdFromClaim(User);
            if (post.Author != userId)
                return Unauthorized("You are not authorized to delete this post.");

            await _postRepository.DeleteAsync(post); // Remove do repositório
            return NoContent();
        }
    }
}
