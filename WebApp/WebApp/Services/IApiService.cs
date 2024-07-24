using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using WebApp.Models;

public interface IApiService
{
    Task<string> GetApiResponseAsync();
    Task<string> GetUserLogin(string usn, string pass);
    Task<string> GetAllLocation();
    Task<string> GetOneLocation(string id);
    //Task<string> SaveTransaction(TransactionModel obj);
    Task<string> GetListTransaction();
}

public class ApiService : IApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ApiService> _logger;

    public ApiService(HttpClient httpClient, ILogger<ApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string> GetApiResponseAsync()
    {
        var response = await _httpClient.GetAsync("https://localhost:7166/Auth/login");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
    public async Task<string> GetUserLogin(string usn, string pass)
    {
        var response = await _httpClient.GetAsync("https://localhost:7166/" + usn + "/" + pass);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
    public async Task<string> GetAllLocation()
    {
        var response = await _httpClient.GetAsync("https://localhost:7166/");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
    public async Task<string> GetOneLocation(string id)
    {
        var response = await _httpClient.GetAsync("https://localhost:7166/" + id);
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
    //public async Task<string> SaveTransaction(TransactionModel obj)
    //{
    //    obj.created_on = DateTime.Now;
    //    obj.last_updated_on = DateTime.Now;
    //    string json = JsonConvert.SerializeObject(obj);
    //    var content = new StringContent(json, Encoding.UTF8, "application/json");
    //    var response = await _httpClient.PostAsync("https://localhost:7166/", content);
    //    response.EnsureSuccessStatusCode();

    //    var responseContent = await response.Content.ReadAsStringAsync();
    //    return responseContent;
    //}
    public async Task<string> GetListTransaction()
    {
        var response = await _httpClient.GetAsync("https://localhost:7166/");
        response.EnsureSuccessStatusCode();

        var responseContent = await response.Content.ReadAsStringAsync();
        return responseContent;
    }
}