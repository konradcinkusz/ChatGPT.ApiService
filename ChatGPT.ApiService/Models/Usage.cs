namespace ChatGPT.ApiService.Models;

public class Usage
{
    public int promptTokens { get; set; }
    public int completionTokens { get; set; }
    public int totalTokens { get; set; }
}
