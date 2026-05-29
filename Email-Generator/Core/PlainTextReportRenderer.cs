using System.Text;
using Email_Generator.Dependencies;
using Email_Generator.Models;

namespace Email_Generator.Core;

public class PlainTextReportRenderer : IReportRenderer
{
    public string Renderer(Report report)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("REPORT: " + report.Subject);
        sb.AppendLine(new string('=', report.Subject.Length + 8)); 
        sb.AppendLine($"To:      {report.RecipientsName}");
        sb.AppendLine($"Email:   {report.RecipientEmail}");
        sb.AppendLine($"Format:  {report.Format}");
        sb.AppendLine();
        
        foreach (var section in report.Sections)
        {
            sb.AppendLine($"--- {section.Title.ToUpper()} ---");
            sb.AppendLine(section.body);
            sb.AppendLine();
        }
        
        if (!string.IsNullOrWhiteSpace(report.Footer))
        {
            sb.AppendLine(new string('-', 30));
            sb.AppendLine(report.Footer);
        }
        
        return sb.ToString();
    }
}