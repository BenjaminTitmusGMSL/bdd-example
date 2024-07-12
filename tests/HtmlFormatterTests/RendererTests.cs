namespace HtmlFormatterTests;

public class RendererTests
{
    [Fact]
    public async Task Simple_message_renders()
    {
        var result = await Renderer.Render("Hello world");
        await Verify(result, "html");
    }
}