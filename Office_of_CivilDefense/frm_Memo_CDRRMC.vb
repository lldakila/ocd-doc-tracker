Imports System.Drawing.Printing
Public Class frm_Memo_CDRRMC

    Dim ResizedImage As Image
    Private Sub btn_browse_Click(sender As Object, e As EventArgs) Handles btn_browse.Click
        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            pb_1.Load(Me.OpenFileDialog1.FileName)

        End If
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click
        Me.Close()
    End Sub

    Private Sub frm_Memo_CDRRMC_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawImage(pb_1.Image, 0, 0)
    End Sub

    Private Sub btn_Print_Click(sender As Object, e As EventArgs) Handles btn_Print.Click
        PrintPreviewDialog1.Document = PrintDocument1
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        Dim Barcode, Check12Digits As String

        If Not (String.IsNullOrEmpty(TextBox2.Text)) Then

            Check12Digits = TextBox2.Text.PadRight(12, CChar("0"))
            Barcode = EAN13(Check12Digits)
            Label6.Text = Barcode

            If Not (String.IsNullOrEmpty(Barcode13Digits)) And
                    Not Barcode13Digits = "" Then
                RichTextBox2.Text = Barcode13Digits.Trim.ToString()
                'Change Colour of certain Text in a RichTextBox
                Dim intStart As Int16 = Convert.ToInt16(RichTextBox2.TextLength - 1)
                ChangeColor(RichTextBox2, intStart)
            End If
        End If
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        frm_admin_main.Show()
        Me.Hide()
    End Sub
End Class