using System.Net.Http.Json;
using FeedbackIntelligenceSystem.UI.Models;

namespace FeedbackIntelligenceSystem.UI.Services;

public class FeedbackApiService
{
    private readonly HttpClient _httpClient;

    public FeedbackApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<FeedbackResponse>> GetFeedbacks()
{
    var response =
        await _httpClient.GetFromJsonAsync<
            ApiResponse<List<FeedbackResponse>>>(
                "http://localhost:5274/api/feedback");

    return response?.Data ?? new List<FeedbackResponse>();
}
}