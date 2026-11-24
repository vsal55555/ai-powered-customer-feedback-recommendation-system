using System.ComponentModel.DataAnnotations;

namespace FeedbackIntelligenceSystem.API.DTOs;

public class CreateFeedbackRequest
{
    [Required]
    [MaxLength(1000)]
    public string FeedbackText { get; set; } = string.Empty;

    [Required]
    [MaxLength(100)]
    public string SourceChannel { get; set; } = string.Empty;
}