using CounterStrikeSharp.API;
using CounterStrikeSharp.API.Core;
using CounterStrikeSharp.API.Core.Translations;
using RedAlertPlugin.RedAlertClient.common;
using CSTimer = CounterStrikeSharp.API.Modules.Timers;
using PluginLogger = RedAlertPlugin.Logger.Logger;

namespace RedAlertPlugin;

public class RedAlertPlugin : BasePlugin, IPluginConfig<Config.Config>
{
    public override string ModuleName => "Red Alert Plugin";

    public override string ModuleVersion => "0.0.1";

    public Config.Config Config { get; set; }

    private RedAlertClient.RedAlertClient _redAlertClient;

    public void OnConfigParsed(Config.Config config)
    {
        Config = config;
        config.PrintConfig();
    }

    public override void Load(bool hotReload)
    {
        base.Load(hotReload);

        _redAlertClient = new RedAlertClient.RedAlertClient(Config.GetAlertsUrl);

        AddTimer(Config.FetchInterval, PeriodicallyFetchRedAlerts, CSTimer.TimerFlags.REPEAT);
    }

    private void PeriodicallyFetchRedAlerts()
    {
        if (Config.Debug)
        {
            PluginLogger.Instance.Debug("Fetching alert from Pikud Haoref");
        }

        var currentAlerts = _redAlertClient.GetCurrentAlerts().Result;
        if (currentAlerts == null)
        {
            return;
        }

        var redAlertMessage = ParseAlertMessage(currentAlerts);
        Server.PrintToChatAll(redAlertMessage);
    }

    private string ParseAlertMessage(Alert alert)
    {
        const string templatePath = "template.txt";
        var templateContent = File.ReadAllText($"{ModuleDirectory}/{templatePath}");

        var message = templateContent
            .Replace("{TITLE}", alert.title)
            .Replace("{DESCRIPTION}", alert.desc)
            .Replace("{CITIES}", string.Join(",", alert.data))
            .ReplaceColorTags()
            .Replace("\n", "\u2029");

        return message;
    }
}