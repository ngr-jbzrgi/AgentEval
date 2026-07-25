using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Client;


// Every class that implements ILlmClient must have a method called CompleteAsync that takes a ChatRequest and eventually returns a ChatResponse."

// Returning a Task or Task<T> in C# means your method is returning a promise or a receipt for work that will finish in the future. Instead of making the program freeze and wait for a slow operation to finish, the method gives the caller a tracking object (the Task) immediately


//This interface exists to decouple the core of the application from specific AI providers (such as OpenAI) and to implement the Dependency Inversion Principle (DIP).
// In the AgentEval architecture, this interface serves as the bridge between the AgentLoop and the outside world. The agent communicates with language models exclusively through this interface, rather than interacting with any provider-specific implementation directly.
// This design allows us to replace one client with another—such as switching from an OpenAI client to a Google Gemini client or a mock testing client—without making any changes to the agent's core logic. As a result, the system becomes more modular, maintainable, and easier to test and extend.


public interface ILlmClient
{
    Task<ChatResponse> CompleteAsync(ChatRequest request); // returns a Task containing a ChatResponse
}

