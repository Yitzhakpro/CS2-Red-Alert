namespace RedAlertPlugin.RedAlertClient.common;

public class Alert
{
    public string Id { get; set; }
    public string cat { get; set; }
    public string title { get; set; }
    public List<string> data { get; set; }
    public string desc { get; set; }
}