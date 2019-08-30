Imports System.Data.OleDb
Public Class frmOrder
    Dim price As String
    Dim qty As String

    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand

    Dim sku As Integer
    Dim skuexist As String
    Dim prdID As Integer
    Dim skuid As Integer

    Dim catid As String
    Dim productid As String

    Dim categoryID As Integer

    Dim quantity, user As Integer

    Dim stock As Integer = frmMain.salesDataGridView.CurrentRow.Cells(3).Value.ToString
    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub frmOrder_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()


        Dim itemname As String = frmMain.cmbProductName.Text
        skuid = frmMain.salesDataGridView.CurrentRow.Cells(0).Value.ToString
        Dim sku As String = frmMain.salesDataGridView.CurrentRow.Cells(2).Value.ToString
        price = frmMain.salesDataGridView.CurrentRow.Cells(3).Value.ToString
        Dim AvailableStock = frmMain.salesDataGridView.CurrentRow.Cells(4).Value.ToString
        lblAvailableStock.Text = AvailableStock
        txtItemName.Text = itemname
        txtSku.Text = sku
        txtItemPrice.Text = price
        lblTotal.Text = price


    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim newPrice As Integer
        qty = txtQty.Text + 1
        txtQty.Text = qty
        newPrice = price * qty
        lblTotal.Text = newPrice
    End Sub

    Private Sub btnSub_Click(sender As Object, e As EventArgs) Handles btnSub.Click
        If txtQty.Text.ToString > "1" Then
            Dim newPrice As Integer
            qty = txtQty.Text - 1
            txtQty.Text = qty
            newPrice = price * qty
            lblTotal.Text = newPrice
        End If


    End Sub

    Private Sub txtItemPrice_TextChanged(sender As Object, e As EventArgs) Handles txtItemPrice.TextChanged
        Dim newPrice As Integer
        newPrice = txtItemPrice.Text.ToString * txtQty.Text.ToString
        lblTotal.Text = newPrice
    End Sub

    Private Sub btnOrderOut_Click(sender As Object, e As EventArgs) Handles btnOrderOut.Click
        con.Open()
        Dim newqtty As Integer
        Dim availableStock As Integer = lblAvailableStock.Text
        Dim stockqtty As Integer = txtQty.Text
        newqtty = availableStock - stockqtty
        
        If (newqtty >= 0) Then
            If String.IsNullOrEmpty(txtItemName.Text) Or String.IsNullOrEmpty(txtItemPrice.Text.ToString) Then
                MessageBox.Show("No blank field is allowed!!!")
            Else

                Dim skusql As String = "SELECT sku.id, product.id From sku, product WHERE sku.units='" & txtSku.Text & "' AND product.productname='" & txtItemName.Text & "'"
                cmd = New OleDbCommand(skusql, con)
                dr = cmd.ExecuteReader
                While dr.Read
                    sku = dr.GetValue(0)
                    prdID = dr.GetValue(1)
                End While
                dr.Close()

                Try
                    Dim strSql As String = "INSERT into sales (sku, quantity, price, productid, saledate, userId) values( " & skuid & "," & txtQty.Text & "," & txtItemPrice.Text & "," & prdID & ", #" & salesDatePicker.Value.ToString("MM/dd/yyyy") & "#, " & user & ")"
                    Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)
                    Dim icount As Integer = cmd.ExecuteNonQuery
                    If icount > 0 Then
                        'Update stock
                        Dim stockupdateSql As String = "UPDATE stock SET quantity=" & newqtty & " WHERE skuid=" & skuid & " AND userId =" & user & ""
                        Dim cmd1 As OleDbCommand = New OleDbCommand(stockupdateSql, con)
                        Dim icount1 As Integer = cmd1.ExecuteNonQuery

                        ' Refresh Soldout datagrid
                        Dim sqlrefresh As String = "SELECT product.productname AS Item, sku.units AS Sku, sales.price AS Price, sales.quantity AS Qtty FROM product, sku, sales WHERE sales.productid=product.id AND sales.sku=sku.id AND sales.userId=" & user & " AND sales.saledate=#" & frmMain.soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
                        da = New System.Data.OleDb.OleDbDataAdapter(sqlrefresh, con)
                        Dim t1 As DataTable = New DataTable()
                        da.Fill(t1)
                        frmMain.soldOutDataGridView.DataSource = t1

                    Else
                        MessageBox.Show("Make sure there is a enough stock")
                        Me.Close()

                    End If
                    Me.Close()
                Catch ex1 As Exception
                    MsgBox(ex1.Message)
                End Try


            End If
        Else
            MessageBox.Show("You can sale more than what's in stock")
            txtQty.Text = "1"
        End If

        con.Close()

        con.Open()
        Dim productsql As String = "SELECT id From product WHERE productname='" & frmMain.cmbProductName.Text & "'"
        cmd = New OleDbCommand(productsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            productid = dr.GetValue(0)
        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim sql As String = "SELECT stock.skuid as ID,product.productname AS ITEM, sku.units AS SKU, sku.price AS PRICE, stock.quantity FROM product, sku, stock WHERE sku.product=" & productid & " AND product.id=" & productid & " AND stock.productid=" & productid & " AND stock.skuid= sku.id "
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        frmMain.salesDataGridView.DataSource = t
        con.Close()

        con.Open()
        Dim strsql1 As String = "SELECT SUM(price*quantity) From sales WHERE userId=" & user & " AND saledate=#" & frmMain.soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            frmMain.lblTotal.Text = dr.Item(0).ToString & " Ush"

        End While
        dr.Close()
        con.Close()
    End Sub

End Class