using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FeedbackIntelligenceSystem.API.Migrations
{
    /// <inheritdoc />
    public partial class AddAiColumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Category",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Sentiment",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Urgency",
                table: "Feedbacks",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Category",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Sentiment",
                table: "Feedbacks");

            migrationBuilder.DropColumn(
                name: "Urgency",
                table: "Feedbacks");
        }
    }
}
