'prev tbl name from tbl_incoming_central

Imports System.IO
Imports MySql.Data.MySqlClient
Public Class frmIncCentralInfo
    Dim fileName As String
    Sub popDgv()
        Try
            Dim query As String = "select * from tbl_all_docu"
            Dim da As New MySqlDataAdapter(query, ultracon)
            Dim ds As New DataSet
            da.Fill(ds, "Emp")
            dgv.DataSource = ds.Tables(0)

            With dgv
                .Columns(0).HeaderText = "File ID"
                .Columns(1).HeaderText = "Barcode ID"
                .Columns(2).HeaderText = "Origin"
                .Columns(3).HeaderText = "Filename"
                .Columns(4).HeaderText = "Date Recieved"
                .Columns(5).HeaderText = "Recieved by"
                .Columns(6).HeaderText = "Subject"
                .Columns(7).HeaderText = "To"
                .Columns(8).HeaderText = "From"
                .Columns(9).HeaderText = "Date of Activity"
                .Columns(10).HeaderText = "Remarks"
                .Columns(11).HeaderText = "Actions Needed"

                .Columns(0).Width = 70
                '.Columns(0).Visible = False
                .Columns(1).Width = 200
                .Columns(2).Width = 200
                .Columns(3).Width = 200
                .Columns(4).Width = 200
                .Columns(5).Width = 200
                .Columns(6).Width = 200
                .Columns(7).Width = 200
                .Columns(8).Width = 200
                .Columns(9).Width = 200
                .Columns(10).Width = 200
            End With
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub clear()
        txtBarcode.Clear()
        txtFilePath.Clear()
        fileName = ""
        txtRecievedBy.Clear()
        txtSubject.Clear()
        txtTo.Clear()
        txtFrom.Clear()
        'dtpDateAct
        txtRemarks.Clear()
        txtActions.Clear()
        lblID.Text = "File ID"
        cbOrigin.Text = ""
        btnAdd.Enabled = True
    End Sub

    Sub add()
        Dim dcom As New MySqlCommand
        dcom.Connection = ultracon

        Try
            dcom.CommandText = "insert into tbl_all_docu(
                barcode_id,
                col_origin,
                filename,
                received_by,
                subject,
                col_to,
                col_from,
                date_activity,
                remarks,
                action_needed) 
                values(@bc, @orig, @fn, @rb, @sub, @to, @fr, @da, @rems, @an);"
            dcom.Parameters.AddWithValue("@bc", txtBarcode.Text)
            dcom.Parameters.AddWithValue("@orig", cbOrigin.Text)
            dcom.Parameters.AddWithValue("@fn", fileName)
            dcom.Parameters.AddWithValue("@rb", txtRecievedBy.Text)
            dcom.Parameters.AddWithValue("@sub", txtSubject.Text)
            dcom.Parameters.AddWithValue("@to", txtTo.Text)
            dcom.Parameters.AddWithValue("@fr", txtFrom.Text)
            dcom.Parameters.AddWithValue("@da", dtpDateAct.Value)
            dcom.Parameters.AddWithValue("@rems", txtRemarks.Text)
            dcom.Parameters.AddWithValue("@an", txtActions.Text)
            dcom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub edit()
        Dim dcom As New MySqlCommand
        dcom.Connection = ultracon

        Try
            dcom.CommandText = "update tbl_all_docu set
                barcode_id =  @bc,
                col_origin = @orig,
                filename = @fn,
                received_by = @rb,
                subject = @sub,
                col_to = @to,
                col_from = @fr,
                date_activity = @da,
                remarks = @rems,
                action_needed = @an
                where file_id = @id;"
            dcom.Parameters.AddWithValue("@bc", txtBarcode.Text)
            dcom.Parameters.AddWithValue("@orig", cbOrigin.Text)
            dcom.Parameters.AddWithValue("@fn", fileName)
            dcom.Parameters.AddWithValue("@rb", txtRecievedBy.Text)
            dcom.Parameters.AddWithValue("@sub", txtSubject.Text)
            dcom.Parameters.AddWithValue("@to", txtTo.Text)
            dcom.Parameters.AddWithValue("@fr", txtFrom.Text)
            dcom.Parameters.AddWithValue("@da", dtpDateAct.Value)
            dcom.Parameters.AddWithValue("@rems", txtRemarks.Text)
            dcom.Parameters.AddWithValue("@an", txtActions.Text)
            dcom.Parameters.AddWithValue("@id", lblID.Text)
            dcom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        MsgBox("Document with barcode ID:" + txtBarcode.Text + " was succesfully updated")
    End Sub

    Sub del()
        Dim dcom As New MySqlCommand
        dcom.Connection = ultracon

        Try
            dcom.CommandText = "delete from tbl_all_docu where file_id=@id;"
            dcom.Parameters.AddWithValue("@id", lblID.Text)
            dcom.ExecuteNonQuery()
        Catch ex As Exception
            MsgBox(ex)
        End Try
        MsgBox("Document with barcode ID:" + txtBarcode.Text + " was succesfully deleted")
    End Sub

    Sub search()
        Dim da As MySqlDataAdapter
        Dim ds As New DataSet
        Try
            'da = New MySqlDataAdapter("select * from tbl_all_docu where barcode_id like '%" & txtSearch.Text & "%';", ultracon)
            Dim dcom As New MySqlCommand
            'Dim @bc = txtSearch.Text
            dcom.Connection = ultracon
            dcom.CommandText = "select * from tbl_all_docu where barcode_id like '%" & txtSearch.Text & "%';"
            'dcom.Parameters.AddWithValue("@bc", txtSearch.Text)
            dcom.ExecuteNonQuery()
            da = New MySqlDataAdapter()
            da.SelectCommand = dcom
            da.Fill(ds)
            dgv.DataSource = ds.Tables(0)
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Sub upload()
        Try
            FileCopy(txtFilePath.Text, "\\LAPTOP-UOSC739\Doc Track Files\" + fileName)
            'FileCopy(fileName, "C:\OCDR2\Office_of_CivilDefense - Copy\Office_of_CivilDefense\bin\Debug\Doc Track Files\" + fileName)
            MsgBox("File Successfully Uploaded")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub

    Private Sub frm_DocuInfo_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ramcon()
        popDgv()
        dtpDateAct.Value = Date.Now
        'dtpDateAct.MinDate = Date.Now
        txtSearch.Select()
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        add()
        clear()
        popDgv()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        edit()
        clear()
        popDgv()
        btnAdd.Enabled = True
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        del()
        clear()
    End Sub

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        clear()
    End Sub

    Private Sub txtFilename_Click(sender As Object, e As EventArgs) Handles txtFilePath.Click
        OpenFileDialog1.ShowDialog()
    End Sub

    Private Sub OpenFileDialog1_FileOk(sender As Object, e As System.ComponentModel.CancelEventArgs) Handles OpenFileDialog1.FileOk
        txtFilePath.Text = OpenFileDialog1.FileName
        fileName = OpenFileDialog1.SafeFileName
    End Sub

    Private Sub btnUpload_Click(sender As Object, e As EventArgs) Handles btnUpload.Click
        If MessageBox.Show("Are you sure you have selected the right file", "File Upload", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            upload()
        End If
    End Sub

    Private Sub btnOpenFile_Click(sender As Object, e As EventArgs) Handles btnOpenFile.Click
        Try
            System.Diagnostics.Process.Start(txtFilePath.Text)
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try

    End Sub

    Private Sub frmIncCentralInfo_Activated(sender As Object, e As EventArgs) Handles MyBase.Activated
        ramcon()
        popDgv()
    End Sub

    Private Sub dgv_CellClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellClick
        btnAdd.Enabled = False
        Dim row As DataGridViewRow = dgv.CurrentRow
        Try
            lblID.Text = row.Cells(0).Value.ToString
            cbOrigin.Text = row.Cells(2).Value.ToString
            'txtFilePath.Text = "C:\OCDR2\Doc Track Files\" + row.Cells(3).Value.ToString
            txtFilePath.Text = "\\LAPTOP-UOSC739\Doc Track Files\" + row.Cells(3).Value.ToString
            fileName = row.Cells(3).Value.ToString
            txtRecievedBy.Text = row.Cells(5).Value.ToString
            txtSubject.Text = row.Cells(6).Value.ToString
            txtTo.Text = row.Cells(7).Value.ToString
            txtFrom.Text = row.Cells(8).Value.ToString
            dtpDateAct.Value = row.Cells(9).Value
            txtRemarks.Text = row.Cells(10).Value.ToString
            txtActions.Text = row.Cells(11).Value.ToString
            txtBarcode.Text = row.Cells(1).Value.ToString
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        search()
        'If txtSearch.Text.Length > 10 Then
        '    txtSearch.SelectAll()
        'End If
    End Sub

    Private Sub txtSearch_Click(sender As Object, e As EventArgs) Handles txtSearch.Click
        txtSearch.SelectAll()
    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        If Asc(e.KeyChar) = 13 Then
            search()
            txtSearch.SelectAll()
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        PrintPreviewDialog1.ShowDialog()
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Drawing.Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim ReportFont As Font = New Drawing.Font("Time New Roman", 12)

        'e.Graphics.DrawString(txtBarcode.Text, New Font("Time New Roman", 12, FontStyle.Regular), Brushes.Black, 650, 110)
        e.Graphics.DrawString(txtBarcode.Text, New Font("EAN-13", 28, FontStyle.Regular), Brushes.Black, 675, 1095)
    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load
        PrintPreviewDialog1.Document = PrintDocument1
    End Sub

    Private Sub btn_dl_Click(sender As Object, e As EventArgs) Handles btn_dl.Click
        download()
    End Sub
    Sub download()
        Try
            FileCopy(txtFilePath.Text, Application.StartupPath + "\Downloads\" + fileName)
            MsgBox("File Successfully Downloaded")
        Catch ex As Exception
            MsgBox(ex.ToString)
        End Try
    End Sub
End Class
