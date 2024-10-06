Imports System.Net.Http

Public Class DragonzLandApi
    Private ReadOnly client As HttpClient

    Public Sub New(Mode As Integer, ByVal queryId As String, ByVal queryIndex As Integer)
        client = New HttpClient With {
            .Timeout = New TimeSpan(0, 0, 30)
        }
        If Mode = 1 Then client.DefaultRequestHeaders.Add("Authorization", $"Bearer {queryId}")
        client.DefaultRequestHeaders.Add("Accept-Language", "en-US")
        client.DefaultRequestHeaders.Add("Cache-Control", "no-cache")
        client.DefaultRequestHeaders.Add("Pragma", "no-cache")
        client.DefaultRequestHeaders.Add("Priority", "u=1, i")
        client.DefaultRequestHeaders.Add("Origin", "https://bot.dragonz.land")
        client.DefaultRequestHeaders.Add("Referer", "https://bot.dragonz.land/")
        client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "empty")
        client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "cors")
        client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-site")
        client.DefaultRequestHeaders.Add("Sec-Ch-Ua", """Google Chrome"";v=""125"", ""Chromium"";v=""125"", ""Not.A/Brand"";v=""24""")
        client.DefaultRequestHeaders.Add("User-Agent", Tools.getUserAgents(queryIndex))
        client.DefaultRequestHeaders.Add("accept", "*/*")
        client.DefaultRequestHeaders.Add("sec-ch-ua-mobile", "?0")
        client.DefaultRequestHeaders.Add("sec-ch-ua-platform", $"""{Tools.getUserAgents(queryIndex, True)}""")
        client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json")
    End Sub

    Public Async Function DLAPIGet(requestUri As String) As Task(Of HttpResponseMessage)
        Try
            Return Await client.GetAsync(requestUri)
        Catch ex As Exception
            Return New HttpResponseMessage With {.StatusCode = Net.HttpStatusCode.ExpectationFailed, .ReasonPhrase = ex.Message}
        End Try
    End Function

    Public Async Function DLAPIPost(requestUri As String, content As HttpContent) As Task(Of HttpResponseMessage)
        Try
            Return Await client.PostAsync(requestUri, content)
        Catch ex As Exception
            Return New HttpResponseMessage With {.StatusCode = Net.HttpStatusCode.ExpectationFailed, .ReasonPhrase = ex.Message}
        End Try
    End Function
End Class
