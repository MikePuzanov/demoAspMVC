namespace DemoAspMVC.Models;

using static DemoAspMVC.Cfg;

public class ApiRequest
{
    public ApiType ApiType { get; set; }
    public string Url { get; set; } 
    public object Data { get; set; } 
    public string AccesToken { get; set; } 
}