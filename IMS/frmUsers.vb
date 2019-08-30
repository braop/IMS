Imports System.Data.OleDb
Public Class frmUsers
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb.mdb;Persist Security Info=False;"
    '"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    'Dim conString2 As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|\imsdb2.mdb;Persist Security Info=False;"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    'Dim con2 As OleDbConnection = New OleDbConnection(conString2)
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dr As OleDbDataReader

    Dim catid As String
    Dim productid As Integer
    Dim user As Integer
    Dim shop As String
    Private Sub frmUsers_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim username As String
        username = frmMain.lblAdminType.Text
        lblAdmin.Text = username
        con.Open()
        Dim strsqlu As String = "SELECT id, password, shop From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
            txtPwd.Text = dr.Item(1).ToString
            txtName.Text = dr.Item(2).ToString
        End While
        dr.Close()
        con.Close()

    End Sub

    Private Sub btnUpdateUser_Click(sender As Object, e As EventArgs) Handles btnUpdateUser.Click
        con.Open()

        If String.IsNullOrEmpty(txtPwd.Text) Then
            MessageBox.Show("Category Name is Required")
        Else
            Dim strSql As String
            Try

                strSql = "UPDATE users SET shop='" & txtName.Text.ToString & "' WHERE id =" & user & ""

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then
                    MsgBox("Your user Information is now Updated", MsgBoxStyle.Exclamation, "Updated Successfully")
                    frmMain.lblShopName.Text = txtName.Text
                    Me.Close()
                Else

                    MsgBox("Cannot Be Update!!", MsgBoxStyle.Critical, "Failed Updated")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()

    End Sub
End Class