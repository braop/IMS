Imports System.Data.OleDb
Public Class frmStats
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim dr As OleDbDataReader
    Dim da As OleDbDataAdapter
    Dim cmd As OleDbCommand

    Dim productID As String

    Dim purchase As Integer
    Dim sold As Integer
    Dim remaining As Integer

    Dim categoryID, user As Integer
    Private Sub frmStats_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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
        Dim strsql As String = "SELECT SUM(cost) From purchase WHERE userId=" & user & ""
        cmd = New OleDbCommand(strsql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            purchase = dr.Item(0).ToString
            lblPurchase.Text = purchase.ToString & " Ush"

        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim stocksql As String = "SELECT SUM(sku.price*stock.quantity) FROM product, sku, stock WHERE stock.productid=product.id AND stock.skuid=sku.id AND stock.userId=" & user & ""
        '
        cmd = New OleDbCommand(stocksql, con)
        dr = cmd.ExecuteReader
        While dr.Read
            remaining = dr.Item(0)
            lblRemaining.Text = remaining.ToString & " Ush"

        End While
        dr.Close()
        con.Close()

        con.Open()
        Dim strsql1 As String = "SELECT SUM(price*quantity) From sales WHERE userId=" & user & ""
        cmd = New OleDbCommand(strsql1, con)
        dr = cmd.ExecuteReader
        While dr.Read
            sold = dr.Item(0)
            lblSold.Text = sold.ToString & " Ush"

        End While
        dr.Close()
        con.Close()
        Dim profits As Integer
        profits = (remaining + sold) - purchase
        'lblProfits.Text = profits
    End Sub

    Private Sub lblPurchase_Click(sender As Object, e As EventArgs) Handles lblPurchase.Click

    End Sub
End Class
