namespace ChatGPT.ApiService.Models;

public class ConversationGPT
{
    public string model { get; set; } = "gpt-4";
    public List<MessageGPT> messages { get; set; }
}
