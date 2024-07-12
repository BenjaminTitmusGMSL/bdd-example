using System.Net.Mail;
using Logic.Interfaces;

namespace EmailSender;

public class EmailSender(string? smtpServerHost, int smtpServerPort) : IEmailSender
{
    public async Task SendMessage(string message)
    {
        var html = await HtmlFormatter.Renderer.Render(message);

        SmtpClient client = new SmtpClient(smtpServerHost, smtpServerPort);
        MailAddress from = new MailAddress("from@gmsl.co.uk", "Test System");
        MailAddress to = new MailAddress("to@gmsl.co.uk", "End User");
        MailMessage mail = new MailMessage(from, to);
        mail.Subject = "Test Subject";
        mail.Body = html;
        mail.IsBodyHtml = true;
        client.Send(mail);
        mail.Dispose();
    }
}