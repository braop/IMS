Imports System.Data.OleDb
Public Class frmUpdateItem
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dr As OleDbDataReader

    Dim catid As String
    Dim productid As Integer

    Dim id As Integer
    Dim itemName As String
    Dim categoryname As String
    Dim user As Integer
    Private Sub frmUpdateItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()
        cmbCategoryType.Items.Clear()

        cmbCategoryType.Items.Clear()
        '---Populating Combobox---'
        con.Open()
        Dim strsql As String = "SELECT catname From category WHERE userId=" & user & ""
        cmd = New OleDbCommand(strsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            cmbCategoryType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()

        id = frmItem.productDataGridView.CurrentRow.Cells(0).Value.ToString
        itemName = frmItem.productDataGridView.CurrentRow.Cells(1).Value.ToString
        categoryname = frmItem.productDataGridView.CurrentRow.Cells(2).Value.ToString

        cmbCategoryType.SelectedItem = categoryname
        txtProduct.Text = itemName

    End Sub

    Private Sub btnUpdateItem_Click(sender As Object, e As EventArgs) Handles btnUpdateItem.Click
        con.Open()
        If String.IsNullOrEmpty(txtProduct.Text) Or String.IsNullOrEmpty(cmbCategoryType.Text) Then
            MessageBox.Show("Both Category and Product Name are Required!!!")
        Else
            Dim strSql As String
            Dim skusql As String = "SELECT id From category WHERE catname='" & cmbCategoryType.Text & "'"
            cmd = New OleDbCommand(skusql, con)

            dr = cmd.ExecuteReader
            While dr.Read
                catid = dr.GetValue(0)
            End While

            dr.Close()

            Try

                strSql = "UPDATE product SET productname='" & txtProduct.Text & "', category=" & catid & " WHERE id=" & id & ""

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    'MsgBox("Item Updated Successfully")
                    Dim sql As String = "SELECT id, productname From product WHERE userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    frmItem.productDataGridView.DataSource = t
                    Me.Close()

                Else

                    MsgBox(txtProduct.Text & " Cannot Be Updated!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()
    End Sub
End Class