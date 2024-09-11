using Core.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstractions;


namespace StackOverflow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetTopicById(int id)
        {
            var topic = await _topicService.GetTopicByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }
            return Ok(topic);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllTopics()
        {
            var topics = await _topicService.GetAllTopicsAsync();
            return Ok(topics);
        }

        // Adaugă endpoint-ul pentru creare
        [HttpPost]
        public async Task<IActionResult> CreateTopic([FromBody] CreateTopicRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var createdTopic = await _topicService.CreateTopicAsync(request);
            return CreatedAtAction(nameof(GetTopicById), new { id = createdTopic.Id }, createdTopic);
        }
    }
}
