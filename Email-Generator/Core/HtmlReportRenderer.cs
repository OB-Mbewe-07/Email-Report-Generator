using System.Text;
using Email_Generator.Dependencies;
using Email_Generator.Models;

namespace Email_Generator.Core;

public class HtmlReportRenderer : IReportRenderer
{
    public string Renderer(Report report)
    {
        var sb = new StringBuilder();
        
        sb.AppendLine("<!DOCTYPE html>");
        sb.AppendLine("<html>");
        sb.AppendLine("<head>");
        sb.AppendLine("  <style>");
        sb.AppendLine("    body { font-family: sans-serif; line-height: 1.6; color: #333; }");
        sb.AppendLine("    .header { border-bottom: 2px solid #eee; padding-bottom: 10px; }");
        sb.AppendLine("    .section { margin-top: 20px; }");
        sb.AppendLine("    .footer { margin-top: 30px; font-size: 0.8em; color: #777; border-top: 1px solid #eee; }");
        sb.AppendLine("  </style>");
        sb.AppendLine("</head>");
        sb.AppendLine("<body>");
        
        sb.AppendLine("  <div class='header'>");
        sb.AppendLine($"    <h1>{report.Subject}</h1>");
        sb.AppendLine($"    <p><strong>To:</strong> {report.RecipientsName} ({report.RecipientEmail})</p>");
        sb.AppendLine("  </div>");

        foreach (var section in report.Sections)
        {
            sb.AppendLine("  <div class='section'>");
            sb.AppendLine($"    <h2 style='color: #2c3e50;'>{section.Title}</h2>");
            sb.AppendLine($"    <p>{section.body}</p>");
            sb.AppendLine("  </div>");
        }

        if (!string.IsNullOrWhiteSpace(report.Footer))
        {
            sb.AppendLine("  <div class='footer'>");
            sb.AppendLine($"    <p>{report.Footer}</p>");
            sb.AppendLine("  </div>");
        }
        
        sb.AppendLine("</body>");
        sb.AppendLine("</html>");
        
        return sb.ToString();
    }
}