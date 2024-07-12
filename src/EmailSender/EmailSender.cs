using Logic.Interfaces;

namespace EmailSender;

public class EmailSender : IEmailSender
{
    public async Task SendMessage(string message)
    {
        var html = await HtmlFormatter.Renderer.Render(message);
        throw new NotImplementedException();
    }
}