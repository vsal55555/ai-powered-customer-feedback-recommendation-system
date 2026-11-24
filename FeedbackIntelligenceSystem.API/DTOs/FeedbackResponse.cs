namespace FeedbackIntelligenceSystem.API.DTOs;

public class FeedbackResponse
{
    public int Id { get; set; }

    public string IncidentTicket { get; set; } = string.Empty;

    public string FeedbackText { get; set; } = string.Empty;

    public string SourceChannel { get; set; } = string.Empty;

    public string Priority { get; set; } = string.Empty;

    public string Category { get; set; } = string.Empty;

    public string Sentiment { get; set; } = string.Empty;

    public string Urgency { get; set; } = string.Empty;

    public string AssignedTeam { get; set; } = string.Empty;

    public string RecommendedAction { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}