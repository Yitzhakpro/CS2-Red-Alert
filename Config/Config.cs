using System.Reflection;
using System.Text.Json.Serialization;
using CounterStrikeSharp.API.Core;

namespace RedAlertPlugin.Config;

public class Config : BasePluginConfig
{
    [JsonPropertyName("debug")] public bool Debug { get; set; } = false;

    [JsonPropertyName("getAlertsUrl")]
    public string GetAlertsUrl { get; set; } = "https://www.kore.co.il/redAlert.json";

    public void PrintConfig()
    {
        Logger.Logger.Instance.Info("Loaded config:");
        
        var type = GetType();
        foreach (var prop in type.GetProperties(BindingFlags.Public | BindingFlags.Instance))
        {
            Console.WriteLine($"{prop.Name}: {prop.GetValue(this)}");
        }
    }
}