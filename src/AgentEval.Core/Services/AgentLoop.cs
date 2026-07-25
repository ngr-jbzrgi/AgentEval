namespace AgentEval.Core.Services;

using AgentEval.Core.Client;
using AgentEval.Core.Client.Models;


public class AgentLoop (ILlmClient client){

    // حافظه برای نگهداری تاریخچه پیام‌ها 🧠
    public List<ChatMessage> Messages { get; set; } = new();

    public async Task<string> SendMessageAsync(string userText)
    {
    // قدم اول: ساخت یک پیام جدید از طرف کاربر و اضافه کردن آن به تاریخچه (History)
    
        var userMessage = new ChatMessage("user", userText);
        Messages.Add(userMessage);

    // قدم دوم: ساخت یک درخواست (Request) برای مدل زبان با استفاده از تاریخچه پیام‌ها

        var request = new ChatRequest
        {
            Messages = Messages,
            Model = "gpt-4o"
        };

    // قدم سوم: ارسال درخواست به مدل زبان و دریافت پاسخ     

        var response = await client.CompleteAsync(request);

    // قدم چهارم: ساخت یک پیام جدید از طرف مدل زبان و اضافه کردن آن به تاریخچه (History)

        var assistantMessage = new ChatMessage("assistant", response.Content);
        Messages.Add(assistantMessage);


        return response.Content;

    }

    

}