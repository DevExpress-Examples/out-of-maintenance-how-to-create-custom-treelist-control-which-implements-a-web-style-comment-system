using System;
using System.Windows.Forms;
using System.Collections.Generic;
using DevExpress.XtraTreeList.Nodes;
using System.Drawing;
using DevExpress.XtraEditors.Controls;




namespace DevExpress.MyControl
{
    public enum MyNodeAction {Nothing, Add, Remove};



    public class MyTreeListNode : TreeListNode
    {
        private MyToolButtonCollection buttons;
        private const int INTERVALbutton = 3;
        private MyToolButton focusedButton;
        private Size avatarSize;
        private const int AVATARCaptionWidth = 46;



        protected internal MyTreeListNode(int id, TreeListNodes owner)
            : base(id, owner)
        {
            isPosted = false;
            buttons = CreateButtonCollection();
            UpdateButtons();
            SelectImageIndex = 0;
            avatarSize = new Size(20, 25);
            avatarImageBounds = Rectangle.Empty;
            avatarCaptionBounds = Rectangle.Empty;
        }



        private Rectangle avatarImageBounds;
        public Rectangle AvatarImageBounds 
        {
            get
            {
                return avatarImageBounds;
            }
        }



        private Rectangle avatarCaptionBounds;
        public Rectangle AvatarCaptionBounds
        {
            get
            {
                return avatarCaptionBounds;
            }
        }



        private bool isPosted;
        internal bool IsPosted
        {
            get
            {
                return isPosted;
            }
            set
            {
                if (isPosted == value) return;
                isPosted = value;
                UpdateButtons();
                TreeList.LayoutChanged();
            }
        }



        public MyToolButtonCollection Buttons
        {
            get
            {
                return buttons;
            }
        }



        protected virtual MyToolButtonCollection CreateButtonCollection()
        {
            return new MyToolButtonCollection();
        }



        protected virtual void UpdateButtons()
        {
            focusedButton = null;
            Buttons.Clear();
            if (!IsPosted)
            {
                Buttons.Add(new MyToolButton(MyButtonType.Cancel));
                Buttons.Add(new MyToolButton(MyButtonType.Commit));
            }
            else Buttons.Add(new MyToolButton(MyButtonType.Link));           
        }



        public int Interval
        {
            get
            {
                return INTERVALbutton;
            }
        }



        public virtual void HitTest(Point pt)
        {
            if (focusedButton != null)
            {
                if (focusedButton.ViewInfo.Bounds.Contains(pt)) return;  
                focusedButton.ViewInfo.UnderCursor = false;
                InvalidateButton(focusedButton);
                focusedButton = null;
            }


            MyToolButton btn;
            for (int i = 0; i < Buttons.Count; i++)
            {
                btn = Buttons[i];
                if (btn.ViewInfo.Bounds.Contains(pt))
                {
                    btn.ViewInfo.UnderCursor = true;
                    focusedButton = btn;
                    InvalidateButton(focusedButton);
                    break;
                }
            }
        }



        protected virtual void InvalidateButton(MyToolButton btn)
        {
            TreeList.Invalidate(btn.ViewInfo.Bounds);
        }



        internal MyNodeAction MouseDownAction(MouseEventArgs e)
        {
            MyNodeAction res = MyNodeAction.Nothing;
            if (e.Button != MouseButtons.Left || focusedButton == null) return res;

            switch (focusedButton.ButtonType)
            {
                case MyButtonType.Link:
                    {
                        res = MyNodeAction.Add;
                        break;
                    }
                case MyButtonType.Cancel:
                    {
                        res = MyNodeAction.Remove;
                        break;
                    }
                case MyButtonType.Commit:
                    {
                        IsPosted = true;
                        res = MyNodeAction.Nothing;
                        break;
                    }

            }
            
            return res;
        }



        internal void CalcAvatarBounds(Rectangle rect)
        {
            avatarImageBounds = new Rectangle(new Point((rect.Width - avatarSize.Width) / 2 + rect.X, rect.Y + 2), avatarSize);
            avatarCaptionBounds = new Rectangle(new Point((rect.Width - AVATARCaptionWidth) / 2 + rect.X, avatarImageBounds.Bottom + 2), new Size(AVATARCaptionWidth, rect.Bottom - avatarImageBounds.Bottom));
        }



        public string AvatarCaption
        {
            get
            {
                MyTreeList mtl = TreeList as MyTreeList;
                if (mtl.AvatarCaptionFieldName == string.Empty) return string.Empty;
                return GetValue(TreeList.Columns[mtl.AvatarCaptionFieldName].AbsoluteIndex) as string;
            }
        }



        public Image AvatarImage
        {
            get
            {
                return GetImage();
            }
        }



        protected virtual Image GetImage()
        {
            Image img = null;
            MyTreeList mtl = TreeList as MyTreeList;
            if (mtl.AvatarImageFieldName == string.Empty) return img;

            try
            {
                DevExpress.XtraTreeList.Columns.TreeListColumn col = TreeList.Columns[mtl.AvatarImageFieldName];
                byte[] buffer = (byte[])GetValue(TreeList.Columns.IndexOf(col));
                img = ByteImageConverter.FromByteArray(buffer);
            }
            catch
            {
                img = null;
            }

            return img;
        }
    }
}
