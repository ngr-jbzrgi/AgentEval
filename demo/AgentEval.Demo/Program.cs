using Microsoft.Extensions.DependencyInjection;
using AgentEval.Core.Agent;
using AgentEval.Core.Agent.Memory;
using AgentEval.Core.Client;

// ۱. بررسی متغیر محیطی
string? apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");
if (string.IsNullOrWhiteSpace(apiKey))
{
    throw new InvalidOperationException("OPENAI_API_KEY environment variable is not set.");
}

// ۲. راه‌اندازی کانتینر سرویس‌ها
var services = new ServiceCollection();

// ثبت ابزار استاندارد مدیریت درخواست‌های شبکه
services.AddHttpClient(); 

// ثبت حافظه به عنوان یک نمونه مشترک (Singleton)
services.AddSingleton<IConversationMemory, InMemoryConversation>();

// ثبت کلاینت با استفاده از Factory Pattern برای تزریق کلید
services.AddSingleton<ILlmClient>(provider => 
{
    var httpClientFactory = provider.GetRequiredService<IHttpClientFactory>();
    var client = httpClientFactory.CreateClient();
    return new OpenAiClient(client, apiKey);
});

// ثبت ایجنت به عنوان یک نمونه موقت (Transient)
services.AddTransient<IAgent, AgentLoop>();

// ۳. ساخت کانتینر نهایی (Build) و دریافت ایجنت بدون استفاده از new
var serviceProvider = services.BuildServiceProvider();
var agentLoop = serviceProvider.GetRequiredService<IAgent>();

// ۴. اجرای حلقه برنامه
while (true)
{
    Console.Write("You: ");
    var userInput = Console.ReadLine();

    if (string.IsNullOrWhiteSpace(userInput) || userInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
        break;

    var response = await agentLoop.RunAsync(userInput);
    Console.WriteLine($"Assistant: {response}");
}