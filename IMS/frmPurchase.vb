Imports System.Data
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmPurchase
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
    Dim user As Integer

    Private Sub frmPurchase_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        'Getting count if purchase is already initialised in the database

        con.Open()
        Dim sql As String = "SELECT purchase.id AS ID, productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase.purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "#  ORDER BY purchase_date"
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        purchaseDataGridView.DataSource = t
        con.Close()

        '---Populating Categoryname ---'

        Try
            con.Open()
            Dim strsqlcategory As String = "SELECT catname From category WHERE userId=" & user & ""
            cmd = New OleDbCommand(strsqlcategory, con)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbCategoryType.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()

        Catch ex As Exception
            MsgBox("First Add Category!!")
        End Try
        con.Close()




    End Sub

    Private Sub cmbCategoryType_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbCategoryType.SelectedIndexChanged

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

    Private Sub cmbProductName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProductName.SelectedIndexChanged
        'Popluate SKU table based on selected Product

        '---Populating Combobox---'
        con.Open()
        Dim cmd1 As OleDbCommand
        Dim catsql As String = "SELECT id From product WHERE productname='" & cmbProductName.Text & "'"
        cmd1 = New OleDbCommand(catsql, con)
        dr = cmd1.ExecuteReader
        While dr.Read
            productid = dr.GetValue(0)
        End While
        dr.Close()

        Try
            cmbSku.Items.Clear()
            Dim strsql As String = "SELECT units FROM sku WHERE product=" & productid & ""
            cmd = New OleDbCommand(strsql, con)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbSku.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
        End Try

        con.Close()
    End Sub

    Private Sub btnAddPurchase_Click(sender As Object, e As EventArgs) Handles btnAddPurchase.Click
        Dim sku As Integer
        con.Open()

        If String.IsNullOrEmpty(Me.cmbSku.Text) Or String.IsNullOrEmpty(Me.cmbProductName.Text) Or String.IsNullOrEmpty(Me.cmbCategoryType.Text) Then
            MessageBox.Show("Product Name is Required!!!")
        Else
            Dim cmdaaa As OleDbCommand
            Dim skusqlaaa As String = "SELECT id From product WHERE productname='" & cmbProductName.Text & "' AND userId=" & user & ""
            cmdaaa = New OleDbCommand(skusqlaaa, con)
            dr = cmdaaa.ExecuteReader
            While dr.Read
                prdID = dr.GetValue(0)
            End While
            dr.Close()
            'MsgBox(prdID)

            Dim cmda As OleDbCommand
            Dim skusql As String = "SELECT sku.id, sku.product From sku WHERE sku.units='" & cmbSku.Text & "' AND sku.product=" & prdID & ""
            cmda = New OleDbCommand(skusql, con)
            dr = cmda.ExecuteReader
            While dr.Read
                sku = dr.GetValue(0)
            End While
            dr.Close()
            'MsgBox(sku)
            Try

                Dim strSql As String = "INSERT INTO purchase (sku, quantity, cost, purchase_date, productid, userId) VALUES( " & sku & ",'" & txtQty.Text & "','" & txtTotalAmount.Text & "', #" & datePickerPurchase.Value.ToString("MM/dd/yyyy") & "#, " & prdID & ", " & user & ")"

                Dim cmdb As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmdb.ExecuteNonQuery

                If icount > 0 Then

                    MsgBox(cmbProductName.Text & " Purchase Added Successfully")

                    'check if it exists in stock or not


                    Dim skustock As String = "SELECT COUNT(skuid) FROM stock WHERE skuid=" & sku & ""
                    cmd = New OleDbCommand(skustock, con)
                    dr = cmd.ExecuteReader
                    While dr.Read
                        skuexist = dr.GetValue(0)
                    End While
                    dr.Close()

                    'if stock exists: Update stock
                    If skuexist > 0 Then
                        Dim stockquantitySql As String = "SELECT quantity FROM stock WHERE skuid=" & sku & ""
                        cmd = New OleDbCommand(stockquantitySql, con)
                        dr = cmd.ExecuteReader
                        While dr.Read
                            quantity = dr.GetValue(0)

                        End While
                        dr.Close()

                        Dim newqtty As Integer
                        Dim stockqtty As Integer = txtQty.Text
                        newqtty = quantity + stockqtty
                        Dim stockupdateSql As String = "UPDATE stock SET quantity=" & newqtty & ", stock_update= #" & datePickerPurchase.Value.ToString("MM/dd/yyyy") & "# WHERE skuid=" & sku & ""
                        Dim cmd1 As OleDbCommand = New OleDbCommand(stockupdateSql, con)
                        Dim icount1 As Integer = cmd1.ExecuteNonQuery
                        If icount1 > 0 Then
                        End If

                    Else

                        Dim stockinsertSql As String = "insert into stock (skuid, quantity, stock_update, productid, userId) values( " & sku & ",'" & txtQty.Text & "',  #" & datePickerPurchase.Value.ToString("MM/dd/yyyy") & "#, " & prdID & ", " & user & ")"
                        Dim cmd1 As OleDbCommand = New OleDbCommand(stockinsertSql, con)
                        Dim icount1 As Integer = cmd1.ExecuteNonQuery
                        If icount1 > 0 Then

                        End If
                    End If


                    'display purchases
                    Dim sqlc As String = "SELECT purchase.id AS ID, productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase.purchase_date=#" & datePickerPurchase.Value.ToString("MM/dd/yyyy") & "#  ORDER BY purchase_date"
                    da = New System.Data.OleDb.OleDbDataAdapter(sqlc, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    purchaseDataGridView.DataSource = t

                    txtQty.Clear()
                    txtTotalAmount.Clear()

                Else

                    MsgBox(cmbProductName.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        cmbCategoryType.Refresh()
        cmbSku.Refresh()
        cmbProductName.Refresh()
        cmbProductName.Items.Clear()
        cmbCategoryType.Items.Clear()
        cmbSku.Items.Clear()

        txtQty.Clear()
        txtTotalAmount.Clear()
        con.Close()
        Try
            con.Open()
            Dim strsqlcategory As String = "SELECT catname From category WHERE userId=" & user & ""
            cmd = New OleDbCommand(strsqlcategory, con)
            dr = cmd.ExecuteReader
            While dr.Read
                cmbCategoryType.Items.Add(dr.Item(0).ToString)
            End While
            dr.Close()
        Catch ex As Exception
        End Try
        con.Close()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdatePurchaseStock.ShowDialog()
    End Sub

    Private Sub purchaseDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles purchaseDataGridView.CellContentClick
        frmUpdatePurchaseStock.ShowDialog()
    End Sub

    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        MessageBox.Show("To delete a purchase set quantity and cost to zero")
    End Sub

    Private Sub searchDatepicker_ValueChanged(sender As Object, e As EventArgs) Handles searchDatepicker.ValueChanged
        con.Open()
        Dim sql As String = "SELECT purchase.id AS ID, productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase.purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "#  ORDER BY purchase_date"
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        purchaseDataGridView.DataSource = t
        con.Close()
    End Sub

    Private Sub btnExportPurchas_Click(sender As Object, e As EventArgs) Handles btnExportPurchas.Click
        'Excel
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        con.Open()
        Try
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            '--- define Worksheet format
            xlApp.StandardFontSize = "12"
            xlWorkSheet.Columns.HorizontalAlignment = Excel.Constants.xlLeft


            Dim sql As String = "SELECT productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase.purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "#  ORDER BY purchase_date"
            da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
            Dim t As DataTable = New DataTable()
            Dim ds As New DataSet
            da.Fill(ds)
            Dim i, j As Integer

            For i = 0 To ds.Tables(0).Rows.Count - 1
                For j = 0 To ds.Tables(0).Columns.Count - 1
                    xlWorkSheet.Cells(i + 1, j + 1) = ds.Tables(0).Rows(i).Item(j)
                Next
            Next
            xlWorkBook.SaveAs("D:\Reports\Purchase_Report.xlsx")
            xlWorkBook.Close()
            xlApp.Quit()

            '--- release the objects
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(misValue)

            MsgBox("The selected Purchse Report has been Saved Successfuly", MsgBoxStyle.Information, "Stock Report saved Successfully")
            Process.Start("D:\Reports\Purchase_Report.xlsx")
        Catch ex As Exception
            MessageBox.Show(ex.Message)

        End Try

        con.Close()
    End Sub

    '-- procedure to release objects
    Private Sub releaseObject(ByVal obj As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0)
                obj = Nothing
            End While
        Catch ex As Exception
            obj = Nothing
        Finally
            GC.Collect()
        End Try

    End Sub
End Class