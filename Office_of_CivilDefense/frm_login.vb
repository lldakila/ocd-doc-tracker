Imports System.Data.SqlClient
Imports MySql.Data.MySqlClient
Public Class frm_login
    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Me.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim connection As New SqlConnection("Server=TESDADFASD=PC; Database = OCD; Integrated Security = true")

        Dim command As New SqlCommand("select * from tbl_login where Username = @username and Password = @password", connection)

        command.Parameters.Add("@username", SqlDbType.VarChar).Value = tb_Username.Text
        command.Parameters.Add("@password", SqlDbType.VarChar).Value = tb_Password.Text

        Dim adapter As New SqlDataAdapter(command)

        Dim table As New DataTable()

        adapter.Fill(table)

        If table.Rows.Count() <= 0 Then

            MessageBox.Show("Username Or Password Are Invalid")

        Else
            frm_admin_main.Show()

        End If
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Me.Close()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        frm_user_account.Show()
        Me.Hide()
    End Sub

    Private Sub CheckBoxSP_CheckedChanged(sender As Object, e As EventArgs) Handles CheckBoxSP.CheckedChanged
        If tb_Password.UseSystemPasswordChar = True Then

            tb_Password.UseSystemPasswordChar = False

        Else
            tb_Password.UseSystemPasswordChar = True
        End If
    End Sub
End Class