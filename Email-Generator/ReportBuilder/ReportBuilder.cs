using Email_Generator.Models;
using EmailReportGenerator.Email_Generator.Enums;

namespace EmailReportGenerator.Email_Generator.ReportBuilder;

public class ReportBuilder
{
    private string _recipientEmail = string.Empty;
    private string _recipientName = string.Empty;
    private string _subject = string.Empty;
    private string? _footer;

    private ReportFormat _format = ReportFormat.PlainText;
    private List<ReportSection> _sections = new();
    private bool _isBuilt = false;


    public ReportBuilder ForRecipient(string name, string email)
    {
        _recipientEmail = email;
        _recipientName = name;

        return this;
    }

    public ReportBuilder WithSubject(string subject)
    {
        _subject = subject;
        return this;
    }

    private ReportBuilder AddSection(string title, string body)
    {
        _sections.Add(new ReportSection(title, body));
        return this;
    }

    public ReportBuilder InFormat(ReportFormat format)
    {
        _format = format;
        return this;
    }

    public ReportBuilder WithFooter(string footer)
    {
        _footer = footer;
        return this;
    }

    public Report Build()
    {
        if (_isBuilt)
        {
            throw new InvalidOperationException("This builder instance has already been used.");
        }

        if (string.IsNullOrWhiteSpace(_recipientEmail) || string.IsNullOrWhiteSpace(_recipientName))
        {
            throw new InvalidOperationException("Recipient name and email must be set before building the report.");
        }

        if (string.IsNullOrWhiteSpace(_subject))
        {
            throw new InvalidOperationException("Subject must be set before building the report.");
        }

        _isBuilt = true;

        return new Report(
            _recipientEmail,
            _recipientName,
            _subject,
            _sections,
            _format,
            _footer
        );
    }
}