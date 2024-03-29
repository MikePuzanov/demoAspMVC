using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using DemoAspMVC.Models;
using Newtonsoft.Json;

namespace DemoAspMVC.Services;

public class BaseService : IBaseService
{
    public ResponseDTO responseModel { get; set; }
    public IHttpClientFactory HttpClient { get; set; }

    public BaseService(IHttpClientFactory httpClient)
    {
        this.responseModel = new ResponseDTO();
        HttpClient = httpClient;
    }


    public async Task<T> SendAsync<T>(ApiRequest apiRequest)
    {
        try
        {
            var client = HttpClient.CreateClient("DemoAsp");
            var message = new HttpRequestMessage();
            message.Headers.Add("Accept", "application/json");
            message.RequestUri = new Uri(apiRequest.Url);
            client.DefaultRequestHeaders.Clear();
            if (apiRequest.Data != null)
            {
                message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data), Encoding.UTF8, "application/json");
            }

            if (!string.IsNullOrEmpty(apiRequest.AccesToken))
            {
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiRequest.AccesToken);
            }

            HttpResponseMessage apiResponse = null;
            switch (apiRequest.ApiType)
            {
                case Cfg.ApiType.POST:
                    message.Method = HttpMethod.Post;
                    break;
                case Cfg.ApiType.PUT:
                    message.Method = HttpMethod.Put;
                    break;
                case Cfg.ApiType.DELETE:
                    message.Method = HttpMethod.Delete;
                    break;
                default:
                    message.Method = HttpMethod.Get;
                    break;
            }

            apiResponse = await client.SendAsync(message);
            var apiContent = await apiResponse.Content.ReadAsStringAsync();
            var apiResponseDto = JsonConvert.DeserializeObject<T>(apiContent);
            return apiResponseDto;
        }
        catch (Exception e)
        {
            var dto = new ResponseDTO
            {
                DisplayMessage = "Error",
                ErrorMessages = new List<string> { Convert.ToString(e.Message) },
                IsSuccess = false
            };
            var res = JsonConvert.SerializeObject(dto);
            var apiResponseDto = JsonConvert.DeserializeObject<T>(res);
            return apiResponseDto;
        }
    }
    
    public void Dispose()
    {
        GC.SuppressFinalize(true);
    }
}