# DragonzLandBot
DragonzLandBot Auto Farm

## ⚠️⚠️New Version⚠️⚠️
[New Version](https://github.com/glad-tidings/DragonzLandBot-New)

## ⚠️Warning
I am not responsible for your account. Please consider the potential risks before using this bot.

## Features
| Feature                   | Supported |
| :------------------------ | :-------- |
| Multithreading            | ✅        |
| Auto Claim Task           | ✅        |
| Auto Tap                  | ✅        |

## Settings
open project in visual studio ([Download Visual Studio Express](https://visualstudio.microsoft.com/vs/express/)) and in program.cs find
```c#
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 0, Name = "Account 1", Auth = "query_id" });
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 1, Name = "Account 2", Auth = "query_id" });
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 2, Name = "Account 3", Auth = "query_id" });
// max 17
```
for each account(max 17) you need to add an Add in a new line, for example for 3 accounts:
```c#
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 0, Name = "Account 1", Auth = "query_id of account 1" });
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 1, Name = "Account 2", Auth = "query_id of account 2" });
DragonzLandQueries.Add(new DragonzLandQuery() { Index = 2, Name = "Account 3", Auth = "query_id of account 3" });
```
and build or start project ([Get Telegram MiniGame Query ID using Chrome](https://youtu.be/r0Ulqev-9M4))

## QueryID Script
Script to request query_id of all your Telegram accounts for any mini Telegram Bot App ==> [TelegramMiniAppQueryID](https://github.com/glad-tidings/TelegramMiniAppQueryID)

## ☕Buy me a coffee
```
USDT(TRC20): TRjdnBWpS1xT4a2oKQdFsM3AAc6TxVmqGZ
TON: UQBmpnet6lYCLXObDwJLitDuMcPIocJIKVxg6pLvaFv5fRmO
```

![](http://visit.parselecom.com/Api/Visit/glad-tidings/DragonzLandBot/CF3476)
