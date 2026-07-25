using AgentEval.Core.Client;
using AgentEval.Core.Client.Models;
using AgentEval.Core.Agent.Memory;

namespace AgentEval.Core.Agent;



// The AgentLoop class is the core orchestrator and a concrete implementation of the IAgent interface. It is responsible for executing the agent's main reasoning cycle, commonly known as the Observe–Think–Act loop.
// The purpose of this class is to coordinate the entire interaction between the user, the language model, and the application's memory. It maintains the conversation history, packages it into a ChatRequest, sends it to the language model through the ILlmClient interface, receives a ChatResponse, and determines the next action based on the model's response.
// In the AgentEval architecture, AgentLoop serves as the central coordinator. It communicates with external language models exclusively through the ILlmClient interface, making it independent of any specific provider such as OpenAI. It also implements the IAgent interface, allowing it to be resolved through Dependency Injection in Program.cs, where all of its required dependencies are injected automatically.


public class AgentLoop(ILlmClient client, IConversationMemory memory) : IAgent 
{
    public async Task<string> RunAsync(string userText)
    {
        // قدم اول: اضافه کردن پیام کاربر به حافظه
        memory.AddMessage("user", userText);

        // قدم دوم: خواندن تاریخچه از حافظه و ساخت درخواست
        var request = new ChatRequest
        {
            Messages = memory.ReadMessages(),
            Model = "gpt-4o"
        };

        // قدم سوم: ارسال درخواست به مدل زبان
        var response = await client.CompleteAsync(request);

        // قدم چهارم: ذخیره پاسخ ایجنت در حافظه
        memory.AddMessage("assistant", response.Content);

        return response.Content;
    }
}