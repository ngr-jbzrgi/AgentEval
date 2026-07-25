using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Client;

public class MockLlmClient : ILlmClient
{
    public async Task<ChatResponse> CompleteAsync(ChatRequest request)
    {

        // Simulate network delay
        await Task.Delay(1000);

        var lastMessage = request.Messages.LastOrDefault();
        var contentString = lastMessage != null ? lastMessage.Content : "empty";
        var responseText = $"Mock response to: {contentString}";
        
        return Task.FromResult(new ChatResponse(responseText, 10, 10));
    }
}