using FeedbackIntelligenceSystem.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace FeedbackIntelligenceSystem.API.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<Feedback> Feedbacks => Set<Feedback>();
}
