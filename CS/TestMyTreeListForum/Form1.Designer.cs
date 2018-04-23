namespace TestMyTreeListForum
{
    partial class FormMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.myTreeList1 = new DevExpress.MyControl.MyTreeList();
            this.colFirstName = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colDescription = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.colAvatar = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.customersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.myDataDataSet = new TestMyTreeListForum.MyDataDataSet();
            this.customersTableAdapter = new TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // myTreeList1
            // 
            this.myTreeList1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.myTreeList1.AvatarCaptionFieldName = "";
            this.myTreeList1.AvatarImageFieldName = "";
            this.myTreeList1.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.colFirstName,
            this.colDescription,
            this.colAvatar});
            this.myTreeList1.DataSource = this.customersBindingSource;
            this.myTreeList1.Location = new System.Drawing.Point(12, 12);
            this.myTreeList1.Name = "myTreeList1";
            this.myTreeList1.OptionsView.AutoCalcPreviewLineCount = true;
            this.myTreeList1.OptionsView.ShowColumns = false;
            this.myTreeList1.OptionsView.ShowHorzLines = false;
            this.myTreeList1.OptionsView.ShowIndicator = false;
            this.myTreeList1.OptionsView.ShowPreview = true;
            this.myTreeList1.PreviewFieldName = "Value";
            this.myTreeList1.ShowButtonMode = DevExpress.XtraTreeList.ShowButtonModeEnum.ShowForFocusedRow;
            this.myTreeList1.Size = new System.Drawing.Size(561, 271);
            this.myTreeList1.TabIndex = 3;
            // 
            // colFirstName
            // 
            this.colFirstName.FieldName = "FirstName";
            this.colFirstName.MinWidth = 66;
            this.colFirstName.Name = "colFirstName";
            this.colFirstName.Visible = true;
            this.colFirstName.VisibleIndex = 0;
            this.colFirstName.Width = 133;
            // 
            // colDescription
            // 
            this.colDescription.FieldName = "Description";
            this.colDescription.Name = "colDescription";
            this.colDescription.Visible = true;
            this.colDescription.VisibleIndex = 1;
            this.colDescription.Width = 133;
            // 
            // colAvatar
            // 
            this.colAvatar.FieldName = "Avatar";
            this.colAvatar.Name = "colAvatar";
            this.colAvatar.Visible = true;
            this.colAvatar.VisibleIndex = 2;
            this.colAvatar.Width = 132;
            // 
            // customersBindingSource
            // 
            this.customersBindingSource.DataMember = "Customers";
            this.customersBindingSource.DataSource = this.myDataDataSet;
            // 
            // myDataDataSet
            // 
            this.myDataDataSet.DataSetName = "MyDataDataSet";
            this.myDataDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // customersTableAdapter
            // 
            this.customersTableAdapter.ClearBeforeFill = true;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(582, 295);
            this.Controls.Add(this.myTreeList1);
            this.Name = "FormMain";
            this.Text = "Main form";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.myTreeList1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.customersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.myDataDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.MyControl.MyTreeList myTreeList1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colFirstName;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colDescription;
        private DevExpress.XtraTreeList.Columns.TreeListColumn colAvatar;
        private MyDataDataSet myDataDataSet;
        private System.Windows.Forms.BindingSource customersBindingSource;
        private TestMyTreeListForum.MyDataDataSetTableAdapters.CustomersTableAdapter customersTableAdapter;
    }
}

