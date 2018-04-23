Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DevExpress.XtraTreeList.Nodes
Imports DevExpress.XtraEditors
Imports DevExpress.XtraEditors.Repository
Imports DevExpress.MyControl



Namespace TestMyTreeListForum
    Partial Public Class FormMain
        Inherits Form

        Public Sub New()
            InitializeComponent()

            For i As Integer = 0 To myTreeList1.Columns.Count - 1
                myTreeList1.Columns(i).VisibleIndex = (If(i = 1, 0, -1))
            Next i

            myTreeList1.KeyFieldName = "ID"
            myTreeList1.ParentFieldName = "ParentID"
            myTreeList1.AvatarImageFieldName = "Avatar"
            myTreeList1.AvatarCaptionFieldName = "FirstName"
            myTreeList1.OptionsView.ShowIndentAsRowStyle = True
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
            Me.customersTableAdapter.Fill(Me.myDataDataSet.Customers)
        End Sub
    End Class
End Namespace