namespace ChatGPT.ApiService;

public interface IApiConfiguration
{
    string ApiUrl { get; }
    string ApiKey { get; }
}
