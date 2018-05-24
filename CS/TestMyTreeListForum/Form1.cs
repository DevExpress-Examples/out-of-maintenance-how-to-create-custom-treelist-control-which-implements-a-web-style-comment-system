using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.MyControl;



namespace TestMyTreeListForum
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            for (int i = 0; i < myTreeList1.Columns.Count; i++)
                myTreeList1.Columns[i].VisibleIndex = (i == 1 ? 0 : -1);

            myTreeList1.KeyFieldName = "ID";
            myTreeList1.ParentFieldName = "ParentID";
            myTreeList1.AvatarImageFieldName = "Avatar";
            myTreeList1.AvatarCaptionFieldName = "FirstName";
            myTreeList1.OptionsView.ShowIndentAsRowStyle = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.myDataDataSet.Customers);
        }
    }
}