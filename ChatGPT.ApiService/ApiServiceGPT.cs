namespace ChatGPT.ApiService;

/// <summary>
/// curl https://api.openai.com/v1/chat/completions   
/// -H "Content-Type: application/json"   
/// -H "Authorization: Bearer $OPENAI_API_KEY"   
/// -d '{
///     "model": "gpt-3.5-turbo",
///     "messages": [
///       {
///         "role": "system",
///         "content": "You are a poetic assistant, skilled in explaining complex programming concepts with creative flair."
///       },
///       {
///     "role": "user",
///         "content": "Compose a poem that explains the concept of recursion in programming."
///       }
///     ]
///   }'
/// </summary>
/// <typeparam name="T"></typeparam>
public class ApiServiceGPT
{
    readonly string apiUrl, apiKey, serviceName;

    public ApiServiceGPT(IApiConfiguration config, string serviceName)
    {
        apiUrl = config.ApiUrl;
        apiKey = $"Bearer {config.ApiKey}";
        this.serviceName = serviceName;
    }

    public async virtual Task<ChatCompletion> MakeApiRequest(ConversationGPT requestData)
    {
        ChatCompletion result = null;

        using (HttpClient httpClient = new HttpClient())
        {
            try
            {
                // Set the API endpoint URL
                httpClient.BaseAddress = new Uri(apiUrl);

                // Add the headers
                httpClient.DefaultRequestHeaders.Add("Authorization", apiKey);

                //var requestData = new ConversationGPT { messages = new List<MessageGPT> { new() {role ="user", content = "Compose a poem that explains the concept of recursion in programming." } }, model = "gpt-4" };

                // Serialize the request data to JSON
                var jsonContent = JsonConvert.SerializeObject(requestData);

                // Create a StringContent object with the request data
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                content.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                // Make a POST request
                HttpResponseMessage response = await httpClient.PostAsync(apiUrl, content);

                if (response.IsSuccessStatusCode)
                {
                    // Read the response content as a string
                    string responseData = await response.Content.ReadAsStringAsync();

                    responseData = responseData.Replace("```json", "").Replace("```", "").Trim();

                    result = JsonConvert.DeserializeObject<ChatCompletion>(responseData);

                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"{serviceName}: HttpRequestException: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{serviceName}: general exception: {ex.Message}");
            }
        }
        return result;
    }
}
