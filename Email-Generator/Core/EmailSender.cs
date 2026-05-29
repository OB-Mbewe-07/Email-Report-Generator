using Email_Generator.Dependencies;

namespace Email_Generator.Core;

public class EmailSender : IEmailSender
{
    public async Task SendEmail(string toAddress, string subject, string body)
    {
        await Task.Delay(500);
        
        Console.WriteLine("--- SENDING EMAIL ---");
        Console.WriteLine($"To:      {toAddress}");
        Console.WriteLine($"Subject: {subject}");
        Console.WriteLine($"Body:    {body.Substring(0, Math.Min(body.Length, 50))}...");
        Console.WriteLine("--- EMAIL SENT SUCCESSFULLY ---");
    }
}