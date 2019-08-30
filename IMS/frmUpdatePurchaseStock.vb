Imports System.Data.OleDb
Public Class frmUpdatePurchaseStock
    Dim itemName As String
    Dim skuName As String
    Dim qtty As Integer
    Dim cost As String
    Dim purchaseId As Integer

    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand

    Dim skuexist As String
    Dim prdID As String

    Dim catid As String
    Dim productid As String

    Dim categoryID As Integer

    Dim quantity As Integer
    Dim stockquantityDelete As Integer
    Dim user As Integer

    Dim stockid As Integer

    Private Sub frmUpdatePurchaseStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        itemName = frmPurchase.purchaseDataGridView.CurrentRow.Cells(1).Value.ToString()
        skuName = frmPurchase.purchaseDataGridView.CurrentRow.Cells(2).Value.ToString()
        cost = frmPurchase.purchaseDataGridView.CurrentRow.Cells(3).Value.ToString()
        qtty = frmPurchase.purchaseDataGridView.CurrentRow.Cells(4).Value.ToString()

        cmbProductName.Items.Add(itemName)
        cmbProductName.SelectedItem = itemName
        cmbSku.Items.Add(skuName)
        cmbSku.SelectedItem = skuName
        txtQty.Text = qtty
        txtTotalAmount.Text = cost

    End Sub

    Private Sub btnAddPurchase_Click(sender As Object, e As EventArgs) Handles btnAddPurchase.Click
        con.Open()
        purchaseId = frmPurchase.purchaseDataGridView.CurrentRow.Cells(0).Value.ToString()
        Dim sku As Integer
        If String.IsNullOrEmpty(Me.cmbSku.Text) Or String.IsNullOrEmpty(Me.cmbProductName.Text) Then
            MessageBox.Show("Product Name is Required!!!")
        Else
            Dim cmda As OleDbCommand
            Dim skusql As String = "SELECT sku.id, product.id From sku, product WHERE sku.units='" & cmbSku.Text & "' AND product.productname='" & cmbProductName.Text & "'"
            cmda = New OleDbCommand(skusql, con)
            dr = cmda.ExecuteReader
            While dr.Read
                sku = dr.GetValue(0)
                prdID = dr.GetValue(1)
            End While
            dr.Close()

            Try

                Dim strSql As String = "UPDATE purchase SET quantity='" & txtQty.Text & "', cost='" & txtTotalAmount.Text & "' WHERE id=" & purchaseId & ""

                Dim cmdb As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmdb.ExecuteNonQuery

                If icount > 0 Then
                    Dim skustock As String = "SELECT COUNT(skuid) From stock WHERE skuid=" & sku & ""
                    cmd = New OleDbCommand(skustock, con)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        skuexist = dr.GetValue(0)
                    End While
                    dr.Close()
                    If skuexist > 0 Then

                        Dim stockquantitySql As String = "SELECT quantity From stock WHERE skuid=" & sku & ""
                        cmd = New OleDbCommand(stockquantitySql, con)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            quantity = dr.GetValue(0)

                        End While
                        dr.Close()

                        Dim newqtty As Integer
                        Dim stockqtty As Integer = txtQty.Text
                        newqtty = quantity - frmPurchase.purchaseDataGridView.CurrentRow.Cells(4).Value + txtQty.Text
                        Dim stockupdateSql As String = "UPDATE stock SET quantity=" & newqtty & " WHERE skuid=" & sku & ""
                        Dim cmd1 As OleDbCommand = New OleDbCommand(stockupdateSql, con)
                        Dim icount1 As Integer = cmd1.ExecuteNonQuery
                        If icount1 > 0 Then

                        End If
                    End If

                    'display purchases
                    Dim sql As String = "SELECT purchase.id AS ID, productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " ORDER BY purchase_date"
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    frmPurchase.purchaseDataGridView.DataSource = t

                    txtQty.Clear()
                    txtTotalAmount.Clear()

                Else

                    MsgBox(cmbProductName.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try

        End If
        cmbSku.Refresh()
        cmbProductName.Refresh()
        cmbProductName.Items.Clear()
        cmbSku.Items.Clear()

        txtQty.Clear()
        txtTotalAmount.Clear()
        
        con.Close()
        Me.Close()
        
    End Sub
End Class