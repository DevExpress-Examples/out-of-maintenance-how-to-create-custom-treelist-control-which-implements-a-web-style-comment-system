using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList;
using System.Drawing;



namespace DevExpress.MyControl
{
    public class MyToolButtonPainter
    {
        public MyToolButtonPainter()
        {
        }



        public virtual void Draw(MyToolButtonDrawEventArgs e)
        {
            MyToolButtonViewInfo vi = e.ViewInfo;
            e.Appearence.FillRectangle(e.Cache, vi.Bounds);


            if (vi.Button.ButtonType == MyButtonType.Link)
            {                
                e.Cache.DrawImage(TestMyTreeListForum.Properties.Resources.CommentIcon, vi.ImageBounds);
                FontStyle fs = e.Appearence.Font.Style;
                if (vi.UnderCursor) fs |= FontStyle.Underline;
                using (Font f = new Font(e.Appearence.Font, fs))
                {             
                    e.Cache.DrawString(vi.Button.Caption, e.Appearence.GetFont(), e.Appearence.GetForeBrush(e.Cache), vi.CaptionBounds);
                }
                return;
            }

            Bitmap bm; 
            if (vi.Button.ButtonType == MyButtonType.Cancel)
                bm = (vi.UnderCursor ? TestMyTreeListForum.Properties.Resources.CancelButtonIconFocused 
                                     : TestMyTreeListForum.Properties.Resources.CancelButtonIconUnfocused);
            else
                bm = (vi.UnderCursor ? TestMyTreeListForum.Properties.Resources.CommitButtonIconFocused
                                     : TestMyTreeListForum.Properties.Resources.CommitButtonIconUnfocused);

            e.Cache.DrawImage(bm, vi.ImageBounds);
        }
    }
}
