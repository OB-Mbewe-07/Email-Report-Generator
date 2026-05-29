namespace Email_Generator.Dependencies;

public interface IEmailSender
{
    Task SendEmail(string toAddress, string subject, string body);
}