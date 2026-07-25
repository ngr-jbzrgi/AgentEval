using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;
using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Client;

//This class: Given a chat request, send it to OpenAI, receive the response, and convert it back into our own objects



// A class can only inherit from ONE base class, but it can implement INFINITE interfaces.
// If we made ILlmClient a regular class, our OpenAiClient would be trapped. It couldn't inherit from anything else (like a generic HttpService class). Interfaces keep our architecture incredibly lightweight and flexible.


// Naming Convention _ : its a private field - but here we used primary constructor

public class OpenAiClient(HttpClient httpClient, string apiKey) : ILlmClient
{
    public async Task<ChatResponse> CompleteAsync(ChatRequest request)
    {
        // تبدیل مدل‌های داخلی خودمان به ساختار مورد انتظار سرور OpenAI
        var openAiRequest = new
        {
            model = request.Model,
            messages = request.Messages.Select(m => new { role = m.Role, content = m.Content })
        };

        httpClient.DefaultRequestHeaders.Clear();
        httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

        var response = await httpClient.PostAsJsonAsync("https://api.openai.com/v1/chat/completions", openAiRequest);
        response.EnsureSuccessStatusCode();

        var responseData = await response.Content.ReadFromJsonAsync<OpenAiResponseDto>();

        var content = responseData?.Choices.FirstOrDefault()?.Message.Content ?? string.Empty;
        var promptTokens = responseData?.Usage?.PromptTokens ?? 0;
        var completionTokens = responseData?.Usage?.CompletionTokens ?? 0;

        return new ChatResponse(content, promptTokens, completionTokens);
    }

    // کلاس‌های کمکی (DTO) فقط برای خواندن JSON اختصاصی OpenAI
    //DTO: Data Transfer Object
    //  a simple object used to transfer data between different layers of an application
    // The API's JSON is messy. It uses specific names like prompt_tokens and nested structures (like choices[0].message.content). If we put all those ugly JSON attributes directly onto our clean ChatResponse class, we'd be tightly coupling our core model to OpenAI's exact format. DTOs take the "messy JSON hit" as a temporary container so our core classes can stay beautiful and clean!
    private class OpenAiResponseDto
    {
        [JsonPropertyName("choices")] public List<ChoiceDto> Choices { get; set; } = [];
        [JsonPropertyName("usage")] public UsageDto? Usage { get; set; }
    }

    private class ChoiceDto
    {
        [JsonPropertyName("message")] public MessageDto Message { get; set; } = new();
    }

    private class MessageDto
    {
        [JsonPropertyName("content")] public string Content { get; set; } = string.Empty;
    }

    private class UsageDto
    {
        [JsonPropertyName("prompt_tokens")] public int PromptTokens { get; set; }
        [JsonPropertyName("completion_tokens")] public int CompletionTokens { get; set; }
    }
}

