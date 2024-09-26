using Core.Models.Requests;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> GetTopicById([FromRoute]int id)
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
            return Ok(new {id = createdTopic});
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopicById([FromRoute] int id)
        {

             bool succes = await _topicService.DeleteTopicAsync(id);
             if (succes)
             {
                  return Ok();
             }
             return BadRequest(ModelState);
        }

        [HttpGet("user/{userId}")]
        public async Task<IActionResult> GetTopicsByUserId([FromRoute] int userId)
        {
            var topics = await _topicService.GetTopicsByUserIdAsync(userId);
            if (topics == null || !topics.Any())
            {
                return NotFound($"No topics found for user with ID {userId}.");
            }
            return Ok(topics);
        }

        [HttpGet("SearchTopics")]
        public async Task<IActionResult> SearchTopics(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term cannot be empty");
            }

            var topics = await _topicService.SearchTopicsAsync(searchTerm);
            if (topics == null || !topics.Any())
            {
                return NotFound("No topics found");
            }

            return Ok(topics);
        }
    }
}
