Imports System.Data.OleDb
Public Class frmPettyCash
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb.mdb;User ID=admin;Password=;"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter
    Dim cmd As OleDbCommand
    Dim user As Integer
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        frmRegisterActivity.ShowDialog()
    End Sub

    Private Sub frmPettyCash_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        cmbActivityType.Items.Clear()
        '---Populating Combobox---'
        con.Open()
        Dim strsql1 As String = "SELECT activityname From activities WHERE userId=" & user & " "
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            cmbActivityType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim sql2 As String = "SELECT cashout.id AS ID, activities.activityName AS Activity, cashout.amount AS Amount, cashdate AS DATE_ FROM cashout, activities WHERE cashout.activity=activities.id AND cashout.userId=" & user & "AND cashout.cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "#"
        da = New System.Data.OleDb.OleDbDataAdapter(sql2, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        pettyDataGridView.DataSource = t
        con.Close()

        con.Open()
        Dim strsqlx As String = "SELECT SUM(amount) From cashout WHERE userId=" & user & " AND cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "# "
        cmd = New OleDbCommand(strsqlx, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"
        End While
        dr.Close()
        con.Close()
    End Sub

  
    Private Sub btnRegisterCash_Click(sender As Object, e As EventArgs) Handles btnRegisterCash.Click
        Dim activityId As Integer
        con.Open()
        Dim strsql1 As String = "SELECT id From activities WHERE userId=" & user & " and activityname='" & cmbActivityType.Text & "'"
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            activityId = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        con.Open()

        If String.IsNullOrEmpty(cmbActivityType.Text) And String.IsNullOrEmpty(txtPrice.Text) Then
            MessageBox.Show("Activity Name is Required")
        Else
            Dim strSql As String
            Try

                strSql = "INSERT INTO cashout (activity, amount, userId, cashdate) VALUES (" & activityId & ", " & txtPrice.Text & "," & user & ", #" & datePickerPetty.Value.ToString("MM/dd/yyyy") & "#)"

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    MsgBox(" Activity Added Successfully")
                    Dim sql As String = "SELECT cashout.id AS ID, activities.activityName AS Activity, cashout.amount AS Amount, cashdate AS DATE_ FROM cashout, activities WHERE cashout.activity=activities.id AND cashout.userId=" & user & "AND cashout.cashdate=#" & datePickerPetty.Value.ToString("MM/dd/yyyy") & "#"
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    pettyDataGridView.DataSource = t

                Else

                    MsgBox("Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()

        con.Open()
        Dim strsqlas As String = "SELECT SUM(amount) From cashout WHERE userId=" & user & " AND cashdate=#" & datePickerPetty.Value.ToString("MM/dd/yyyy") & "# "
        cmd = New OleDbCommand(strsqlas, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub dateTimeCash_ValueChanged(sender As Object, e As EventArgs) Handles dateTimeCash.ValueChanged
        con.Open()
        Dim sqlx As String = "SELECT cashout.id AS ID, activities.activityName AS Activity, cashout.amount AS Amount, cashdate AS DATE_ FROM cashout, activities WHERE cashout.activity=activities.id AND cashout.userId=" & user & "AND cashout.cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "#"
        da = New System.Data.OleDb.OleDbDataAdapter(sqlx, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        pettyDataGridView.DataSource = t
        con.Close()

        con.Open()
        Dim strsql As String = "SELECT SUM(amount) From cashout WHERE userId=" & user & " AND cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "# "
        cmd = New OleDbCommand(strsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"
        End While
        dr.Close()
        con.Close()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete? Please Note: All information about this Activity will be lost!!", "Warning Before Deleting", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            con.Open()
            Dim deleteSql As String
            Try

                deleteSql = "DELETE FROM cashout WHERE id=" & pettyDataGridView.CurrentRow.Cells(0).Value.ToString & ""
                Dim cmd As OleDbCommand = New OleDbCommand(deleteSql, con)
                Dim icount As Integer = cmd.ExecuteNonQuery
                If icount > 0 Then
                    'MsgBox("Item Updated Successfully")
                    Dim sql11 As String = "SELECT cashout.id AS ID, activities.activityName AS Activity, cashout.amount AS Amount, cashdate AS DATE_ FROM cashout, activities WHERE cashout.activity=activities.id AND cashout.userId=" & user & "AND cashout.cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "#"
                    da = New System.Data.OleDb.OleDbDataAdapter(sql11, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    pettyDataGridView.DataSource = t


                    Dim strsqlxx As String = "SELECT SUM(amount) From cashout WHERE userId=" & user & " AND cashdate=#" & dateTimeCash.Value.ToString("MM/dd/yyyy") & "# "
                    cmd = New OleDbCommand(strsqlxx, con)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        lblTotal.Text = dr.Item(0).ToString & " Ush"
                    End While
                    dr.Close()


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