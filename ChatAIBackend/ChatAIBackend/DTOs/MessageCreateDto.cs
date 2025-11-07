namespace ChatAIBackend.DTOs
{
    public class MessageCreateDto
    {
        public string userName { get; set; } = "anonymous";
        public string content { get; set; } = String.Empty;
    }
}
