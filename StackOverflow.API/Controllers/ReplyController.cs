﻿using Core.Models;
using Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;
using Services.Users;

namespace StackOverflow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;
        private readonly CurrentUserServices _current;
 
        public ReplyController(IReplyService replyService, CurrentUserServices current)
        {
            _replyService = replyService;
            _current = current;
        }

        // Obtine un reply după ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReplyById([FromRoute] int id)
        {
            var reply = await _replyService.GetReplyByIdAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            return Ok(reply);
        }


        // Creeaza un reply
        [HttpPost("{id}")]
        public async Task<IActionResult> CreateReply([FromRoute] int id, [FromBody] string description)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //var newReply = await _replyService.CreateReplyAsync(request);
             await _current.CreateReply(id, description);
             return Ok();
        }

        // Obtine toate reply-urile pentru un anumit topic
        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetRepliesForTopic([FromRoute] int topicId)
        {
            var replies = await _replyService.GetRepliesForToticAsync(topicId);
          //  if (replies == null || replies.Count == 0)
          //  {
          //      return NotFound(new { message = $"No replies found for topic with ID {topicId}." });
          //  }
            return Ok(replies);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetRepliesByUserId([FromRoute] int userId)
        {
            var replies = await _replyService.GetRepliesByUserIdAsync(userId);
            if (replies == null || replies.Count == 0)
            {
                return NotFound(new { message = $"No replies found for user with ID {userId}." });
            }
            return Ok(replies);
        }


        // Editeaza un reply existent / adauga end-point
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReply([FromRoute] int id, [FromBody] string newDescription)
        {
            var newReply = await _replyService.UpdateReplyAsync(id, newDescription);
            if (newReply == null)
            {
                return NotFound();
            }
            return Ok(newReply);
        }

        //sterge un reply
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReply([FromRoute] int id)
        {
            try
            {
                await _replyService.DeleteReplyAsync(id);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(new { message = ex.Message });
            }
        }

        [HttpPost("rating")]
        public async Task<IActionResult> SubmitRating([FromQuery]int replyId, [FromBody] int rating)
        {
            try
            {
                await _replyService.SubmitRatingAsync(replyId, rating);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
