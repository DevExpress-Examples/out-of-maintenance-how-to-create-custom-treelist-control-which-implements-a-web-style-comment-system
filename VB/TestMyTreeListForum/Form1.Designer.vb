Imports DevExpress.XtraTreeList.Columns

<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormMain
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.MyTreeList1 = New TestMyTreeListForum.DevExpress.MyControl.MyTreeList
        Me.MyDataDataSet = New TestMyTreeListForum.MyDataDataSet
        Me.CustomersBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomersTableAdapter = New TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter
        Me.colFirstName = New TreeListColumn
        Me.colDescription = New TreeListColumn
        Me.colAvatar = New TreeListColumn
        CType(Me.MyTreeList1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MyDataDataSet, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MyTreeList1
        '
        Me.MyTreeList1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left) _
                    Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.MyTreeList1.AvatarCaptionFieldName = ""
        Me.MyTreeList1.AvatarImageFieldName = ""
        Me.MyTreeList1.Columns.AddRange(New TreeListColumn() {Me.colFirstName, Me.colDescription, Me.colAvatar})
        Me.MyTreeList1.DataSource = Me.CustomersBindingSource
        Me.MyTreeList1.Location = New System.Drawing.Point(12, 12)
        Me.MyTreeList1.Name = "MyTreeList1"
        Me.MyTreeList1.OptionsView.AutoCalcPreviewLineCount = True
        Me.MyTreeList1.OptionsView.ShowColumns = False
        Me.MyTreeList1.OptionsView.ShowHorzLines = False
        Me.MyTreeList1.OptionsView.ShowIndicator = False
        Me.MyTreeList1.OptionsView.ShowPreview = True
        Me.MyTreeList1.PreviewFieldName = "Value"
        Me.MyTreeList1.Size = New System.Drawing.Size(526, 346)
        Me.MyTreeList1.TabIndex = 0
        '
        'MyDataDataSet
        '
        Me.MyDataDataSet.DataSetName = "MyDataDataSet"
        Me.MyDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'CustomersBindingSource
        '
        Me.CustomersBindingSource.DataMember = "Customers"
        Me.CustomersBindingSource.DataSource = Me.MyDataDataSet
        '
        'CustomersTableAdapter
        '
        Me.CustomersTableAdapter.ClearBeforeFill = True
        '
        'colFirstName
        '
        Me.colFirstName.FieldName = "FirstName"
        Me.colFirstName.MinWidth = 66
        Me.colFirstName.Name = "colFirstName"
        Me.colFirstName.Visible = True
        Me.colFirstName.VisibleIndex = 0
        Me.colFirstName.Width = 175
        '
        'colDescription
        '
        Me.colDescription.FieldName = "Description"
        Me.colDescription.Name = "colDescription"
        Me.colDescription.Visible = True
        Me.colDescription.VisibleIndex = 1
        Me.colDescription.Width = 175
        '
        'colAvatar
        '
        Me.colAvatar.FieldName = "Avatar"
        Me.colAvatar.Name = "colAvatar"
        Me.colAvatar.Visible = True
        Me.colAvatar.VisibleIndex = 2
        Me.colAvatar.Width = 174
        '
        'FormMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(550, 370)
        Me.Controls.Add(Me.MyTreeList1)
        Me.Name = "FormMain"
        Me.Text = "Main form"
        CType(Me.MyTreeList1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MyDataDataSet, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomersBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents MyTreeList1 As TestMyTreeListForum.DevExpress.MyControl.MyTreeList
    Friend WithEvents MyDataDataSet As TestMyTreeListForum.MyDataDataSet
    Friend WithEvents CustomersBindingSource As System.Windows.Forms.BindingSource
    Friend WithEvents CustomersTableAdapter As TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter
    Friend WithEvents colFirstName As TreeListColumn
    Friend WithEvents colDescription As TreeListColumn
    Friend WithEvents colAvatar As TreeListColumn

End Class
