namespace ChatAIBackend.DTOs
{
    public class MessageReadDto
    {
        public int Id { get; set; }
        public string userName { get; set; } = "anonymous";
        public string content { get; set; } = String.Empty;
        public string? sentiment { get; set; }
        public double? sentimentScore { get; set; }
        public DateTime createdAt { get; set; }
    }
}
