using AgentEval.Core.Client.Models;

namespace AgentEval.Core.Agent.Memory;

public interface IConversationMemory
{
   void ClearMemory();
   void AddMessage(string role, string content);

   List<ChatMessage>  ReadMessages();
}