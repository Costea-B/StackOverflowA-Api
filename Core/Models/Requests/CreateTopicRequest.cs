namespace Core.Models.Requests
{
    public class CreateTopicRequest
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public IList<string> Tags { get; set; } = new List<string>();
        public int UserId { get; set; }
    }
}
