
using FeedbackIntelligenceSystem.API.Data;
using FeedbackIntelligenceSystem.API.Entities;
using FeedbackIntelligenceSystem.API.DTOs;
using FeedbackIntelligenceSystem.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FeedbackIntelligenceSystem.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FeedbackController : ControllerBase
{
    private readonly AppDbContext _context;
    private readonly PiiMaskingService _maskingService;
	private readonly GroqService _groqService;
	private readonly RecommendationService _recommendationService;
	private readonly ILogger<FeedbackController> _logger;

    public FeedbackController(
        AppDbContext context,
        PiiMaskingService maskingService,
		GroqService groqService,
		RecommendationService recommendationService,
		ILogger<FeedbackController> logger)
    {
        _context = context;
        _maskingService = maskingService;
		_groqService = groqService;
		_recommendationService = recommendationService;
		_logger = logger;
    }
	/// <summary>
	/// Submit customer feedback for AI analysis.
	/// </summary>
	/// <returns>
	/// AI-generated category, sentiment, urgency and recommendation.
	/// </returns>
    // POST: api/Feedback
    [HttpPost]
    public async Task<IActionResult> CreateFeedback(
        [FromBody] CreateFeedbackRequest request)
    {	
		if (!ModelState.IsValid)
		{
			return BadRequest(ModelState);
		}

		
		 // Step 1: Mask PII
        var maskedText = _maskingService.Mask(
            request.FeedbackText);
		
		_logger.LogInformation(
			"New feedback received from {Channel}",
				request.SourceChannel);
	
		  // Step 2: Analyze feedback using Groq AI
		var aiResult =
		await _groqService.ClassifyAsync(maskedText);
		
		var priority =
		_recommendationService.GetPriority(
        aiResult.Category,
        aiResult.Urgency);

		var assignedTeam =
		_recommendationService.GetAssignedTeam(
        aiResult.Category);

		var recommendedAction =
		_recommendationService.GetRecommendedAction(
        aiResult.Category);

		var incidentTicket =
		$"INC-{DateTime.Now:yyyyMMdd}-{Guid.NewGuid().ToString("N")[..6].ToUpper()}";
	
		// Step 3: Create feedback entity
        var feedback = new Feedback
{
    IncidentTicket = incidentTicket,
    FeedbackText = maskedText,
    SourceChannel = request.SourceChannel,

    Category = aiResult.Category,
    Sentiment = aiResult.Sentiment,
    Urgency = aiResult.Urgency,

    Priority = priority,
    AssignedTeam = assignedTeam,
    RecommendedAction = recommendedAction,

    CreatedAt = DateTime.UtcNow
};
		
		// Step 4: Save to SQL Server
        _context.Feedbacks.Add(feedback);

        await _context.SaveChangesAsync();
		
		_logger.LogInformation(
    "Ticket {TicketId} created successfully",
    feedback.IncidentTicket);
		
		// Step 5: Return response
        var response = new FeedbackResponse
{
    Id = feedback.Id,
    IncidentTicket = feedback.IncidentTicket,

    FeedbackText = feedback.FeedbackText,
    SourceChannel = feedback.SourceChannel,

    Category = feedback.Category,
    Sentiment = feedback.Sentiment,
    Urgency = feedback.Urgency,

    Priority = feedback.Priority,
    AssignedTeam = feedback.AssignedTeam,
    RecommendedAction = feedback.RecommendedAction,

    CreatedAt = feedback.CreatedAt
};

        return Ok(new ApiResponse<FeedbackResponse>
		{
			Success = true,
			Message = "Feedback submitted successfully.",
			Data = response
		});
    }
	/// <summary>
	/// Get all analyzed feedback records.
	/// </summary>
    // GET: api/Feedback
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var feedbacks = await _context.Feedbacks
            .OrderByDescending(x => x.CreatedAt)
            .Select(x => new FeedbackResponse
				{
					Id = x.Id,
					IncidentTicket = x.IncidentTicket,

					FeedbackText = x.FeedbackText,
					SourceChannel = x.SourceChannel,

					Priority = x.Priority,
					Category = x.Category,
					Sentiment = x.Sentiment,
					Urgency = x.Urgency,

					AssignedTeam = x.AssignedTeam,
					RecommendedAction = x.RecommendedAction,

					CreatedAt = x.CreatedAt
				})
            .ToListAsync();

        return Ok(
    new ApiResponse<List<FeedbackResponse>>
    {
        Success = true,
        Message = "Feedback record retrieved successfully.",
        Data = feedbacks
    });
    }

// GET: api/feedback/category?name=Fraud/Security
[HttpGet("category")]
public async Task<IActionResult> GetByCategory(
    [FromQuery] string name)
{
    var feedbacks = await _context.Feedbacks
        .Where(x => x.Category == name)
        .OrderByDescending(x => x.CreatedAt)
        .Select(x => new FeedbackResponse
        {
            Id = x.Id,
            IncidentTicket = x.IncidentTicket,

            FeedbackText = x.FeedbackText,
            SourceChannel = x.SourceChannel,

            Priority = x.Priority,
            Category = x.Category,
            Sentiment = x.Sentiment,
            Urgency = x.Urgency,

            AssignedTeam = x.AssignedTeam,
            RecommendedAction = x.RecommendedAction,

            CreatedAt = x.CreatedAt
        })
        .ToListAsync();

    return Ok(feedbacks);
}

// GET: api/feedback/team?name=Fraud Investigation Team
[HttpGet("team")]
public async Task<IActionResult> GetByTeam([FromQuery] string name)
{
    var feedbacks = await _context.Feedbacks
        .Where(x => x.AssignedTeam == name)
		.OrderByDescending(x => x.CreatedAt)
        .Select(x => new FeedbackResponse
        {
            Id = x.Id,
            IncidentTicket = x.IncidentTicket,

            FeedbackText = x.FeedbackText,
            SourceChannel = x.SourceChannel,

            Priority = x.Priority,
            Category = x.Category,
            Sentiment = x.Sentiment,
            Urgency = x.Urgency,

            AssignedTeam = x.AssignedTeam,
            RecommendedAction = x.RecommendedAction,

            CreatedAt = x.CreatedAt
        })
        .ToListAsync();

    return Ok(feedbacks);
}	
	
	
	// GET: api/feedback/10
[HttpGet("{id}")]
public async Task<IActionResult> GetById(int id)
{
    var feedback = await _context.Feedbacks
        .Where(x => x.Id == id)
        .Select(x => new FeedbackResponse
        {
            Id = x.Id,
            IncidentTicket = x.IncidentTicket,

            FeedbackText = x.FeedbackText,
            SourceChannel = x.SourceChannel,

            Priority = x.Priority,
            Category = x.Category,
            Sentiment = x.Sentiment,
            Urgency = x.Urgency,

            AssignedTeam = x.AssignedTeam,
            RecommendedAction = x.RecommendedAction,

            CreatedAt = x.CreatedAt
        })
        .FirstOrDefaultAsync();

    if (feedback == null)
    {
        return NotFound(new
        {
            Message = $"Feedback with ID {id} not found."
        });
    }

    return Ok(feedback);
}
}
