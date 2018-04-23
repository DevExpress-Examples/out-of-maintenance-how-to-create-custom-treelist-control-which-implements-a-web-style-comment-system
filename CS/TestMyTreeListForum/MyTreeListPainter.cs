using System;
using System.Collections.Generic;
using DevExpress.XtraTreeList.Painter;



namespace DevExpress.MyControl
{
    public class MyTreeListPainter : TreeListPainter
    {
        protected internal MyTreeListPainter() 
            :base()
        {	
		}



        public override ITreeListPaintHelper CreatePaintHelper()
        {
            return new MyTreeListPaintHelper();
        }
    }
}
