namespace Specs.Steps;

[Binding]
public sealed class ApiStepDefinitions(ApiDriver apiDriver)
{
    [When("the message is updated to be {string}")]
    public async Task WhenTheMessageIsUpdatedToBe(string message)
    {
        await apiDriver.UpdateMessage(message);
    }
}