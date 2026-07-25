namespace AgentEval.Core.Agent;

// The IAgent file is an interface that defines the core contract and required behavior for all agents in the system, such as implementing the RunAsync method.
// The purpose of this interface is to implement the Dependency Inversion Principle (DIP) within our architecture, ensuring that other parts of the application (such as Program.cs) are not tightly coupled to a specific agent implementation.
// In the AgentEval project, the AgentLoop class implements this interface. Then, in Program.cs, we use Dependency Injection (DI) to register AgentLoop as the implementation of IAgent. As a result, whenever any part of the application requests an IAgent, the DI container automatically provides an instance of AgentLoop, while the rest of the application remains dependent only on the interface rather than the concrete class.


public interface IAgent
{
 
    Task<string> RunAsync(string userMessage);
}