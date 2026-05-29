
  


# <img src="https://img.icons8.com/?size=1000&id=LKaOHNqQKHDM&format=png&color=000000" alt="Email-Generator Logo" width="27"/> Email-Generator

A C# console application that demonstrates the **Builder** and **Facade** design patterns by implementing a monthly sales report email service.

## What It Does

The application takes raw sales data, builds a structured report, renders it in a chosen format, and delivers it via email — all coordinated behind a single, clean service interface.

## Project Structure

```
Email-Generator/
├── Core/
│   ├── EmailSender.cs            # Sends the rendered report via email
│   ├── FileAuditLogger.cs        # Logs audit events to a file
│   ├── HtmlReportRenderer.cs     # Renders reports as HTML email strings
│   └── PlainTextReportRenderer.cs # Renders reports as plain text
├── Dependencies/
│   ├── IAuditLogger.cs           # Interface for audit logging
│   ├── IEmailSender.cs           # Interface for email delivery
│   └── IReportRenderer.cs        # Interface for report rendering
├── Enums/
│   └── ReportFormat.cs           # Html | PlainText
├── Models/
│   ├── Report.cs                 # Immutable record — the assembled report
│   ├── ReportSection.cs          # Immutable value object — title + body
│   └── SalesData.cs              # Raw sales figures with formatting methods
├── ReportBuilder/
│   └── ReportBuilder.cs          # Fluent builder for assembling Report objects
├── ReportingService/
│   └── ReportingService.cs       # Facade — one public method hides everything
└── Program.cs                    # Entry point — wires dependencies and runs the app
```

## Design Patterns Used

### Builder — `ReportBuilder`
Assembles a `Report` object step by step using a fluent API. Each method returns `this`, allowing calls to be chained. `Build()` validates all required fields before producing the final immutable record.

```csharp
var report = new ReportBuilder()
    .WithTitle("May Sales Report")
    .ForRecipient("Alice")
    .InFormat(ReportFormat.Html)
    .AddSection("Revenue", salesData.FormatRevenue())
    .Build();
```

### Facade — `ReportingService`
Hides the complexity of building, rendering, logging, and sending behind a single method. The caller never imports or interacts with the renderer, sender, or logger directly.

```csharp
await reportingService.SendMonthlyReportAsync("alice@company.com", "Alice", salesData);
```

## Key Design Decisions

- **Records for models** — `Report`, `ReportSection`, and `SalesData` are immutable by design. They represent snapshots of data that should never change after creation.
- **Interfaces for dependencies** — `IReportRenderer`, `IEmailSender`, and `IAuditLogger` allow implementations to be swapped without touching `ReportingService`.
- **Constructor injection** — `ReportingService` receives all dependencies through its constructor, making it easy to test and extend.

## Getting Started

**Prerequisites:** .NET 8 SDK or later

```bash
git clone <repo-url>
cd Email-Generator
dotnet run
```

To switch between HTML and plain text rendering, swap the renderer passed into `ReportingService` in `Program.cs` — no other changes required.