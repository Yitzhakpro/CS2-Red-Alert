# CS2-Red-Alert

A plugin for showing Red Alerts (Pikud-Haoref alerts) in the server chat.

## Installation

1. Install [CounterStrikeSharp](https://github.com/roflmuffin/CounterStrikeSharp/releases)
   and [Metamod:Source](https://www.sourcemm.net/downloads.php/?branch=master) on your
   server (you can find a detailed
   tutorial [here](https://docs.cssharp.dev/docs/guides/getting-started.html)).
2. Download the latest release of CS2-Red-Alert from
   the [releases page](https://github.com/Yitzhakpro/CS2-Red-Alert/releases).
3. Extract the contents of the zip into your server's `game\csgo\addons\counterstrikesharp\plugins` folder.

## Configuration

The config is initialized when the plugin is loaded for the first time. You can find the config file at
`\game\csgo\addons\counterstrikesharp\configs\plugins\RedAlertPlugin\RedAlertPlugin.json`.

### Config options

- **debug**: if true, more logs will be printed to the console (default: false)
- **fetchInterval**: amount of seconds between each alerts fetch (default: 5)
- **getAlertsUrl**: the URL to fetch the alerts from (default: "https://www.kore.co.il/redAlert.json")

The plugin comes with a default template message that will be sent to the server chat when a new alert is fetched.<br/>
You can customize the message by editing the `template.txt` file located in the plugin folder (
`\game\csgo\addons\counterstrikesharp\plugins\RedAlertPlugin\template.txt`).

### Custom colors & Formatting

You can use the following color codes in the template message:
`DEFAULT, WHITE, DARKRED, GREEN, LIGHTYELLOW, LIGHTBLUE, OLIVE, LIME, RED, LIGHTPURPLE, PURPLE, GREY, YELLOW, GOLD, SILVER, BLUE, DARKBLUE, BLUEGREY, MAGENTA, LIGHTRED, ORANGE`.

To add a new line, use the `\n` character or just press `ENTER` in the template file.