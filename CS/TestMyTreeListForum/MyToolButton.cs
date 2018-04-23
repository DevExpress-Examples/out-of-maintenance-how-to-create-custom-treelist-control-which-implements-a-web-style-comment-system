using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;



namespace DevExpress.MyControl
{
    public enum MyButtonType {Link, Cancel, Commit};


    public class MyToolButton
    {
        private string COMMENTcaption = "Comment";
        private MyButtonType buttonType;
        private MyToolButtonViewInfo viewInfo;
        private MyToolButtonPainter painter;
        private int width;
        private int height;



        public MyToolButton(MyButtonType btnType)
        {
            buttonType = btnType;
            if (buttonType == MyButtonType.Link)
            {
                width = 60;
                height = 13;
            }
            else width = height = 10;

            viewInfo = CreateViewInfo();
            painter = CreatePainter();
        }



        public MyButtonType ButtonType
        {
            get
            {
                return buttonType;
            }
        }



        public string Caption
        {
            get
            {
                return (buttonType == MyButtonType.Link ? COMMENTcaption : string.Empty);
            }
        }



        public MyToolButtonViewInfo ViewInfo
        {
            get
            {
                return viewInfo;
            }
        }



        public MyToolButtonPainter Painter
        {
            get
            {
                return painter;
            }
        }



        public int Width
        {
            get
            {
                return width;
            }
        }



        public int Height
        {
            get
            {
                return height;
            }
        }



        protected virtual MyToolButtonViewInfo CreateViewInfo()
        {
            return new MyToolButtonViewInfo(this);
        }



        protected virtual MyToolButtonPainter CreatePainter()
        {
            return new MyToolButtonPainter();
        }
    }
}
