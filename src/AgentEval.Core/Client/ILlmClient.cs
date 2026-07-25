using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Client;


// Every class that implements ILlmClient must have a method called CompleteAsync that takes a ChatRequest and eventually returns a ChatResponse."

// Returning a Task or Task<T> in C# means your method is returning a promise or a receipt for work that will finish in the future. Instead of making the program freeze and wait for a slow operation to finish, the method gives the caller a tracking object (the Task) immediately

public interface ILlmClient
{
    Task<ChatResponse> CompleteAsync(ChatRequest request); // returns a Task containing a ChatResponse
}

