namespace ChatGPT.ApiService.Models;

public class Choice
{
    public int index { get; set; }
    public MessageGPT message { get; set; }
    public string finishReason { get; set; }
}
