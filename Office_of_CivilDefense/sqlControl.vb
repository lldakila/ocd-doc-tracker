Imports MySql.Data.MySqlClient
Module sqlControl
    'Public ultracon As New MySqlConnection("Server=LAPTOP-UOSC739 ;userid=root; password='pass';Integrated Security = SSPI;Database=OCD;")
    Public ultracon As New MySqlConnection("Server=localhost;uid=root; password=;Integrated Security = SSPI;Database=OCD;")

    Sub ramcon()
        If ultracon.State = ConnectionState.Closed Then
            Try
                ultracon.Open()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        End If
    End Sub
End Module
