using Email_Generator.Models;

namespace Email_Generator.Dependencies;

public interface IReportRenderer
{
    string Renderer(Report report);
}