Imports System.Data.OleDb
Public Class frmUpdateCategory
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter
    Dim categoryname As String
    Dim catid As Integer
    Dim cmd As OleDbCommand
    Dim user As Integer
    Private Sub frmUpdateCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        catid = frmCategory.categoryDataGridView.CurrentRow.Cells(0).Value.ToString
        categoryname = frmCategory.categoryDataGridView.CurrentRow.Cells(1).Value.ToString
        txtCategory.Text = categoryname

        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub btnUpdateCategory_Click(sender As Object, e As EventArgs) Handles btnUpdateCategory.Click
        con.Open()

        If String.IsNullOrEmpty(txtCategory.Text) Then
            MessageBox.Show("Category Name is Required")
        Else
            Dim strSql As String

            Try

                strSql = "UPDATE category SET catname='" & txtCategory.Text & "' WHERE id =" & catid & ""

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    'MsgBox(txtCategory.Text & " Category Added Successfully")
                    Dim sql As String = "SELECT id AS ID, catname AS CATEGORY FROM category WHERE userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    frmCategory.categoryDataGridView.DataSource = t


                    frmMain.cmbCategoryType.Items.Clear()
                    '---Populating Combobox---'

                    Dim strsql1 As String = "SELECT catname From category WHERE userId=" & user & ""
                    cmd = New OleDbCommand(strsql1, con)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        frmMain.cmbCategoryType.Items.Add(dr.Item(0).ToString)
                    End While
                    dr.Close()

                    Me.Close()
                Else

                    MsgBox(txtCategory.Text & " Cannot Be Update!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()
    End Sub
End Class