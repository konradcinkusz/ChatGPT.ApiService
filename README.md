Here's how you can do it:

### Step 1: Implement the Interface

```csharp
public class ApiConfiguration : IApiConfiguration
{
    public string ApiUrl { get; set; }
    public string ApiKey { get; set; }
}
```

### Step 2: Register the Configuration Class with Dependency Injection

In your `Startup.cs` (for ASP.NET Core) or wherever you configure services:

```csharp
public void ConfigureServices(IServiceCollection services)
{
    // Configure the settings
    services.Configure<ApiConfiguration>(Configuration.GetSection("ApiConfiguration"));

    // Register the interface and implementation
    services.AddSingleton<IApiConfiguration>(sp =>
        sp.GetRequiredService<IOptions<ApiConfiguration>>().Value);

    // Register the ApiServiceGPT
    services.AddTransient<ApiServiceGPT>();

    // Other service registrations...
}
```

### Step 3: Update the Configuration File

Add the API URL and API key to your configuration file (e.g., `appsettings.json`):

```json
{
    "ApiConfiguration": {
        "ApiUrl": "https://api.openai.com/v1/chat/completions",
        "ApiKey": "sk-****************************"
    }
}
```

### Step 4: Create in code
```
ApiServiceGPT apiServiceGPT = new ApiServiceGPT("GPT");
```