using System.Text.RegularExpressions;

namespace FeedbackIntelligenceSystem.API.Services;

public class PiiMaskingService
{
    public string Mask(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return text;

        // Phone numbers
        text = Regex.Replace(
            text,
            @"\b98\d{8}\b",
            "**********");

        // Account numbers (9+ digits)
        text = Regex.Replace(
            text,
            @"\b\d{9,}\b",
            "*********");

        return text;
	}
}