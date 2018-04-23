using System;
using System.Collections.Generic;
using System.Drawing;



namespace DevExpress.MyControl
{
    public class MyToolButtonDrawEventArgs
    {
        private DevExpress.Utils.AppearanceObject appearance;
        private Graphics graphics;
        private MyToolButtonViewInfo viewInfo;
        private DevExpress.Utils.Drawing.GraphicsCache cache;



        public MyToolButtonDrawEventArgs(DevExpress.Utils.AppearanceObject appearance,
                                         Graphics graphics,
                                         MyToolButtonViewInfo viewInfo,
                                         DevExpress.Utils.Drawing.GraphicsCache cache)
        {
            this.appearance = appearance;
            this.graphics = graphics;
            this.viewInfo = viewInfo;
            this.cache = cache;
        }



        public DevExpress.Utils.AppearanceObject Appearence
        {
            get
            {
                return appearance;
            }
        }



        public Graphics Graphics
        {
            get
            {
                return graphics;
            }
        }



        public MyToolButtonViewInfo ViewInfo
        {
            get
            {
                return viewInfo;
            }
        }



        public DevExpress.Utils.Drawing.GraphicsCache Cache
        {
            get
            {
                return cache;
            }
        }
    }
}
