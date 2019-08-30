Imports System.Data.OleDb
Public Class frmRegisterActivity
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb.mdb;User ID=admin;Password=;"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim user As Integer

    Private Sub frmRegisterActivity_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim sql As String = "SELECT id AS ID, activityname AS Activity FROM activities WHERE userId=" & user & ""
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        activityDataGridView.DataSource = t
        con.Close()
    End Sub

    Private Sub btnRegisterActivity_Click(sender As Object, e As EventArgs) Handles btnRegisterActivity.Click
        con.Open()

        If String.IsNullOrEmpty(txtActivity.Text) Then
            MessageBox.Show("Activity Name is Required")
        Else
            Dim strSql As String

            Try

                strSql = "INSERT INTO activities (activityname, userId) VALUES ('" & txtActivity.Text & "'," & user & ")"

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    MsgBox(txtActivity.Text & " Activity Added Successfully")
                    txtActivity.Clear()

                    Dim sql As String = "SELECT id AS ID, activityname AS Activity FROM activities WHERE userId=" & user & " "
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    activityDataGridView.DataSource = t

                Else

                    MsgBox(txtActivity.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()

        frmPettyCash.cmbActivityType.Items.Clear()
        '---Populating Combobox---'
        con.Open()
        Dim strsql1 As String = "SELECT activityname From activities WHERE userId=" & user & " "
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            frmPettyCash.cmbActivityType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete? Please Note: All information about this Acitivity will be lost!!", "Warning Before Deleting", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            con.Open()
            Dim activityid As Integer
            Dim deleteSql As String
            Dim skusql As String = "SELECT id From activities WHERE activityname='" & activityDataGridView.CurrentRow.Cells(1).Value.ToString & "'"
            cmd = New OleDbCommand(skusql, con)
            dr = cmd.ExecuteReader
            While dr.Read
                activityid = dr.GetValue(0)
            End While

            dr.Close()

            Try

                deleteSql = "DELETE FROM activities WHERE id=" & activityid & ""
                Dim cmd As OleDbCommand = New OleDbCommand(deleteSql, con)
                Dim icount As Integer = cmd.ExecuteNonQuery
                If icount > 0 Then
                    Dim sql11 As String = "SELECT id AS ID, activityname AS ACTIVITY From activities WHERE userId=" & user & " "
                    da = New System.Data.OleDb.OleDbDataAdapter(sql11, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    activityDataGridView.DataSource = t

                Else

                    MsgBox("Cannot Be Deleted!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try

            con.Close()
        End If


        frmPettyCash.cmbActivityType.Items.Clear()
        '---Populating Combobox---'
        con.Open()
        Dim strsql1 As String = "SELECT activityname From activities WHERE userId=" & user & " "
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            frmPettyCash.cmbActivityType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()
    End Sub
End Class