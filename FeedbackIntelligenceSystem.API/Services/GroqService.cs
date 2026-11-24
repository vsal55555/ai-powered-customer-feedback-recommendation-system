
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using FeedbackIntelligenceSystem.API.DTOs;

namespace FeedbackIntelligenceSystem.API.Services;

public class GroqService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public GroqService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<AiFeedbackAnalysis> ClassifyAsync(
        string feedbackText)
    {
        var apiKey = _configuration["GroqSettings:ApiKey"];

        if (string.IsNullOrWhiteSpace(apiKey))
        {
            throw new InvalidOperationException(
                "Groq API Key is missing.");
        }

        _httpClient.DefaultRequestHeaders.Authorization =
            new AuthenticationHeaderValue("Bearer", apiKey);

        var prompt = $$"""
        You are a banking customer feedback analyst.

        Analyze the customer's feedback and return ONLY valid JSON.

        Valid Categories:
        - Mobile Banking
        - ATM/Cards
        - Branch Service
        - Loans
        - Fraud/Security
        - Internet Banking
        - Deposits
        - Others

        Valid Sentiments:
        - Positive
        - Neutral
        - Negative

        Valid Urgency:
        - Low
        - Medium
        - High

        Response format:

        {
          "Category": "",
          "Sentiment": "",
          "Urgency": ""
        }

        Customer Feedback:

        {{feedbackText}}
        """;

        var requestBody = new
        {
            model = "openai/gpt-oss-120b",
            messages = new[]
            {
                new
                {
                    role = "user",
                    content = prompt
                }
            },
            temperature = 0.1
        };

        var content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.PostAsync(
            "https://api.groq.com/openai/v1/chat/completions",
            content);

        if (!response.IsSuccessStatusCode)
{
    var errorMessage =
        await response.Content.ReadAsStringAsync();

    throw new HttpRequestException(
        $"Groq API Error: {(int)response.StatusCode} - {errorMessage}");
}

        var responseJson =
            await response.Content.ReadAsStringAsync();

        using var document = JsonDocument.Parse(responseJson);

        var aiContent = document.RootElement
            .GetProperty("choices")[0]
            .GetProperty("message")
            .GetProperty("content")
            .GetString();

        if (string.IsNullOrWhiteSpace(aiContent))
        {
            throw new InvalidOperationException(
                "No response received from Groq.");
        }

        var result = JsonSerializer.Deserialize<AiFeedbackAnalysis>(
            aiContent,
            new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            });

        if (result == null)
        {
            throw new InvalidOperationException(
                "Failed to parse Groq response.");
        }

        return result;
    }
}
