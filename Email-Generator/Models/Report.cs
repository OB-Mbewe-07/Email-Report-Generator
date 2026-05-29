using EmailReportGenerator.Email_Generator.Enums;

namespace Email_Generator.Models;

public record Report(
    string RecipientEmail,
    string RecipientsName,
    string Subject,
    List<ReportSection> Sections,
    ReportFormat Format,
    DateTime GeneratedAt,
    string? Footer = null
);