namespace DemoAspMVC;

public class Cfg
{
    public static string ProductApiBase { get; set; }
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}