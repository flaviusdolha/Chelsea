using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Chelsea.Model.Domain.Ticket;
using Chelsea.Model.Service;
using Microsoft.AspNetCore.Mvc;

namespace Chelsea.Controllers
{
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentService _commentService;

        public CommentsController(CommentService commentService)
        {
            _commentService = commentService;
        }

        [HttpGet]
        [Route("api/[controller]")]
        public ActionResult GetAllComments(int ticketId)
        {
            List<Comment> list;
            if (ticketId != 0) list = _commentService.GetAllComments(ticketId);
            else list = _commentService.GetAllComments();
            if (list.Count == 0) return NotFound();
            return Ok(list);
        }

        [HttpGet]
        [Route("api/[controller]/{id}")]
        public ActionResult GetOneComment(int id)
        {
            var comment = _commentService.GetCommentWithId(id);
            if (comment is null) return NotFound();
            return Ok(comment);
        }

        [HttpPost]
        [Route("api/[controller]")]
        public async Task<ActionResult> AddComment()
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                try
                {
                    _commentService.AddComment(json);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
        
        [HttpPut]
        [Route("api/[controller]/{id}")]
        public async Task<ActionResult> UpdateComment(int id)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = await reader.ReadToEndAsync();
                var json = JsonSerializer.Deserialize<Dictionary<string, dynamic>>(body);
                var ticket = _commentService.GetCommentWithId(id);
                if (ticket is null) return NotFound();
                try
                {
                    ticket.Content = json["content"].ToString();
                    _commentService.ModifyComment(ticket);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest(e);
                }
            }
        }
        
        [HttpDelete]
        [Route("api/[controller]/{id}")]
        public ActionResult RemoveComment(int id)
        {
            var comment = _commentService.GetCommentWithId(id);
            if (comment is null) return NotFound();
            _commentService.RemoveComment(id);
            return Ok();
        }
    }
}