namespace ChatGPT.ApiService.Models;

public class ChatCompletion
{
    public string id { get; set; }
    public string Object { get; set; }
    public long Created { get; set; }
    public string Model { get; set; }
    public List<Choice> Choices { get; set; }
    public Usage Usage { get; set; }
    public object SystemFingerprint { get; set; }
}
