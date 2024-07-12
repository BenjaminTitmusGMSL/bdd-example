namespace HtmlFormatterTests;

public static class ModuleInitializer
{
    [ModuleInitializer]
    public static void Initialize()
    {
        VerifyAngleSharpDiffing.Initialize();
    }
}