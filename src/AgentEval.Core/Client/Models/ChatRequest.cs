namespace AgentEval.Core.Client.Models;

public class ChatRequest
{

    //without this, the model will default to gpt-4o
    // in C# when we define classes or lists, they dont have any memory allocated for them until we instantiate them. So, if we don't initialize the Messages property, it will be null by default. This means that if we try to add messages to it or access it without initializing it first, we'll get a NullReferenceException. By initializing it with new(), we ensure that it's ready to hold ChatMessage objects as soon as a ChatRequest instance is created.
    public List<ChatMessage> Messages { get; set; } = new();
    public string Model { get; set; } = "gpt-4o";
}