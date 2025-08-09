// WfcdService.cs
using System.Net.Http;
using System.Text.Json;
using WebApp.Models;

public class WfcdService
{
    private readonly HttpClient _httpClient;

    public WfcdService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<WarframeItem>> GetItemsByCategoryAsync(string category)
    {
        var url = $"http://localhost:3001/items/category/{category}";
        var response = await _httpClient.GetAsync(url);

        response.EnsureSuccessStatusCode();

        var json = await response.Content.ReadAsStringAsync();

        var items = JsonSerializer.Deserialize<List<WarframeItem>>(json, new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        });

        return items;
    }

}