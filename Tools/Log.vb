Public Class Log
    Public Shared Sub Show(ByVal Game As String, ByVal Account As String, ByVal Message As String, ByVal Color As ConsoleColor)
        Console.ForegroundColor = ConsoleColor.White
        Console.Write($"[{Date.Now.ToString("yyyy-MM-dd HH:mm:ss")}] ")
        Console.ForegroundColor = ConsoleColor.DarkYellow
        Console.Write($"[{Game}] ")
        Console.ForegroundColor = ConsoleColor.Cyan
        Console.Write($"[{Account}] ")
        Console.ForegroundColor = Color
        Console.WriteLine(Message)
        Console.ResetColor()
    End Sub
End Class
