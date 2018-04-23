Namespace TestMyTreeListForum
    Partial Public Class FormMain
        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (components IsNot Nothing) Then
                components.Dispose()
            End If
            MyBase.Dispose(disposing)
        End Sub

        #Region "Windows Form Designer generated code"

        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Me.myTreeList1 = New DevExpress.MyControl.MyTreeList()
            Me.colFirstName = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.colDescription = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.colAvatar = New DevExpress.XtraTreeList.Columns.TreeListColumn()
            Me.customersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
            Me.myDataDataSet = New TestMyTreeListForum.MyDataDataSet()
            Me.customersTableAdapter = New TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter()
            CType(Me.myTreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(Me.myDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' myTreeList1
            ' 
            Me.myTreeList1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
            Me.myTreeList1.AvatarCaptionFieldName = ""
            Me.myTreeList1.AvatarImageFieldName = ""
            Me.myTreeList1.Columns.AddRange(New DevExpress.XtraTreeList.Columns.TreeListColumn() { Me.colFirstName, Me.colDescription, Me.colAvatar})
            Me.myTreeList1.DataSource = Me.customersBindingSource
            Me.myTreeList1.Location = New System.Drawing.Point(12, 12)
            Me.myTreeList1.Name = "myTreeList1"
            Me.myTreeList1.OptionsView.AutoCalcPreviewLineCount = True
            Me.myTreeList1.OptionsView.ShowColumns = False
            Me.myTreeList1.OptionsView.ShowHorzLines = False
            Me.myTreeList1.OptionsView.ShowIndicator = False
            Me.myTreeList1.OptionsView.ShowPreview = True
            Me.myTreeList1.PreviewFieldName = "Value"
            Me.myTreeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow
            Me.myTreeList1.Size = New System.Drawing.Size(561, 271)
            Me.myTreeList1.TabIndex = 3
            ' 
            ' colFirstName
            ' 
            Me.colFirstName.FieldName = "FirstName"
            Me.colFirstName.MinWidth = 66
            Me.colFirstName.Name = "colFirstName"
            Me.colFirstName.Visible = True
            Me.colFirstName.VisibleIndex = 0
            Me.colFirstName.Width = 133
            ' 
            ' colDescription
            ' 
            Me.colDescription.FieldName = "Description"
            Me.colDescription.Name = "colDescription"
            Me.colDescription.Visible = True
            Me.colDescription.VisibleIndex = 1
            Me.colDescription.Width = 133
            ' 
            ' colAvatar
            ' 
            Me.colAvatar.FieldName = "Avatar"
            Me.colAvatar.Name = "colAvatar"
            Me.colAvatar.Visible = True
            Me.colAvatar.VisibleIndex = 2
            Me.colAvatar.Width = 132
            ' 
            ' customersBindingSource
            ' 
            Me.customersBindingSource.DataMember = "Customers"
            Me.customersBindingSource.DataSource = Me.myDataDataSet
            ' 
            ' myDataDataSet
            ' 
            Me.myDataDataSet.DataSetName = "MyDataDataSet"
            Me.myDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
            ' 
            ' customersTableAdapter
            ' 
            Me.customersTableAdapter.ClearBeforeFill = True
            ' 
            ' FormMain
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(582, 295)
            Me.Controls.Add(Me.myTreeList1)
            Me.Name = "FormMain"
            Me.Text = "Main form"
            CType(Me.myTreeList1, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.customersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
            CType(Me.myDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

        #End Region

        Private myTreeList1 As DevExpress.MyControl.MyTreeList
        Private colFirstName As DevExpress.XtraTreeList.Columns.TreeListColumn
        Private colDescription As DevExpress.XtraTreeList.Columns.TreeListColumn
        Private colAvatar As DevExpress.XtraTreeList.Columns.TreeListColumn
        Private myDataDataSet As MyDataDataSet
        Private customersBindingSource As System.Windows.Forms.BindingSource
        Private customersTableAdapter As TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter
    End Class
End Namespace

