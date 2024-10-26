namespace RedAlertPlugin.Logger;

public interface ILogger
{
    void Debug(string message);
    void Info(string message);
    void Warn(string message);
    void Error(string message);
}

public class Logger : ILogger
{
    public const string RED_ALERT_PREFIX = "[RedAlertPlugin]";

    public static Logger Instance { get; } = new Logger();

    private Logger()
    {
    }

    public void Debug(string message)
    {
        Log("DEBUG", message);
    }

    public void Info(string message)
    {
        Log("INFO", message);
    }

    public void Warn(string message)
    {
        Log("WARN", message);
    }

    public void Error(string message)
    {
        Log("ERROR", message);
    }

    private void Log(string level, string message)
    {
        var currentTimeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
        Console.WriteLine($"[{currentTimeStamp}] {RED_ALERT_PREFIX} [{level}] {message}");
    }
}