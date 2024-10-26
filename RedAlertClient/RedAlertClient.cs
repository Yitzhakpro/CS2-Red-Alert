using System.Text.Json;
using RedAlertPlugin.RedAlertClient.common;
using PluginLogger = global::RedAlertPlugin.Logger.Logger;

namespace RedAlertPlugin.RedAlertClient;

public class RedAlertClient
{
    private readonly HttpClient _httpClient;
    private readonly string _getAlertsUrl;

    public RedAlertClient(string getAlertsUrl, HttpClient httpClient = null)
    {
        _httpClient = httpClient ?? new HttpClient();
        _getAlertsUrl = getAlertsUrl;
    }

    public async Task<Alert?> GetCurrentAlerts()
    {
        try
        {
            var response = await _httpClient.GetAsync(_getAlertsUrl);
            var jsonResponse = await response.Content.ReadAsStringAsync();

            var alerts = JsonSerializer.Deserialize<Alert>(jsonResponse);

            return alerts;
        }
        catch (Exception e)
        {
            PluginLogger.Instance.Error($"Failed to fetch alerts from Pikud Haoref {e}");
            return null;
        }
    }
}