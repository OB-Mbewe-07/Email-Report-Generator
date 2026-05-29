using Email_Generator.Dependencies;

namespace Email_Generator.Core;

public class FileAuditLogger : IAuditLogger
{
    public void Log(string message)
    {
        string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.Write($"[{timestamp}] ");
        
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write("[AUDIT] ");
        
        Console.ResetColor();
        Console.WriteLine(message);
    }
}