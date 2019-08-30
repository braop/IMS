Imports System.Data.OleDb
Public Class frmItem
    Dim conString As String = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=imsdb.mdb"
    Dim con As OleDbConnection = New OleDbConnection(conString)
    Dim cmd As OleDbCommand
    Dim da As OleDbDataAdapter
    Dim dr As OleDbDataReader

    Dim id As Integer

    Dim catid As String
    Dim user As Integer

    Private Sub frmItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load
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

        con.Open()
        Dim sql As String = "SELECT product.id As ID, product.productname AS ITEM, category.catname AS CATEGORY From product, category WHERE product.category=category.id and product.userId=" & user & ""
        da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
        Dim t As DataTable = New DataTable()
        da.Fill(t)
        productDataGridView.DataSource = t
        con.Close()

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

    End Sub

    Private Sub btnAddProduct_Click_1(sender As Object, e As EventArgs) Handles btnAddProduct.Click
        con.Open()

        If String.IsNullOrEmpty(txtProduct.Text) Or String.IsNullOrEmpty(cmbCategoryType.Text) Then
            MessageBox.Show("Both Category and Product Name are Required!!!")
        Else
            Dim strSql As String
            Dim skusql As String = "SELECT id From category WHERE catname='" & cmbCategoryType.Text & "' AND userId=" & user & ""
            cmd = New OleDbCommand(skusql, con)

            dr = cmd.ExecuteReader
            While dr.Read
                catid = dr.GetValue(0)
            End While

            dr.Close()

            Try

                strSql = "insert into product (productname, category, userId) values('" & txtProduct.Text & "', " & catid & ", " & user & ")"

                Dim cmd As OleDbCommand = New OleDbCommand(strSql, con)

                Dim icount As Integer = cmd.ExecuteNonQuery

                If icount > 0 Then

                    'MsgBox(txtProduct.Text & " Product Added Successfully")
                    txtProduct.Clear()

                    Dim sql As String = "SELECT product.id As ID, product.productname AS ITEM, category.catname AS CATEGORY From product, category WHERE product.category=category.id and product.userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    productDataGridView.DataSource = t

                Else

                    MsgBox(txtProduct.Text & " Cannot Be Added!!")

                End If

            Catch ex1 As Exception
                MsgBox(ex1.Message)
            End Try


        End If
        con.Close()
    End Sub

    Private Sub productDataGridView_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles productDataGridView.CellContentClick
        frmUpdateItem.ShowDialog()
    End Sub


    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click
        frmUpdateItem.ShowDialog()
    End Sub

   
    Private Sub btnDelete_Click(sender As Object, e As EventArgs) Handles btnDelete.Click
        Dim result As Integer = MessageBox.Show("Are you sure you want to delete? Please Note: All information about this Item will be lost!!", "Warning Before Deleting", MessageBoxButtons.YesNo)
        If result = DialogResult.Yes Then
            con.Open()
            Dim productid As Integer
            Dim deleteSql As String
            Dim skusql As String = "SELECT id From product WHERE productname='" & productDataGridView.CurrentRow.Cells(1).Value.ToString & "'"
            cmd = New OleDbCommand(skusql, con)
            dr = cmd.ExecuteReader
            While dr.Read
                productid = dr.GetValue(0)
            End While

            dr.Close()

            Try

                deleteSql = "DELETE FROM product WHERE id=" & productid & ""
                Dim cmd As OleDbCommand = New OleDbCommand(deleteSql, con)
                Dim icount As Integer = cmd.ExecuteNonQuery
                If icount > 0 Then
                    'MsgBox("Item Updated Successfully")
                    Dim sql11 As String = "SELECT id AS ID, productname AS ITEM From product WHERE userId=" & user & ""
                    da = New System.Data.OleDb.OleDbDataAdapter(sql11, con)
                    Dim t As DataTable = New DataTable()
                    da.Fill(t)
                    productDataGridView.DataSource = t
                    ' Me.Close()

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