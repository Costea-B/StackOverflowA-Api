using Core.DbModels;
using DataBase.Abstraction;
using Services.Abstractions;
using Core.Models.Requests;

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

        public async Task<bool> DeleteTopicAsync(int id)
        {
             bool status = await _topicRepository.DeleteAsync(id);
             return status;
          }

        public async Task<List<TopicDbTables>> GetTopicsByUserIdAsync(int userId)
        {
             return await _topicRepository.GetTopicsByUserIdAsync(userId);
          }

        public async Task<IEnumerable<TopicDbTables>> SearchTopicsAsync(string searchTerm)
        {
             return await _topicRepository.SearchTopicsAsync(searchTerm);
          }
    }

    
}
