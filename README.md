# DragonzLandBot
DragonzLandBot Auto Farm

## Features
| Feature                   | Supported |
| :------------------------ | :-------- |
| Multithreading            | ✅        |
| Auto Claim Task           | ✅        |
| Auto Tap                  | ✅        |
| Auto Hold Coins           | ✅        |

## Settings
open project in visual studio and in program.cs find
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
and build or start project

![](http://visit.parselecom.com/Api/Visit/18/CF3476)
