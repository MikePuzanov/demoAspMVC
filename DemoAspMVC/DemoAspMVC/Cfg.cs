namespace DemoAspMVC;

public class Cfg
{
    public static string ProductApiBase { get; set; }
    public static string AccountApiBase { get; set; }
    public enum ApiType
    {
        GET,
        POST,
        PUT,
        DELETE
    }
}