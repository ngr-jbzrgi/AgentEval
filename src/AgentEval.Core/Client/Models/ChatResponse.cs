namespace AgentEval.Core.Client.Models;


// The ChatResponse class is a Data Transfer Object (DTO) that encapsulates the output returned by a language model, including the generated text, token usage statistics, and any tool call requests.
// The purpose of this class is to provide a unified and standardized representation of model responses, allowing the application to avoid parsing the different and often complex JSON response formats used by various providers (such as OpenAI or Google).
// In the AgentEval architecture, this class is the return type of the CompleteAsync method defined in the ILlmClient interface. The AgentLoop receives a ChatResponse object and uses the information it contains to determine the next step—either displaying the generated message to the user or executing a requested tool call.

public class ChatResponse(string content, int promptTokens, int completionTokens)
{
    public string Content { get; set; } = content;
    public int PromptTokens { get; set; } = promptTokens;
    public int CompletionTokens { get; set; } = completionTokens;
    
    public int TotalTokens => PromptTokens + CompletionTokens;
}