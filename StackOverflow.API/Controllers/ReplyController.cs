﻿using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;

namespace StackOverflow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReplyController : ControllerBase
    {
        private readonly IReplyService _replyService;

        public ReplyController(IReplyService replyService)
        {
            _replyService = replyService;
        }

        // Obtine un reply după ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReplyById(int id)
        {
            var reply = await _replyService.GetReplyByIdAsync(id);
            if (reply == null)
            {
                return NotFound();
            }
            return Ok(reply);
        }

        // Obtine toate reply-urile pentru un anumit topic
        [HttpGet("topic/{topicId}")]
        public async Task<IActionResult> GetRepliesForTopic(int topicId)
        {
            var replies = await _replyService.GetRepliesForToticAsync(topicId);
            return Ok(replies);
        }

        // Creeaza un reply
        [HttpPost]
        public async Task<IActionResult> CreateReply([FromBody] CreateReplyRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newReply = await _replyService.CreateReplyAsync(request);
            return CreatedAtAction(nameof(GetReplyById), new { id = newReply.Id }, newReply);
        }

        // Editeaza un reply existent / adauga end-point
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReply(int id, [FromBody] string newDescription)
        {
            var newReply = await _replyService.UpdateReplyAsync(id, newDescription);
            if (newReply == null)
            {
                return NotFound();
            }
            return Ok(newReply);
        }
    }
}