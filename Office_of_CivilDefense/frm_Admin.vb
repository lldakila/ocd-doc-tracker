Public Class frm_admin_main
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frm_Memo_CDRRMC.Show()
        Me.Hide()
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        frmIncomingRGLnPRV.Show()
        Me.Hide()
    End Sub
End Class