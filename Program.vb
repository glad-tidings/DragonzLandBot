Imports System
Imports System.Threading

Module Program

    Private ReadOnly DragonzLandQueries As New List(Of DragonzLandQuery)

    Sub Main()
        DragonzLandQueries.Add(New DragonzLandQuery With {.Index = 0, .Name = "Account 1", .Auth = "query_id"})
        DragonzLandQueries.Add(New DragonzLandQuery With {.Index = 1, .Name = "Account 2", .Auth = "query_id"})
        DragonzLandQueries.Add(New DragonzLandQuery With {.Index = 2, .Name = "Account 3", .Auth = "query_id"})
        'max 17

        Console.WriteLine("----------------------- Dragonz Land Bot Starting -----------------------")
        Console.WriteLine()

        For Each Query In DragonzLandQueries
            Dim BotThread As New Thread(Sub() DragonzLandThread(Query))
            BotThread.Start()

            Thread.Sleep(60000)
        Next

        Console.ReadLine()
    End Sub

    Public Async Sub DragonzLandThread(Query As DragonzLandQuery)
        While True
            Dim RND As New Random()

            Dim Bot As New DragonzLandBot(Query)
            If Not Bot.HasError Then
                Log.Show("DragonzLand", Query.Name, $"login successfully.", ConsoleColor.Green)
                Dim Sync = Await Bot.DragonzLandUserDetail()
                If Sync IsNot Nothing Then
                    Log.Show("DragonzLand", Query.Name, $"synced successfully. B<{Sync.Coins}> D<{Sync.Diamonds}> P<{Sync.Power}> L<{Sync.Level}> E<{Sync.Energy}> F<{Sync.FeedCoins}>", ConsoleColor.Green)
                    Dim taskList = Await Bot.DragonzLandTasks()
                    If taskList IsNot Nothing Then
                        For Each task In taskList.Where(Function(x) x.Active = True And x.Recurrence = "daily")
                            Dim syncTask = Sync.Tasks.Where(Function(x) x.TaskId = task.Id)
                            Dim taskDo As Boolean = False
                            If syncTask.Count = 0 Then
                                taskDo = True
                            Else
                                If syncTask(0).ActiveAt.HasValue Then
                                    If syncTask(0).ActiveAt.Value.ToLocalTime < Date.Now Then
                                        taskDo = True
                                    End If
                                End If
                            End If

                            If taskDo Then
                                Dim claimTask = Await Bot.DragonzLandTasksVerify(task.Id)
                                If claimTask Then
                                    Log.Show("DragonzLand", Query.Name, $"task '{task.Title}' completed", ConsoleColor.Green)
                                Else
                                    Log.Show("DragonzLand", Query.Name, $"task '{task.Title}' failed", ConsoleColor.Red)
                                End If

                                Dim eachtaskRND As Integer = RND.Next(7, 20)
                                Thread.Sleep(eachtaskRND * 1000)
                            End If
                        Next
                    End If

                    Dim feedCount As Integer = Sync.Energy / Sync.FeedCoins
                    Dim feed = Await Bot.DragonzLandFeed(feedCount)
                    If feed Then
                        Log.Show("DragonzLand", Query.Name, $"'{feedCount}' taps completed", ConsoleColor.Green)
                    Else
                        Log.Show("DragonzLand", Query.Name, $"tap failed", ConsoleColor.Red)
                    End If

                    Dim syncBoost = Sync.Boosts.Where(Function(x) x.BoostId = "daily-energy-recharge")
                    Dim boostDo As Boolean = False
                    If syncBoost.Count = 0 Then
                        boostDo = True
                    Else
                        If syncBoost(0).ActiveAt.HasValue Then
                            If syncBoost(0).ActiveAt.Value.ToLocalTime < Date.Now Then
                                boostDo = True
                            End If
                        End If
                    End If

                    If boostDo Then
                        Dim busBoost = Await Bot.DragonzLandBuyBoost("daily-energy-recharge")
                        If busBoost Then
                            Log.Show("DragonzLand", Query.Name, $"buy 'Full Energy' completed", ConsoleColor.Green)
                            feedCount = Sync.EnergyLimit / Sync.FeedCoins
                            feed = Await Bot.DragonzLandFeed(feedCount)
                            If feed Then
                                Log.Show("DragonzLand", Query.Name, $"'{feedCount}' taps completed", ConsoleColor.Green)
                            Else
                                Log.Show("DragonzLand", Query.Name, $"tap failed", ConsoleColor.Red)
                            End If
                        Else
                            Log.Show("DragonzLand", Query.Name, $"buy 'Full Energy' failed", ConsoleColor.Red)
                        End If
                    End If
                Else
                    Log.Show("DragonzLand", Query.Name, $"synced failed", ConsoleColor.Red)
                End If
            Else
                Log.Show("DragonzLand", Query.Name, $"{Bot.ErrorMessage}", ConsoleColor.Red)
            End If

            Dim syncRND As Integer = RND.Next(1000, 2000)
            Log.Show("DragonzLand", Query.Name, $"sync sleep '{Int(syncRND / 3600)}h {Int((syncRND Mod 3600) / 60)}m {syncRND Mod 60}s'", ConsoleColor.Yellow)
            Thread.Sleep(syncRND * 1000)
        End While
    End Sub
End Module
