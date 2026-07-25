namespace AgentEval.Core.Client.Models;



// The ChatRequest class is a DTO (Data Transfer Object) pattern that encapsulates all the information required to send a request to a language model—such as the complete conversation history and model settings—into a single, standardized object.

// The purpose of this class is to provide an abstraction layer, ensuring that our system is not tightly coupled to the specific JSON request format of any particular provider (such as OpenAI). It also keeps request handling consistent and unified throughout the application.

// In the AgentEval architecture, this class contains a collection of ChatMessage objects. It is populated inside the AgentLoop before each request is sent, and then passed as the input parameter to the CompleteAsync method defined in the ILlmClient interface.

public class ChatRequest
{

    //without this, the model will default to gpt-4o
    // in C# when we define classes or lists, they dont have any memory allocated for them until we instantiate them. So, if we don't initialize the Messages property, it will be null by default. This means that if we try to add messages to it or access it without initializing it first, we'll get a NullReferenceException. By initializing it with new(), we ensure that it's ready to hold ChatMessage objects as soon as a ChatRequest instance is created.
    
    public List<ChatMessage> Messages { get; set; } = new();
    public string Model { get; set; } = "gpt-4o";
}