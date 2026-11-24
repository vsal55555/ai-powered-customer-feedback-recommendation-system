using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackIntelligenceSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddRecommendationFields : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AssignedTeam",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IncidentTicket",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Priority",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "RecommendedAction",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AssignedTeam",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "IncidentTicket",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Priority",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "RecommendedAction",
                table: "Feedbacks");
        }
    }
}
