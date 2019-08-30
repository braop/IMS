Imports System.Data
Imports System.Data.OleDb
Imports Excel = Microsoft.Office.Interop.Excel
Public Class frmPurchaseStock
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand

    Dim productID As String

    Dim categoryID As Integer
    Dim user As Integer

   
    Private Sub frmPurchaseStock_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        con.Open()
        Dim strsqlu As String = "SELECT id From users WHERE username='" & frmMain.lblAdminType.Text & "' "
        cmd = New OleDbCommand(strsqlu, con)
        dr = cmd.ExecuteReader
        While dr.Read
            user = dr.Item(0).ToString
        End While
        dr.Close()
        con.Close()

        con.Open()
        Try
            Dim sql As String = "SELECT productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "# "
            da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
            Dim t As DataTable = New DataTable()
            da.Fill(t)
            purchaseDataGridView.DataSource = t
        Catch ex As Exception

        End Try
        con.Close()

        con.Open()
        Dim strsql As String = "SELECT SUM(cost) From purchase WHERE userId=" & user & " AND purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "# "
        cmd = New OleDbCommand(strsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"
        End While
        dr.Close()
        con.Close()

        'stock datagrid
        con.Open()
        Try
            Dim sql As String = "SELECT productname AS ITEM, units AS SKU, price AS PRICE, quantity AS STOCK FROM product, sku, stock WHERE stock.productid=product.id AND stock.skuid=sku.id AND stock.userId=" & user & ""
            da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
            Dim t As DataTable = New DataTable()
            da.Fill(t)
            stockDataGridView.DataSource = t
        Catch ex As Exception

        End Try
        con.Close()

        con.Open()
        Dim stocksql As String = "SELECT SUM(sku.price*stock.quantity) FROM product, sku, stock WHERE stock.productid=product.id and stock.skuid=sku.id AND stock.userId=" & user & ""
        '
        cmd = New OleDbCommand(stocksql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblStockTotal.Text = dr.Item(0).ToString & " Ush"

        End While
        dr.Close()
        con.Close()

    End Sub

    Private Sub searchDatepicker_ValueChanged(sender As Object, e As EventArgs) Handles searchDatepicker.ValueChanged
        con.Open()
        Dim sql As String = "SELECT productname AS ITEM, units AS SKU, cost AS COST, quantity AS QUANTITY, purchase_date AS DATES FROM product, sku, purchase WHERE purchase.productid=product.id AND purchase.sku=sku.id AND purchase.userId=" & user & " AND purchase.purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "#  ORDER BY purchase_date"
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        purchaseDataGridView.DataSource = t
        con.Close()

        con.Open()
        Dim strsqlxx As String = "SELECT SUM(cost) From purchase WHERE userId=" & user & " AND purchase_date=#" & searchDatepicker.Value.ToString("MM/dd/yyyy") & "# "
        cmd = New OleDbCommand(strsqlxx, con)
        dr = cmd.ExecuteReader
        While dr.Read
            lblTotal.Text = dr.Item(0).ToString & " Ush"

        End While
        dr.Close()
        con.Close()
    End Sub


    Private Sub btnExportPurchas_Click(sender As Object, e As EventArgs) Handles btnExportPurchas.Click
        'Excel
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Try
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            '--- define Worksheet format
            xlApp.StandardFontSize = "12"
            xlWorkSheet.Columns.HorizontalAlignment = Excel.Constants.xlLeft

            con.Open()
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

            con.Close()

            MsgBox("The selected Purchse Report has been Saved Successfuly", MsgBoxStyle.Information, "Stock Report saved Successfully")
            Process.Start("D:\Reports\Purchase_Report.xlsx")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
    '-- procedure to release objects
    Private Sub releaseObject(ByVal obj As Object)
        Try
            While (System.Runtime.InteropServices.Marshal.ReleaseComObject(obj) > 0)
                obj = Nothing
            End While
        Catch ex As Exception
        Finally
            obj = Nothing
            GC.Collect()
        End Try

    End Sub

    Private Sub btnStockExel_Click(sender As Object, e As EventArgs) Handles btnStockExel.Click
        'Excel
        Dim xlApp As New Excel.Application
        Dim xlWorkBook As Excel.Workbook
        Dim xlWorkSheet As Excel.Worksheet
        Dim misValue As Object = System.Reflection.Missing.Value
        Try
            xlWorkBook = xlApp.Workbooks.Add(misValue)
            xlWorkSheet = xlWorkBook.Sheets("Sheet1")

            '--- define Worksheet format
            xlApp.StandardFontSize = "12"
            xlWorkSheet.Columns.HorizontalAlignment = Excel.Constants.xlLeft
            con.Open()
            Dim sql As String = "SELECT productname AS ITEM, units AS SKU, price AS PRICE, quantity AS STOCK FROM product, sku, stock WHERE stock.productid=product.id AND stock.skuid=sku.id AND stock.userId=" & user & ""
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
            xlWorkBook.SaveAs("D:\Reports\Stock_Report.xlsx")
            xlWorkBook.Close()
            xlApp.Quit()

            '--- release the objects
            releaseObject(xlApp)
            releaseObject(xlWorkBook)
            releaseObject(xlWorkSheet)
            releaseObject(misValue)

            con.Close()

            MsgBox("The selected Stock Report has been Saved Successfuly", MsgBoxStyle.Information, "Stock Report saved Successfully")
            Process.Start("D:\Reports\Stock_Report.xlsx")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try

    End Sub
End Class