using System;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using DevExpress.XtraTreeList.ViewInfo;
using DevExpress.XtraTreeList.Painter;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraTreeList.Columns;



namespace DevExpress.MyControl
{
    public class MyTreeList : TreeList
    {
        private RepositoryItem defaultRepositoryItem;
        private string avatarCaptionFieldName;
        private string avatarImageFieldName;



        public MyTreeList()
            : base(null)
        {
            this.OptionsView.AutoCalcPreviewLineCount = true;
            this.OptionsView.ShowColumns = false;
            this.OptionsView.ShowPreview = true;
            this.OptionsView.ShowIndicator = false;
            this.OptionsView.ShowHorzLines = false;
            this.PreviewFieldName = "Value";
            this.defaultRepositoryItem = new RepositoryItemMemoEdit();
            this.avatarCaptionFieldName = string.Empty;
            this.avatarImageFieldName = string.Empty; 
        }



        public string AvatarCaptionFieldName
        {
            get
            {
                return avatarCaptionFieldName;
            }
            set
            {
            	if (avatarCaptionFieldName == value) return;
                if (value != string.Empty)
                {
                    TreeListColumn tlc = Columns[value];
                    if (tlc == null) throw new Exception("Invalid column name.");
                }

                avatarCaptionFieldName = value;
            }
        }



        public string AvatarImageFieldName
        {
            get
            {
                return avatarImageFieldName;
            }
            set
            {
                if (avatarImageFieldName == value) return;
                if (value != string.Empty)
                {
                    TreeListColumn tlc = Columns[value];
                    if (tlc == null) throw new Exception("Invalid column name.");
                }

                avatarImageFieldName = value;
            }
        }



        protected override TreeListNode CreateNode(int nodeID, TreeListNodes owner, object tag)
        {
            CreateCustomNodeEventArgs e = new CreateCustomNodeEventArgs(nodeID, owner, tag);
            RaiseCreateCustomNode(e);
            if (e.Node != null)
                return e.Node;
            return new MyTreeListNode(nodeID, owner);
        }



        protected override void RaiseGetPreviewText(TreeListNode node, ref string text)
        {
            text = " ";   
        }



        protected override TreeListViewInfo CreateViewInfo()
        {
            return new MyTreeListViewInfo(this);
        }



        protected override TreeListPainter CreatePainter()
        {
            return new MyTreeListPainter();
        }



        protected override RepositoryItem GetColumnEdit(TreeListColumn column)
        {          
            if (column.ColumnEdit != null) return column.ColumnEdit;
            return defaultRepositoryItem;
        }



        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);

            MyTreeListViewInfo vi = ViewInfo as MyTreeListViewInfo;
            if (vi.NodeWithFocusedPreview != null)
            {
                MyNodeAction n_action = vi.NodeWithFocusedPreview.MouseDownAction(e);
                switch (n_action)
                {
                    case MyNodeAction.Nothing:
                        {
                            return;
                            break;
                        }
                    case MyNodeAction.Add:
                        {
                            AddNewNode(vi.NodeWithFocusedPreview);
                            break;
                        }
                    case MyNodeAction.Remove:
                        {
                            DeleteNode(vi.NodeWithFocusedPreview);
                            vi.NodeWithFocusedPreview = null;
                            break;
                        }
                }
            }
        }



        internal void AddNewNode(MyTreeListNode parentNode)
        {
            TreeListNode node = null;
            try
            {
                node = AppendNode(null, parentNode);
            }
            catch
            {
            }

            if (node != null)
            {
                object[] values = new object[Data.Columns.Count];
                for (int i = 0; i < Data.Columns.Count; i++)
                {
                    if (Data.Columns[i].ColumnName == KeyFieldName)
                    {
                        if (ParentFieldName != string.Empty) node.SetValue(ParentFieldName, parentNode.GetValue(Data.Columns[i].ColumnName));
                        continue;
                    }

                    if (Data.Columns[i].ColumnName == AvatarCaptionFieldName ||
                        Data.Columns[i].ColumnName == AvatarImageFieldName)
                    {
                        node.SetValue(Data.Columns[i].ColumnName, parentNode.GetValue(Data.Columns[i].ColumnName));
                        continue;
                    }
                }

                node.Selected = true;
            }
        }



        public override void ShowEditor()
        {
            RowInfo ri = FocusedRow;
            if (ri != null)
            {
                MyTreeListNode node = ri.Node as MyTreeListNode;
                if (node != null)
                    if (node.IsPosted) return;
            }

            base.ShowEditor();
        }



        protected override void HideEditorCore(bool setFocus)
        {
            bool need_calc = ActiveEditor != null;
            base.HideEditorCore(setFocus);
            if (need_calc) ViewInfo.CalcRowsInfo();
        }
    }
}
