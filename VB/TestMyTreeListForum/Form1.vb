Public Class FormMain
    Public Sub New()
        InitializeComponent()

        For i As Integer = 0 To myTreeList1.Columns.Count - 1
            If i = 1 Then
                myTreeList1.Columns(i).VisibleIndex = (0)
            Else
                myTreeList1.Columns(i).VisibleIndex = (-1)
            End If
        Next i

        myTreeList1.KeyFieldName = "ID"
        myTreeList1.ParentFieldName = "ParentID"
        myTreeList1.AvatarImageFieldName = "Avatar"
        myTreeList1.AvatarCaptionFieldName = "FirstName"
    End Sub



    Private Sub FormMain_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'TODO: This line of code loads data into the 'MyDataDataSet.Customers' table. You can move, or remove it, as needed.
        Me.CustomersTableAdapter.Fill(Me.MyDataDataSet.Customers)

    End Sub
End Class
