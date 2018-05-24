using System;
using System.Drawing;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.ViewInfo;



namespace DevExpress.MyControl
{
    public class MyTreeListViewInfo : TreeListViewInfo
    {
        private const int MINRowHeight = 36;
        private MyTreeListNode nodeWithFocusedPreview;
        private const int minAvatarCaptionHeight = 10;
        internal MyTreeListNode NodeWithFocusedPreview
        {
            get 
            {
                return nodeWithFocusedPreview;
            }
            set
            {
                if (nodeWithFocusedPreview == value) return;
                nodeWithFocusedPreview = value;
            }
        }





        public MyTreeListViewInfo(MyTreeList treeList)
            : base(treeList)
        {
            nodeWithFocusedPreview = null;
		}


        public override int RowHeight 
        { 
            get 
            {
                return RC.RowHeight < MINRowHeight ? MINRowHeight : RC.RowHeight;
            } 
        }



        protected override void CalcRowPreviewInfo(RowInfo ri)
        {
            base.CalcRowPreviewInfo(ri);

            bool graphic_is_created = (GInfo.Graphics != null);
            if (!graphic_is_created) GInfo.AddGraphics(null);        
            try
            {
                CalcPreviewElementBounds(ri);
            }
            finally
            {
                if (!graphic_is_created) GInfo.ReleaseGraphics();
            }
        }



        protected virtual void CalcPreviewElementBounds(RowInfo ri)
        {
            MyTreeListNode node = ri.Node as MyTreeListNode;

            if (!node.IsPosted)
            {
                int posX = ri.PreviewBounds.Right - 20, posY = ri.PreviewBounds.Y + 2;

                for (int i = node.Buttons.Count - 1; i >= 0; i--)
                {
                    node.Buttons[i].ViewInfo.CalcBounds(new Rectangle(posX, posY, node.Buttons[i].Width, node.Buttons[i].Height));
                    posX -= (node.Interval + node.Buttons[i].Width);
                }
            }
            else
            {
                if (node.Buttons.Count > 0) node.Buttons[0].ViewInfo.CalcBounds(new Rectangle(ri.PreviewBounds.X + 2, ri.PreviewBounds.Y, node.Buttons[0].Width, node.Buttons[0].Height));
            }
        }




        public override TreeListHitTest GetHitTest(Point pt)
        {
            TreeListHitTest ht = base.GetHitTest(pt);
            
            if (ht.HitInfoType == HitInfoType.RowPreview)
            {
                MyTreeListNode node = ht.Node as MyTreeListNode;
                node.HitTest(pt);
                nodeWithFocusedPreview = node;
            }
            else
            {
                if (nodeWithFocusedPreview != null)
                {
                    nodeWithFocusedPreview.HitTest(pt);
                    nodeWithFocusedPreview = null;
                }
            }

            return ht;
        }




        public override void CreateResources()
        {
            bool need_adjustImageSize = RC.NeedsRestore;
            base.CreateResources();
            if (need_adjustImageSize) RC.SelectImageSize.Width = 50;
        }

        protected override void CalcSelectImageBounds(RowInfo rInfo, Rectangle indentBounds) {
            base.CalcSelectImageBounds(rInfo, indentBounds);
            MyTreeListNode node = rInfo.Node as MyTreeListNode;
            if (node == null) return;
            Rectangle rect = rInfo.SelectImageBounds;
            rect.Height += minAvatarCaptionHeight;
            rInfo.SelectImageBounds = rect;
            node.CalcAvatarBounds(rInfo.SelectImageBounds);
           
        }

        //protected override void CalcSelectImage(RowInfo ri)
        //{
        //    base.CalcSelectImage(ri);
        //    MyTreeListNode node = ri.Node as MyTreeListNode;
        //    if (node == null) return;
        //    node.CalcAvatarBounds(ri.SelectImageBounds);
           
        //}
    }
}
