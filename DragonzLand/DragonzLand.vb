Imports System.Text.Json.Serialization

Public Class DragonzLandQuery
    Public Property Index As Integer
    Public Property Name As String
    Public Property Auth As String
End Class

Public Class DragonzLandAuthRequest
    <JsonPropertyName("initData")>
    Public Property InitData As String
End Class

Public Class DragonzLandAuthResponse
    <JsonPropertyName("accessToken")>
    Public Property AccessToken As String
    <JsonPropertyName("refreshToken")>
    Public Property RefreshToken As String
End Class

Public Class DragonzLandMeResponse
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("telegramUserId")>
    Public Property TelegramUserId As Long
    <JsonPropertyName("username")>
    Public Property Username As String
    <JsonPropertyName("firstName")>
    Public Property FirstName As String
    <JsonPropertyName("lastName")>
    Public Property LastName As String
    <JsonPropertyName("diamonds")>
    Public Property Diamonds As Integer
    <JsonPropertyName("coins")>
    Public Property Coins As Integer
    <JsonPropertyName("power")>
    Public Property Power As Integer
    <JsonPropertyName("feedCoins")>
    Public Property FeedCoins As Integer
    <JsonPropertyName("level")>
    Public Property Level As Integer
    <JsonPropertyName("energy")>
    Public Property Energy As Integer
    <JsonPropertyName("energyLimit")>
    Public Property EnergyLimit As Integer
    <JsonPropertyName("tasks")>
    Public Property Tasks As List(Of DragonzLandMeTask)
    <JsonPropertyName("boosts")>
    Public Property Boosts As List(Of DragonzLandMeBoost)
    <JsonPropertyName("cards")>
    Public Property Cards As List(Of DragonzLandMeCard)
End Class

Public Class DragonzLandMeTask
    <JsonPropertyName("taskId")>
    Public Property TaskId As String
    <JsonPropertyName("level")>
    Public Property Level As Integer
    <JsonPropertyName("attempts")>
    Public Property Attempts As Integer
    <JsonPropertyName("attemptedAt")>
    Public Property AttemptedAt As DateTime?
    <JsonPropertyName("activeAt")>
    Public Property ActiveAt As DateTime?
End Class

Public Class DragonzLandMeBoost
    <JsonPropertyName("boostId")>
    Public Property BoostId As String
    <JsonPropertyName("level")>
    Public Property Level As Integer
    <JsonPropertyName("attempts")>
    Public Property Attempts As Integer
    <JsonPropertyName("attemptedAt")>
    Public Property AttemptedAt As DateTime?
    <JsonPropertyName("activeAt")>
    Public Property ActiveAt As DateTime?
End Class

Public Class DragonzLandMeCard
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("cardId")>
    Public Property CardId As String
    <JsonPropertyName("level")>
    Public Property Level As Integer
    <JsonPropertyName("attemptedAt")>
    Public Property AttemptedAt As DateTime?
    <JsonPropertyName("activeAt")>
    Public Property ActiveAt As DateTime?
End Class

Public Class DragonzLandTaskResponse
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("type")>
    Public Property Type As String
    <JsonPropertyName("recurrence")>
    Public Property Recurrence As String
    <JsonPropertyName("attemptsLimit")>
    Public Property AttemptsLimit As Integer
    <JsonPropertyName("active")>
    Public Property Active As Boolean
    <JsonPropertyName("featured")>
    Public Property Featured As Boolean
    <JsonPropertyName("pinned")>
    Public Property Pinned As Boolean
    <JsonPropertyName("listed")>
    Public Property Listed As Boolean
    <JsonPropertyName("title")>
    Public Property Title As String
End Class

Public Class DragonzLandTaskDoneRequest
    <JsonPropertyName("taskId")>
    Public Property TaskId As String
End Class

Public Class DragonzLandFeedRequest
    <JsonPropertyName("feedCount")>
    Public Property FeedCount As Integer
End Class

Public Class DragonzLandBoostResponse
    <JsonPropertyName("id")>
    Public Property Id As String
    <JsonPropertyName("type")>
    Public Property Type As String
    <JsonPropertyName("active")>
    Public Property Active As Boolean
    <JsonPropertyName("comingSoon")>
    Public Property ComingSoon As Boolean
    <JsonPropertyName("title")>
    Public Property Title As String
    <JsonPropertyName("attemptsLimit")>
    Public Property AttemptsLimit As Integer
    <JsonPropertyName("recurrence")>
    Public Property Recurrence As String
End Class

Public Class DragonzLandBoostBuyRequest
    <JsonPropertyName("boostId")>
    Public Property BoostId As String
End Class

Public Class DragonzLandCardResponse

End Class