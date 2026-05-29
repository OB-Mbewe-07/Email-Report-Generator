namespace Email_Generator.Dependencies;

public interface IAuditLogger
{
    void Log(string message);
}