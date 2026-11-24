namespace FeedbackIntelligenceSystem.API.DTOs;

public class AiFeedbackAnalysis
{
    public string Category { get; set; } = string.Empty;

    public string Sentiment { get; set; } = string.Empty;

    public string Urgency { get; set; } = string.Empty;
}