using Email_Generator.Dependencies;
using Email_Generator.Enums;
using Email_Generator.Models;


namespace Email_Generator.ReportingService;

public class ReportingService
{
    private readonly IReportRenderer _renderer;
    private readonly IEmailSender _emailSender;
    private readonly IAuditLogger _auditLogger;

    public ReportingService(
        IReportRenderer renderer,
        IEmailSender emailSender,
        IAuditLogger auditLogger)
    {
        _renderer = renderer;
        _emailSender = emailSender;
        _auditLogger =  auditLogger;
    }

    public async Task SendMonthlyReportAsync(string email, string name, SalesData salesData)
    {
        try
        {
            var report = new ReportBuilder.ReportBuilder()
                .ForRecipient(name, email)
                .WithSubject($"Monthly Sales Report - {DateTime.Now:MMMM yyyy}")
                .AddSection("Revenue Overview", $"Total Revenue: {salesData.FormatRevenue()}")
                .AddSection("Product Performance", $"Top Product: {salesData.FormatTopProduct()}")
                .AddSection("Customer Retention", $"Churn Rate: {salesData.FormatChurnRate()}")
                .InFormat(ReportFormat.Html) 
                .WithFooter("Automated Sales Intelligence System")
                .Build();
        }
        catch (Exception e)
        {
            _auditLogger.Log($"FAILED to send report to {email}. Error: {e.Message}");
            throw;
        }
    }
}