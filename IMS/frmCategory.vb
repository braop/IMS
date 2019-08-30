Imports System.Data.OleDb
Public Class frmCategory
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb.mdb;User ID=admin;Password=;"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim user As Integer


    Private Sub frmCategory_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim sql As String = "SELECT id AS ID, catname AS CATEGORY FROM category WHERE userId=" & user & ""
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        categoryDataGridView.DataSource = t
        con.Close()
    End Sub


    Private Sub btnSave_Click_1(sender As Object, e As EventArgs) Handles btnSave.Click
        con.Open()

        If String.IsNullOrEmpty(txtCategory.Text) Then
            MessageBox.Show("Category Name is Required")
        Else
            Dim strSql As String

            Try

                strSql = "INSERT INTO category (catname, userId) VALUES ('" & txtCategory.Text & "'," & user & ")"

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    MsgBox(txtCategory.Text & " Category Added Successfully")
                    txtCategory.Clear()

                    Dim sql As String = "SELECT id AS ID, catname AS CATEGORY FROM category WHERE userId=" & user & " "
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    categoryDataGridView.DataSource = t

                Else

                    MsgBox(txtCategory.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()

        frmMain.cmbCategoryType.Items.Clear()
        '---Populating Combobox---'
        con.Open()
        Dim strsql1 As String = "SELECT catname From category WHERE userId=" & user & " "
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            frmMain.cmbCategoryType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub categoryDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles categoryDataGridView.CellContentClick
        frmUpdateCategory.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdateCategory.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete? Please Note: All information about this Category will be lost!!", "Warning Before Deleting", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            con.Open()
            Dim categoryid As Integer
            Dim deleteSql As String
            Dim skusql As String = "SELECT id From category WHERE catname='" & categoryDataGridView.CurrentRow.Cells(1).Value.ToString & "'"
            cmd = New OleDbCommand(skusql, con)
            dr = cmd.ExecuteReader
            While dr.Read
                categoryid = dr.GetValue(0)
            End While

            dr.Close()

            Try

                deleteSql = "DELETE FROM category WHERE id=" & categoryid & ""
                Dim cmd As OleDbCommand = New OleDbCommand(deleteSql, con)
                Dim icount As Integer = cmd.ExecuteNonQuery
                If icount > 0 Then
                    'MsgBox("Item Updated Successfully")
                    Dim sql11 As String = "SELECT id AS ID, catname AS CATEGORY From category WHERE userId=" & user & " "
                    da = New System.Data.OleDb.OleDbDataAdapter(sql11, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    categoryDataGridView.DataSource = t
                    ' Me.Close()

                Else

                    MsgBox("Cannot Be Deleted!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try

            con.Close()
        End If
    End Sub
End Class