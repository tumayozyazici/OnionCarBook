using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionCarBook.Application.Features.Mediator.Commands.CommentCommands;
using OnionCarBook.Application.Features.RepositoryPattern;
using OnionCarBook.Domain.Entities;

namespace OnionCarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly IGenericRepository<Comment> _commentRepository;
        private readonly IMediator _mediator;

        public CommentsController(IGenericRepository<Comment> commentRepository, IMediator mediator)
        {
            _commentRepository = commentRepository;
            _mediator = mediator;
        }

        [HttpGet("CommentList")]
        public IActionResult CommentList()
        {
            var values = _commentRepository.GetAll();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetComment(int id)
        {
            var values = _commentRepository.GetById(id);
            return Ok(values);
        }

        [HttpPost("CreateComment")]
        public IActionResult CreateComment(Comment comment)
        {
            _commentRepository.Create(comment);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPost("CreateCommentWithMediator")]
        public async Task<IActionResult> CreateCommentWithMediator(CreateCommentCommand createCommentCommand)
        {
            await _mediator.Send(createCommentCommand);
            return Ok("Yorum başarıyla eklendi");
        }

        [HttpPut("UpdateComment")]
        public IActionResult UpdateComment(Comment comment)
        {
            _commentRepository.Update(comment);
            return Ok("Yorum başarıyla güncellendi");
        }

        [HttpDelete("RemoveComment")]
        public IActionResult RemoveComment(int id)
        {
            _commentRepository.Remove(id);
            return Ok("Yorum başarıyla silindi");
        }

        [HttpGet("GetCommentsByBlogID")]
        public IActionResult GetCommentsByBlogID(int id)
        {
            var values = _commentRepository.GetCommentsByBlogId(id);
            return Ok(values);
        }

        [HttpGet("GetCommentCountByBlogID")]
        public IActionResult GetCommentCountByBlogID(int id)
        {
            var values = _commentRepository.GetCommentCountByBlogId(id);
            return Ok(values);
        }
    }
}