namespace ChatAIBackend.Models
{
    public class Message
    {
        public int Id { get; set; }
        public string userName { get; set; }
        public string content { get; set; }
        public string? sentiment { get; set; }
        public double? sentimentScore { get; set; }
        public DateTime createdAt { get; set; } = DateTime.UtcNow;
    }
}
