Imports System.Data.OleDb
Public Class frmLogin
    Dim conString As String
    Dim con As OleDbConnection
    Dim cmd As OleDbCommand
    Dim dr As OleDbDataReader
    Dim count As Integer

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        'select where password is
        If String.IsNullOrEmpty(txtPwd.Text) Then
            MsgBox("Password cant be blank", MsgBoxStyle.Exclamation, "Warning")
        Else
            'Connecting to Database 
            conString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb.mdb;Persist Security Info=False;"
            '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
            con = New OleDbConnection(conString)

            con.Open()
            If rBtnAdmin1.Checked = True Then
                Dim strsql1 As String = "SELECT COUNT(id) FROM users WHERE username='Admin 1' AND password= '" & txtPwd.Text & "' "
                cmd = New OleDbCommand(strsql1, con)
            Else
                Dim strsql1 As String = "SELECT COUNT(id) FROM users WHERE username='Admin 2' AND password= '" & txtPwd.Text & "' "
                cmd = New OleDbCommand(strsql1, con)
            End If

            dr = cmd.ExecuteReader
            While dr.Read
                count = dr.Item(0).ToString
            End While
            dr.Close()
            con.Close()

            If count = 1 Then
                Dim password As String
                password = txtPwd.Text
                txtPwd.Clear()
                Me.Hide()
                frmMain.Show()
            Else
                passwordcheckLabel.Text = "Password Mismatch, Please try again!!"
            End If
        End If

    End Sub

    Private Sub frmLogin_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

End Class
