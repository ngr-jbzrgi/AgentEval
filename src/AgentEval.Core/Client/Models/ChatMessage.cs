namespace AgentEval.Core.Client.Models;



// Primary constructor syntax in C# allows you to define a class with a concise syntax that automatically generates properties and a constructor based on the parameters provided. In this case, the `ChatMessage` class has two properties: `Role` and `Content`, which are initialized through the primary constructor.

//Role : user , assistent , system


public class ChatMessage(string role, string content)
{
    public string Role { get; set; } = role;
    public string Content { get; set; } = content;
}