using Core.DbModels;
using Core.Models;
using DataBase.Abstraction;
using Services.Abstractions;

namespace Services.Topic
{

    public class TopicService : ITopicService
    {
        private readonly ITopicRepository _topicRepository;

        public TopicService(ITopicRepository topicRepository)
        {
            _topicRepository = topicRepository;
        }

        public async Task<TopicDbTables> GetTopicByIdAsync(int id)
        {
            return await _topicRepository.GetByIdAsync(id);
        }

        public async Task<List<TopicDbTables>> GetAllTopicsAsync()
        {
            return await _topicRepository.GetAllAsync();
        }

        public async Task<TopicDbTables> CreateTopicAsync(CreateTopicRequest request)
        {
            var topicDbTable = new TopicDbTables
            {
                Title = request.Title,
                Description = request.Description,
                Datecreate = DateTime.UtcNow,
                Tags = request.Tags,
                UserId = request.UserId
            };

            await _topicRepository.AddAsync(topicDbTable);

            return topicDbTable;
        }
    }
}
