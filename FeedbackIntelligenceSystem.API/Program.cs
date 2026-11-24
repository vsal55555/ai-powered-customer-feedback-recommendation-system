using FeedbackIntelligenceSystem.API.Services;
using FeedbackIntelligenceSystem.API.Data;
using Microsoft.EntityFrameworkCore;
using FeedbackIntelligenceSystem.API.Middleware;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Register controllers
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    var xmlFile =
        $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

    var xmlPath =
        Path.Combine(AppContext.BaseDirectory, xmlFile);

    c.IncludeXmlComments(xmlPath);
});

builder.Services.AddHttpClient<GroqService>();

builder.Services.AddScoped<PiiMaskingService>();

builder.Services.AddScoped<RecommendationService>();

// Register SQL Server Database
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

app.UseSwagger();

app.UseSwaggerUI();

app.UseMiddleware<ExceptionMiddleware>();

// Configure middleware
app.UseHttpsRedirection();

app.UseAuthorization();

// Map API controllers
app.MapControllers();

// Default API homepage
app.MapGet("/", () =>
    "Feedback Intelligence System API is Running Successfully!");

app.MapGet("/echo", () =>
{
    return Results.Ok(new
    {
        Status = "Healthy",
        Timestamp = DateTime.UtcNow
    });
});

app.Run();
