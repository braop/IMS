Imports System.Data.OleDb
Public Class frmSku

    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter

    Dim cmd As OleDbCommand

    Dim catid As String
    Dim productid As String
    Dim user As Integer

    Private Sub frmSku_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim strsql As String = "SELECT catname From category WHERE userId=" & user & " "
        cmd = New OleDbCommand(strsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            cmbCategoryType.Items.Add(dr.Item(0).ToString)
        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim sql As String = "SELECT sku.id AS ID, product.productname AS ITEM, sku.units AS SKU, sku.price AS PRICE from product, sku where product.id=sku.product AND sku.userId=" & user & " "
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        skuDataGridView.DataSource = t
        con.Close()

    End Sub

    Private Sub cmbCategoryType_SelectedIndexChanged_1(sender As Object, e As EventArgs) Handles cmbCategoryType.SelectedIndexChanged
        '---Populating Combobox---'
        con.Open()

        Dim catsql As String = "SELECT id From category WHERE catname='" & cmbCategoryType.Text & "'"
        cmd = New OleDbCommand(catsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            catid = dr.GetValue(0)
        End While
        dr.Close()

        Try
            cmbProductName.Items.Clear()
            Dim strsql As String = "SELECT productname From product where category=" & catid & ""
            cmd = New OleDbCommand(strsql, con)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbProductName.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
        End Try

        con.Close()
    End Sub

    Private Sub btnRegisterSku_Click(sender As Object, e As EventArgs) Handles btnRegisterSku.Click
        con.Open()

        Dim catsql As String = "SELECT id From product WHERE productname='" & cmbProductName.Text & "'"
        cmd = New OleDbCommand(catsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            productid = dr.GetValue(0)
        End While
        dr.Close()
        con.Close()


        con.Open()
        If String.IsNullOrEmpty(txtPrice.Text) Then
            MessageBox.Show("Price Name is Required!!!")
        Else

            Dim strSql As String
            Try

                strSql = "insert into sku (units, price, product, userId) values('" & txtUnits.Text & "','" & txtPrice.Text & "'," & productid & "," & user & ")"

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    MsgBox(txtUnits.Text & " Product Added Successfully")
                    txtUnits.Clear()
                    txtPrice.Clear()

                    Dim sql As String = "SELECT sku.id AS ID, product.productname AS ITEM, sku.units AS SKU, sku.price AS PRICE from product, sku where product.id=sku.product AND sku.userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    skuDataGridView.DataSource = t

                Else

                    MsgBox(txtUnits.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()
    End Sub

    Private Sub skuDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles skuDataGridView.CellContentClick
        frmUpdateSku.ShowDialog()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdateSku.ShowDialog()
    End Sub


    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete? Please Note: All information about this SKU will be lost!!", "Warning Before Deleting", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            con.Open()
            'Dim skuid As Integer
            Dim deleteSql As String

            Try

                deleteSql = "DELETE FROM sku WHERE id=" & skuDataGridView.CurrentRow.Cells(0).Value.ToString & ""
                Dim cmd As OleDbCommand = New OleDbCommand(deleteSql, con)
                Dim icount As Integer = cmd.ExecuteNonQuery
                If icount > 0 Then
                    Dim sql11 As String = "SELECT sku.id AS ID, product.productname AS ITEM, sku.units AS SKU, sku.price AS PRICE from product, sku where product.id=sku.product AND sku.userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql11, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    skuDataGridView.DataSource = t

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