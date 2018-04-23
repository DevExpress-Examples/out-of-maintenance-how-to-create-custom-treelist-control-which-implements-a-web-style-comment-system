using System;
using System.Collections.Generic;
using System.Drawing;



namespace DevExpress.MyControl
{
    public class MyToolButtonViewInfo
    {
        private MyToolButton button;
        public MyToolButton Button
        {
            get
            {
                return button;
            }
        }



        public MyToolButtonViewInfo(MyToolButton button)
        {
            this.button = button;
            imageBounds = Rectangle.Empty;
            captionBounds = Rectangle.Empty;
            bounds = Rectangle.Empty;
        }




        private Rectangle imageBounds;
        public Rectangle ImageBounds
        {
            get
            {
                return imageBounds;
            }
        }



        private Rectangle captionBounds;
        public Rectangle CaptionBounds
        {
            get
            {
                return captionBounds;
            }
        }



        private Rectangle bounds;
        public Rectangle Bounds
        {
            get
            {
                return bounds;
            }
        }



        public void CalcBounds(Rectangle rect)
        {
            bounds = new Rectangle(rect.Location, rect.Size);
            if (button.ButtonType == MyButtonType.Link)
            {
                imageBounds = new Rectangle(new Point(bounds.X, bounds.Y + 2), new Size(10, 10));
                captionBounds = new Rectangle(imageBounds.Right + 2, bounds.Y, bounds.Right - imageBounds.Right, bounds.Height);
                return;
            }

            imageBounds = bounds;
        }



        private bool underCursor;
        public bool UnderCursor
        {
            get
            {
                return underCursor;
            }
            set
            {
                underCursor = value;
            }
        }
    }
}
