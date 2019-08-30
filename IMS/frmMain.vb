Imports System.Data.OleDb
Public Class frmMain
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
    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim username As String
        If (frmLogin.rBtnAdmin1.Checked = True) Then
            username = frmLogin.rBtnAdmin1.Text
            lblAdminType.Text = username
            lblShopName.BackColor = Color.Green
        Else
            username = frmLogin.rBtnAdmin2.Text
            lblAdminType.Text = username
            lblShopName.BackColor = Color.Blue
        End If

        cmbCategoryType.Items.Clear()
        '---Populating Combobox---'

        con.Open()
        Dim strsqlu As String = "SELECT id, shop From users WHERE username='" & lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
            lblShopName.Text = dr.Item(1).ToString
        End While
        dr.Close()
        con.Close()

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
        Try
            Dim sql As String = "SELECT product.productname AS Item, sku.units AS Sku, sales.price AS Price, sales.quantity AS Qtty FROM product, sku, sales WHERE sales.productid=product.id AND sales.sku=sku.id AND sales.userId=" & user & " AND sales.saledate=#" & soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
            da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
            Dim t As DataTable = New DataTable()
            da.Fill(t)
            soldOutDataGridView.DataSource = t
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        con.Close()

        con.Open()
        Dim strsql1 As String = "SELECT SUM(price*quantity) From sales WHERE userId=" & user & " AND saledate=#" & soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"

        End While
        dr.Close()
        con.Close()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        frmItem.ShowDialog()

    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs)

        frmLogin.Close()


    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        frmStats.ShowDialog()

    End Sub

    Private Sub btnSKU_Click(sender As Object, e As EventArgs) Handles btnSKU.Click
        frmSku.ShowDialog()

    End Sub

    Private Sub Button4_Click_1(sender As Object, e As EventArgs) Handles btnPurchase.Click
        frmPurchase.ShowDialog()

    End Sub

    Private Sub btnCat_Click(sender As Object, e As EventArgs) Handles btnCat.Click
        frmCategory.ShowDialog()
    End Sub

    Private Sub btnItem_Click(sender As Object, e As EventArgs) Handles btnItem.Click
        frmItem.ShowDialog()
    End Sub

    Private Sub btnProductStock_Click(sender As Object, e As EventArgs) Handles btnProductStock.Click
        frmPurchaseStock.ShowDialog()
    End Sub

    Private Sub cmbCategoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryType.SelectedIndexChanged
        '---Populating Combobox---'
        con.Open()
        Dim catsql As String = "SELECT id From category WHERE catname='" & cmbCategoryType.Text & "' AND userId=" & user & ""
        cmd = New OleDbCommand(catsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            catid = dr.GetValue(0)
        End While
        dr.Close()

        Try
            cmbProductName.Items.Clear()
            Dim strsql As String = "SELECT productname From product where category=" & catid & " AND userId=" & user & ""
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

    Private Sub salesDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles salesDataGridView.CellContentClick
        Dim sku As Integer
        Dim prdID As Integer
        Dim quantity As Integer
        con.Open()
        Dim skusql As String = "SELECT sku.id, product.id From sku, product WHERE sku.units='" & salesDataGridView.CurrentRow.Cells(1).Value.ToString & "' AND product.productname='" & cmbProductName.Text & "' AND sku.userId=product.userId"
        cmd = New OleDbCommand(skusql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            sku = dr.GetValue(0)
            prdID = dr.GetValue(1)
        End While
        dr.Close()
        con.Close()

        quantity = salesDataGridView.CurrentRow.Cells(3).Value
       
        If quantity <= 0 Then
            MsgBox("The selected has Zero(0) stock, Please make sure to add stock!!", MsgBoxStyle.Critical, "Warning, Out of stock")
        Else
            frmOrder.ShowDialog()
        End If

    End Sub

    Private Sub cmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductName.SelectedIndexChanged
        con.Open()
        Dim productsql As String = "SELECT id From product WHERE productname='" & cmbProductName.Text & "' AND userId=" & user & ""
        cmd = New OleDbCommand(productsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            productid = dr.GetValue(0)
        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim sql As String = "SELECT stock.skuid as ID, product.productname AS ITEM, sku.units AS SKU, sku.price AS PRICE, stock.quantity FROM product, sku, stock WHERE sku.product=" & productid & " AND product.id=" & productid & " AND stock.productid=" & productid & " AND stock.skuid= sku.id AND sku.userId=stock.userId"
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        salesDataGridView.DataSource = t
        con.Close()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs)
        frmLogin.Close()
    End Sub

    Private Sub btnClose_Click_2(sender As Object, e As EventArgs) Handles btnClose.Click
        frmLogin.Show()
        Me.Close()

    End Sub

 
    Private Sub btnStats_Click(sender As Object, e As EventArgs) Handles btnStats.Click
        frmStats.ShowDialog()
    End Sub

    Private Sub lblTotal_Click(sender As Object, e As EventArgs) Handles lblTotal.Click

    End Sub


    Private Sub btnPettyCash_Click(sender As Object, e As EventArgs) Handles btnPettyCash.Click
        frmPettyCash.ShowDialog()
    End Sub

 
    Private Sub btnUser_Click(sender As Object, e As EventArgs) Handles btnUser.Click
        frmUsers.ShowDialog()
    End Sub

    Private Sub soldoutDatePicker_ValueChanged(sender As Object, e As EventArgs) Handles soldoutDatePicker.ValueChanged

        con.Open()
        Try
            Dim sql As String = "SELECT product.productname AS Item, sku.units AS Sku, sales.price AS Price, sales.quantity AS Qtty FROM product, sku, sales WHERE sales.productid=product.id AND sales.sku=sku.id AND sales.userId=" & user & " AND sales.saledate=#" & soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
            da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
            Dim t As DataTable = New DataTable()
            da.Fill(t)
            soldOutDataGridView.DataSource = t
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
        con.Close()

        con.Open()
        Dim strsql1 As String = "SELECT SUM(price*quantity) From sales WHERE userId=" & user & " AND saledate=#" & soldoutDatePicker.Value.ToString("MM/dd/yyyy") & "#"
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"

        End While
        dr.Close()
        con.Close()
    End Sub
End Class