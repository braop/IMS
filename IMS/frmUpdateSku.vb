Imports System.Data.OleDb
Public Class frmUpdateSku
    Dim product As String
    Dim units As String
    Dim price As String
    Dim skuid As Integer

    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As System.Data.OleDb.OleDbDataAdapter

    Dim cmd As OleDbCommand

    Dim catid As String
    Dim productid As String
    Dim user As Integer

    Private Sub frmUpdateSku_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        cmbProductName.Items.Clear()

        skuid = frmSku.skuDataGridView.CurrentRow.Cells(0).Value.ToString
        product = frmSku.skuDataGridView.CurrentRow.Cells(1).Value.ToString
        units = frmSku.skuDataGridView.CurrentRow.Cells(2).Value.ToString
        price = frmSku.skuDataGridView.CurrentRow.Cells(3).Value.ToString

        cmbProductName.Items.Add(product)
        cmbProductName.SelectedItem = product
        txtPrice.Text = price
        txtUnits.Text = units

    End Sub

    Private Sub btnUpdateSku_Click(sender As Object, e As EventArgs) Handles btnUpdateSku.Click
        con.Open()

        Dim catsql As String = "SELECT id FROM product WHERE productname='" & cmbProductName.Text & "'"
        cmd = New OleDbCommand(catsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            productid = dr.GetValue(0)
        End While
        dr.Close()
        con.Close()


        con.Open()
        If String.IsNullOrEmpty(txtPrice.Text) Then
            MessageBox.Show("All fields Are Required!!!")
        Else

            Dim strSql As String
            Try

                strSql = "UPDATE sku SET units= '" & txtUnits.Text & "', price='" & txtPrice.Text & "' , product= " & productid & " WHERE id=" & skuid & ""

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
                    frmSku.skuDataGridView.DataSource = t

                    Me.Close()

                Else

                    MsgBox(txtUnits.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()
    End Sub
End Class