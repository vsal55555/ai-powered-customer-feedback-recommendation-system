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

