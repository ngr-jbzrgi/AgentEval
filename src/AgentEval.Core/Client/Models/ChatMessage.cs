namespace AgentEval.Core.Client.Models;



// Primary constructor syntax in C# allows you to define a class with a concise syntax that automatically generates properties and a constructor based on the parameters provided. In this case, the `ChatMessage` class has two properties: `Role` and `Content`, which are initialized through the primary constructor.

//Role : user , assistent , system

// ChatMessage class represents a single message in a chat conversation. It has two properties: Role and Content. The Role property indicates the role of the sender (e.g., "user", "assistant", or "system"), while the Content property contains the actual text of the message.

// The ChatMessage class is essentially a Data Transfer Object (DTO) that encapsulates the smallest unit of information in a conversation: the sender's identity (role) and the message content.
// This class exists because Large Language Model (LLM) APIs are stateless. To understand the flow and context of a conversation, they require a structured and standardized history of messages with defined roles (such as user and assistant), rather than a single block of plain text.
// In the AgentEval system, this class forms the foundation of all communication. It is stored as a list in the AgentLoop's conversation memory, included as the payload inside a ChatRequest when sending requests to the server, and the model's final output is returned to the application in the form of another ChatMessage object contained within a ChatResponse.


public class ChatMessage(string role, string content)
{
    public string Role { get; set; } = role;
    public string Content { get; set; } = content;
}

// یک الگوی DTO (Data Transfer Object)