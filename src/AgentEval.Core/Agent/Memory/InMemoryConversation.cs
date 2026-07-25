using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Agent.Memory;

public class InMemoryConversation : IConversationMemory
{
    private List<ChatMessage> _messages = new List<ChatMessage>();

    public void ClearMemory()
    {
        _messages.Clear();
    }

    public void AddMessage(string role, string content)
    {
        _messages.Add(new ChatMessage(role, content));
    }

    public List<ChatMessage> ReadMessages()
    {
        return new List<ChatMessage>(_messages);
    }
}
