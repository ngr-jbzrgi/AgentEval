namespace AgentEval.Core.Client.Models;

public class ChatResponse(string content, int promptTokens, int completionTokens)
{
    public string Content { get; set; } = content;
    public int PromptTokens { get; set; } = promptTokens;
    public int CompletionTokens { get; set; } = completionTokens;
    
    public int TotalTokens => PromptTokens + CompletionTokens;
}