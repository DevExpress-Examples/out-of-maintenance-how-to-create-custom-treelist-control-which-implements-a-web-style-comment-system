using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Painter;
using System.Drawing;



namespace DevExpress.MyControl
{
    public class MyTreeListPaintHelper : TreeListPaintHelper
    {
        public MyTreeListPaintHelper() 
            : base()
        {
		}
        public override void DrawNodePreview(CustomDrawNodePreviewEventArgs e)
        {
            MyTreeListNode node = e.Node as MyTreeListNode;
            e.Appearance.FillRectangle(e.Cache, e.Bounds);
            for (int i = 0; i < node.Buttons.Count; i++)
                node.Buttons[i].Painter.Draw(new MyToolButtonDrawEventArgs(e.Appearance, e.Graphics, node.Buttons[i].ViewInfo, e.Cache));
        }
        protected override void DrawNodeImageCore(CustomDrawNodeImagesEventArgs e, Rectangle bounds, Point location, object imageList, int imageIndex)
        {
            e.Appearance.FillRectangle(e.Cache, bounds);
            MyTreeListNode node = e.Node as MyTreeListNode;
            if (node == null) return;

            Image img = node.AvatarImage; 
            if (img != null) e.Cache.Paint.DrawImage(e.Graphics, img, node.AvatarImageBounds);
                
            else e.Cache.DrawRectangle(Pens.Gray, node.AvatarImageBounds);
            string caption = node.AvatarCaption;
            if (caption != string.Empty)
            {
                e.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
                e.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                e.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
                e.Appearance.DrawString(e.Cache, caption, node.AvatarCaptionBounds);
            }
        }
    }
}
