# AI-Powered Customer Feedback Recommendation System

An intelligent banking feedback management solution built with ASP.NET Core, SQL Server, Blazor, and Generative AI.

The system automatically analyzes customer feedback, masks sensitive information, classifies complaints using AI, assigns the appropriate team, generates incident tickets, prioritizes issues, and recommends actions for resolution.

---

## Project Overview

Banks receive thousands of customer complaints and service requests through channels such as:

- Mobile Banking
- Internet Banking
- ATM/Card Services
- Branch Services
- Customer Support
- Loan Services
- Deposits

Manually reviewing and routing feedback is time-consuming.

This application automates the process using AI and business rules.

---

## Key Features

### AI-Powered Feedback Classification

Customer feedback is automatically classified into:

- Mobile Banking
- Internet Banking
- ATM/Cards
- Loans
- Deposits
- Branch Service
- Fraud/Security
- Others

---

### Sentiment Analysis

Detects customer sentiment:

- Positive
- Neutral
- Negative

---

### Urgency Detection

Automatically identifies urgency levels:

- Low
- Medium
- High

---

### Incident Ticket Generation

Creates unique incident tickets automatically.

Example:

```text
INC-20261123-C29BD3
```

---

### Priority Assignment

Business rules automatically assign priorities:

| Priority | Description |
|-----------|-------------|
| P1 | Critical |
| P2 | High |
| P3 | Medium |
| P4 | Low |

Example:

```text
Fraud/Security + High Urgency = P1
```

---

### Team Routing

Issues are automatically assigned to the correct team.

| Category | Assigned Team |
|-----------|--------------|
| Fraud/Security | Fraud Investigation Team |
| Mobile Banking | Digital Banking Team |
| Internet Banking | Digital Banking Team |
| ATM/Cards | Card Support Team |
| Loans | Loan Operations Team |
| Deposits | Customer Service Team |
| Branch Service | Branch Operations Team |

---

### Recommendation Engine

Generates recommended actions for faster resolution.

Example:

```text
Category: Fraud/Security

Recommended Action:
Escalate immediately and investigate account activity.
```

---

### PII Masking

Sensitive customer information is automatically masked.

Example:

Input:

```text
My account number 123456789 and phone 9841234567 were charged twice.
```

Stored:

```text
My account number ********* and phone ********** were charged twice.
```

---

### Dashboard

Blazor dashboard provides:

- Total Incidents
- Incident List
- Priority Tracking
- Category Monitoring
- Assigned Teams
- Recommendations

---

## System Architecture

```text
Customer Feedback
       │
       ▼
 ASP.NET Core API
       │
       ▼
 PII Masking Service
       │
       ▼
 Groq AI Classification
       │
       ├── Category
       ├── Sentiment
       └── Urgency
       │
       ▼
 Recommendation Engine
       │
       ├── Priority
       ├── Assigned Team
       └── Recommended Action
       │
       ▼
 SQL Server
       │
       ▼
 Blazor Dashboard
```

---
## 📷 Application Screenshots

### Main Application

<img width="1343" height="675" alt="image" src="https://github.com/user-attachments/assets/eeb749ba-22bf-4f80-9d86-73b57d1bd5a2" />

---

## 🖥️ Dashboard Components

<img width="1354" height="605" alt="image" src="https://github.com/user-attachments/assets/3da5d3d5-5931-4507-ae72-d21e9cf484cb" />

---

## Technology Stack

### Backend

- ASP.NET Core 10
- Entity Framework Core
- SQL Server
- REST API
- Swagger/OpenAPI

### AI

- Groq API
- GPT OSS Model

### Frontend

- Blazor Server

### Database

- SQL Server

### Tools

- Visual Studio 2026
- Postman
- Git
- GitHub

---

## Database Design

### Feedback Table

```sql
Feedbacks
(
    Id,
    IncidentTicket,
    FeedbackText,
    SourceChannel,
    Priority,
    Category,
    Sentiment,
    Urgency,
    AssignedTeam,
    RecommendedAction,
    CreatedAt
)
```

---

## Example API Response

```json
{
  "id": 10,
  "incidentTicket": "INC-20261123-C29BD3",
  "feedbackText": "Unauthorized transaction detected",
  "category": "Fraud/Security",
  "sentiment": "Negative",
  "urgency": "High",
  "priority": "P1",
  "assignedTeam": "Fraud Investigation Team",
  "recommendedAction": "Escalate immediately and investigate account activity"
}
```

---

## AI Evaluation & Accuracy Testing

To evaluate the effectiveness of the recommendation engine, a manually validated dataset was created and tested against the system.

### Test Dataset

A synthetic banking feedback dataset was generated containing customer feedback from multiple banking domains, including:

- Mobile Banking
- Internet Banking
- ATM/Cards
- Branch Services
- Loans
- Deposits
- Fraud/Security
- Remittance Services
- Customer Support

The dataset included positive, negative, and neutral feedback with varying urgency levels.

### Evaluation Process

For each feedback record:

1. Expected output was manually defined.
2. Feedback was submitted to the AI Recommendation System.
3. Actual output produced by Groq AI and the Recommendation Engine was recorded.
4. Results were compared and verified manually.

The following attributes were validated:

- Category Classification
- Sentiment Detection
- Urgency Detection
- Priority Assignment
- Assigned Team Mapping
- Recommended Action Generation

### Sample Evaluation

| Feedback |
|-----------|
| My account received an unexpected deposit from an unknown source. |

Expected:

```json
{
  "priority": "P1",
  "category": "Fraud/Security",
  "sentiment": "Negative",
  "urgency": "High",
  "assignedTeam": "Fraud Investigation Team"
}
```

Actual Output:

```json
{
  "priority": "P1",
  "category": "Fraud/Security",
  "sentiment": "Negative",
  "urgency": "High",
  "assignedTeam": "Fraud Investigation Team"
}
```

Result:

```text
Correct ✅
```

### Evaluation Results

| Metric | Result |
|----------|----------|
| Dataset Size | 60+ Feedback Samples |
| Categories Tested | 8 |
| Features Evaluated | 6 |
| Validation Method | Manual Review |
| Classification Accuracy | 95%+ |
| Priority Mapping Accuracy | 100% (Rule Based) |
| Team Assignment Accuracy | 100% (Rule Based) |

### Observations

- Fraud-related incidents were consistently identified with high confidence.
- Banking service requests were accurately routed to the responsible team.
- Sentiment detection showed strong performance on customer complaints and appreciation messages.
- Rule-based recommendation generation ensured consistent and explainable outputs.
- PII masking successfully protected sensitive customer information before AI processing.

### Example Categories Tested

- Mobile Banking App Issues
- ATM Card Problems
- Branch Service Complaints
- Fixed Deposit Requests
- Loan Processing Issues
- Fraud Alerts
- Unauthorized Transactions
- Internet Banking Errors
- Customer Service Requests

---

## Future Enhancements

- Authentication & Authorization
- Role-Based Access Control
- Email Notifications
- Power BI Integration
- Real-Time Dashboard
- Trend Analysis
- Category Analytics
- AI Chat Assistant
- Azure Deployment
- Docker Support
- Larger evaluation dataset (500+ samples)
- Precision / Recall metrics
- Confusion Matrix Visualization
- Human-in-the-loop feedback validation
- ML.NET supervised classifier comparison
- Real-world anonymized banking feedback dataset

---

## Learning Outcomes

This project demonstrates:

- Enterprise API Development
- AI Integration with .NET
- SQL Server Design
- Entity Framework Core
- Clean Architecture Principles
- Business Rule Engines
- Data Protection (PII Masking)
- Incident Management Workflows
- Blazor Dashboard Development

---

## Author

**Bishal Shrestha**

Core Banking Systems & Software Development Enthusiast

Focused on:

- .NET Development
- Banking Solutions
- AI-Powered Applications
- Data Engineering
- Cloud Technologies

