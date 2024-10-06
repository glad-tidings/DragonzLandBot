using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using Microsoft.VisualBasic;

namespace DragonzLandBot
{

    static class Program
    {

        private readonly static List<DragonzLandQuery> DragonzLandQueries = new List<DragonzLandQuery>();

        public static void Main()
        {
            DragonzLandQueries.Add(new DragonzLandQuery() { Index = 0, Name = "Account 1", Auth = "query_id" });
            DragonzLandQueries.Add(new DragonzLandQuery() { Index = 1, Name = "Account 2", Auth = "query_id" });
            DragonzLandQueries.Add(new DragonzLandQuery() { Index = 2, Name = "Account 3", Auth = "query_id" });
            // max 17

            Console.WriteLine("----------------------- Dragonz Land Bot Starting -----------------------");
            Console.WriteLine();

            foreach (var Query in DragonzLandQueries)
            {
                var BotThread = new Thread(() => DragonzLandThread(Query));
                BotThread.Start();

                Thread.Sleep(60000);
            }

            Console.ReadLine();
        }

        public async static void DragonzLandThread(DragonzLandQuery Query)
        {
            while (true)
            {
                var RND = new Random();

                var Bot = new DragonzLandBot(Query);
                if (!Bot.HasError)
                {
                    Log.Show("DragonzLand", Query.Name, $"login successfully.", ConsoleColor.Green);
                    var Sync = await Bot.DragonzLandUserDetail();
                    if (Sync is not null)
                    {
                        Log.Show("DragonzLand", Query.Name, $"synced successfully. B<{Sync.Coins}> D<{Sync.Diamonds}> P<{Sync.Power}> L<{Sync.Level}> E<{Sync.Energy}> F<{Sync.FeedCoins}>", ConsoleColor.Green);
                        var taskList = await Bot.DragonzLandTasks();
                        if (taskList is not null)
                        {
                            foreach (var task in taskList.Where(x => x.Active == true & x.Recurrence == "daily"))
                            {
                                var syncTask = Sync.Tasks.Where(x => (x.TaskId ?? "") == (task.Id ?? ""));
                                bool taskDo = false;
                                if (syncTask.Count() == 0)
                                {
                                    taskDo = true;
                                }
                                else if (syncTask.ElementAtOrDefault(0).ActiveAt.HasValue)
                                {
                                    if (syncTask.ElementAtOrDefault(0).ActiveAt.Value.ToLocalTime() < DateTime.Now)
                                    {
                                        taskDo = true;
                                    }
                                }

                                if (taskDo)
                                {
                                    bool claimTask = await Bot.DragonzLandTasksVerify(task.Id);
                                    if (claimTask)
                                    {
                                        Log.Show("DragonzLand", Query.Name, $"task '{task.Title}' completed", ConsoleColor.Green);
                                    }
                                    else
                                    {
                                        Log.Show("DragonzLand", Query.Name, $"task '{task.Title}' failed", ConsoleColor.Red);
                                    }

                                    int eachtaskRND = RND.Next(7, 20);
                                    Thread.Sleep(eachtaskRND * 1000);
                                }
                            }
                        }

                        int feedCount = (int)Math.Round(Sync.Energy / (double)Sync.FeedCoins);
                        bool feed = await Bot.DragonzLandFeed(feedCount);
                        if (feed)
                        {
                            Log.Show("DragonzLand", Query.Name, $"'{feedCount}' taps completed", ConsoleColor.Green);
                        }
                        else
                        {
                            Log.Show("DragonzLand", Query.Name, $"tap failed", ConsoleColor.Red);
                        }

                        var syncBoost = Sync.Boosts.Where(x => x.BoostId == "daily-energy-recharge");
                        bool boostDo = false;
                        if (syncBoost.Count() == 0)
                        {
                            boostDo = true;
                        }
                        else if (syncBoost.ElementAtOrDefault(0).ActiveAt.HasValue)
                        {
                            if (syncBoost.ElementAtOrDefault(0).ActiveAt.Value.ToLocalTime() < DateTime.Now)
                            {
                                boostDo = true;
                            }
                        }

                        if (boostDo)
                        {
                            bool busBoost = await Bot.DragonzLandBuyBoost("daily-energy-recharge");
                            if (busBoost)
                            {
                                Log.Show("DragonzLand", Query.Name, $"buy 'Full Energy' completed", ConsoleColor.Green);
                                feedCount = (int)Math.Round(Sync.EnergyLimit / (double)Sync.FeedCoins);
                                feed = await Bot.DragonzLandFeed(feedCount);
                                if (feed)
                                {
                                    Log.Show("DragonzLand", Query.Name, $"'{feedCount}' taps completed", ConsoleColor.Green);
                                }
                                else
                                {
                                    Log.Show("DragonzLand", Query.Name, $"tap failed", ConsoleColor.Red);
                                }
                            }
                            else
                            {
                                Log.Show("DragonzLand", Query.Name, $"buy 'Full Energy' failed", ConsoleColor.Red);
                            }
                        }
                    }
                    else
                    {
                        Log.Show("DragonzLand", Query.Name, $"synced failed", ConsoleColor.Red);
                    }
                }
                else
                {
                    Log.Show("DragonzLand", Query.Name, $"{Bot.ErrorMessage}", ConsoleColor.Red);
                }

                int syncRND = RND.Next(1000, 2000);
                Log.Show("DragonzLand", Query.Name, $"sync sleep '{Conversion.Int(syncRND / 3600d)}h {Conversion.Int(syncRND % 3600 / 60d)}m {syncRND % 60}s'", ConsoleColor.Yellow);
                Thread.Sleep(syncRND * 1000);
            }
        }
    }
}