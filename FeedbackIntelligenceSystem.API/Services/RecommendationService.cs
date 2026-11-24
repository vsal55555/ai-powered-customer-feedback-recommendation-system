namespace FeedbackIntelligenceSystem.API.Services;

public class RecommendationService
{
    public string GetPriority(string category, string urgency)
    {
        if (category == "Fraud/Security" && urgency == "High")
            return "P1";

        if (urgency == "High")
            return "P2";

        if (urgency == "Medium")
            return "P3";

        return "P4";
    }

    public string GetAssignedTeam(string category)
    {
        return category switch
        {
            "Fraud/Security" => "Fraud Investigation Team",
            "Mobile Banking" => "Digital Banking Team",
            "ATM/Cards" => "Card Support Team",
            "Loans" => "Loan Operations Team",
            "Branch Service" => "Branch Operations Team",
            "Internet Banking" => "Digital Banking Team",
            "Deposits" => "Customer Service Team",
            _ => "Customer Service Team"
        };
    }

    public string GetRecommendedAction(string category)
    {
        return category switch
        {
            "Fraud/Security"
                => "Escalate immediately and investigate account activity",

            "Mobile Banking"
                => "Assign issue to Digital Banking Team",

            "ATM/Cards"
                => "Create card operations ticket",

            "Loans"
                => "Forward case to Loan Operations",

            "Branch Service"
                => "Notify Branch Manager",

            "Internet Banking"
                => "Assign issue to Digital Banking Team",

            "Deposits"
                => "Review deposit operations",

            _
                => "Manual review required"
        };
    }
}