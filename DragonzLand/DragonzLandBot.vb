Imports System.Net.Http
Imports System.Text
Imports System.Text.Json
Imports System.Threading

Public Class DragonzLandBot

    Private ReadOnly PubQuery As DragonzLandQuery
    Private ReadOnly AccessToken As String
    Public ReadOnly HasError As Boolean
    Public ReadOnly ErrorMessage As String

    Public Sub New(Query As DragonzLandQuery)
        PubQuery = Query
        Dim GetToken = DragonzLandGetToken().Result
        If GetToken IsNot Nothing Then
            AccessToken = GetToken.AccessToken
            HasError = False
            ErrorMessage = ""
        Else
            HasError = True
            ErrorMessage = "get token failed"
        End If
    End Sub

    Private Async Function DragonzLandGetToken() As Task(Of DragonzLandAuthResponse)
        Dim DLAPI As New DragonzLandApi(0, PubQuery.Auth, PubQuery.Index)
        Dim request As New DragonzLandAuthRequest With {.InitData = PubQuery.Auth}
        Dim serializedRequest = JsonSerializer.Serialize(request)
        Dim serializedRequestContent = New StringContent(serializedRequest, Encoding.UTF8, "application/json")
        Dim httpResponse = Await DLAPI.DLAPIPost("https://bot.dragonz.land/api/auth/telegram", serializedRequestContent)
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Dim responseStream = Await httpResponse.Content.ReadAsStreamAsync()
                Dim responseJson = Await JsonSerializer.DeserializeAsync(Of DragonzLandAuthResponse)(responseStream)
                Return responseJson
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Async Function DragonzLandUserDetail() As Task(Of DragonzLandMeResponse)
        Dim rDLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim rewardResponse = Await rDLAPI.DLAPIGet("https://bot.dragonz.land/api/tasks/welcome-reward")
        Thread.Sleep(3000)
        Dim DLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim httpResponse = Await DLAPI.DLAPIGet("https://bot.dragonz.land/api/me")
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Dim responseStream = Await httpResponse.Content.ReadAsStreamAsync()
                Dim responseJson = Await JsonSerializer.DeserializeAsync(Of DragonzLandMeResponse)(responseStream)
                Return responseJson
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Async Function DragonzLandTasks() As Task(Of List(Of DragonzLandTaskResponse))
        Dim DLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim httpResponse = Await DLAPI.DLAPIGet("https://bot.dragonz.land/api/tasks")
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Dim responseStream = Await httpResponse.Content.ReadAsStreamAsync()
                Dim responseJson = Await JsonSerializer.DeserializeAsync(Of List(Of DragonzLandTaskResponse))(responseStream)
                Return responseJson
            Else
                Return Nothing
            End If
        Else
            Return Nothing
        End If
    End Function

    Public Async Function DragonzLandTasksVerify(taskId As String) As Task(Of Boolean)
        Dim DLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim request As New DragonzLandTaskDoneRequest With {.TaskId = taskId}
        Dim serializedRequest = JsonSerializer.Serialize(request)
        Dim serializedRequestContent = New StringContent(serializedRequest, Encoding.UTF8, "application/json")
        Dim httpResponse = Await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/tasks/verify", serializedRequestContent)
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Async Function DragonzLandFeed(feedCount As Integer) As Task(Of Boolean)
        Dim DLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim request As New DragonzLandFeedRequest With {.FeedCount = feedCount}
        Dim serializedRequest = JsonSerializer.Serialize(request)
        Dim serializedRequestContent = New StringContent(serializedRequest, Encoding.UTF8, "application/json")
        Dim httpResponse = Await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/feed", serializedRequestContent)
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

    Public Async Function DragonzLandBuyBoost(boostId As String) As Task(Of Boolean)
        Dim DLAPI As New DragonzLandApi(1, AccessToken, PubQuery.Index)
        Dim request As New DragonzLandBoostBuyRequest With {.BoostId = boostId}
        Dim serializedRequest = JsonSerializer.Serialize(request)
        Dim serializedRequestContent = New StringContent(serializedRequest, Encoding.UTF8, "application/json")
        Dim httpResponse = Await DLAPI.DLAPIPost("https://bot.dragonz.land/api/me/boosts/buy", serializedRequestContent)
        If httpResponse IsNot Nothing Then
            If httpResponse.IsSuccessStatusCode Then
                Return True
            Else
                Return False
            End If
        Else
            Return False
        End If
    End Function

End Class
