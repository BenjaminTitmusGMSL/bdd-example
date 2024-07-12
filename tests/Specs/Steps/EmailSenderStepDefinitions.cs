namespace Specs.Steps;

[Binding]
public class EmailSenderStepDefinitions(EmailSenderDriver emailSenderDriver)
{
    [Then("an email is sent with message {string}")]
    public async Task ThenEmailIsSentWithMessage(string message)
    {
        await emailSenderDriver.CheckMessageReceived(message);
    }
}
