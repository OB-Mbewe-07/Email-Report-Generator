using Email_Generator.Core;
using Email_Generator.Dependencies;
using Email_Generator.Models;
using Email_Generator.ReportingService;

IAuditLogger logger = new FileAuditLogger();
IReportRenderer renderer = new HtmlReportRenderer();
IEmailSender emailSender = new EmailSender();

var reportingServices = new ReportingService(renderer, emailSender, logger);

var monthlySales = new SalesData(
    Revenue: 125500.00m,
    TopProduct: "NVIDIA stocks",
    ChurnRate: 0.032
);

logger.Log("Application started. Preparing to send monthly reports...");

try
{
    await reportingServices.SendMonthlyReportAsyc(email :)
}