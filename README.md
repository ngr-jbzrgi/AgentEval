
# AgentEval

A C# framework for building AI agents and evaluating their performance rigorously.

Built from scratch as a learning project and portfolio piece — every layer of the architecture is hand-written to demonstrate deep understanding of AI agent systems, LLM evaluation, and modern C# design patterns.

> **Author:** Negar Jamehbozorgi — Final-year CS (AI specialisation), Heriot-Watt University Dubai  
> **Goal:** Production-quality AI agent evaluation framework in C# and .NET 10

---

## What AgentEval does

- Wraps the OpenAI Chat Completions API in a clean, typed C# client
- Runs an AI agent loop with tool calling and conversation memory
- Supports pluggable tools via a tool registry (`ITool` interface)
- Evaluates agent outputs using LLM-as-judge with configurable rubrics
- Scores agent reliability with pass@k metrics
- Runs a full benchmark suite and produces structured reports
- Includes a RAG pipeline using OpenAI embeddings and cosine similarity

---

## Architecture

```
AgentEval/
├── src/
│   └── AgentEval.Core/          # Core library — all agent and eval logic
│       ├── Client/              # LLM client layer (ILlmClient, OpenAiClient)
│       ├── Agent/               # Agent loop, tool registry, conversation memory
│       ├── Evaluation/          # LLM-as-judge engine, rubrics, metrics
│       └── Rag/                 # Embeddings, vector store, RAG pipeline
├── demo/
│   └── AgentEval.Demo/          # Console app — runs the agent end to end
└── tests/
    └── AgentEval.Tests/         # xUnit unit tests
```

---

## Tech stack

| Area | Technology |
|---|---|
| Language | C# 12 |
| Runtime | .NET 10 |
| LLM APIs | OpenAI (GPT-4o, GPT-4.1-mini) |
| Local LLMs | OllamaSharp (llama3.2) |
| Evaluation | LLM-as-judge, G-Eval principles |
| Testing | xUnit |
| IDE | VS Code on macOS |

---

## Build progress

Each week adds one layer to the framework. Committed every week.

---

## How to run

```bash
# Clone
git clone https://github.com/ngr-jbzrgi/AgentEval.git
cd AgentEval

# Build
dotnet build

# Run the demo
dotnet run --project demo/AgentEval.Demo

# Run tests
dotnet test
```

**Requirements:** .NET 10, an OpenAI API key set as environment variable:

```bash
export OPENAI_API_KEY=your_key_here
```

## About

I am a final-year Computer Science (AI specialisation) student at Heriot-Watt University Dubai, currently interning as an AI software engineer building C# AI agents and LLM evaluation pipelines professionally.

AgentEval is built entirely from scratch — no agent framework, no scaffolding — to demonstrate genuine understanding of how AI agent systems work at the architectural level.

