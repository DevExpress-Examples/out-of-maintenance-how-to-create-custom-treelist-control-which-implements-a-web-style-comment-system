using System;
using System.Collections.Generic;



namespace DevExpress.MyControl
{
    public class MyToolButtonCollection
    {
        private List<MyToolButton> buttonList;


        public MyToolButtonCollection()
        {
            buttonList = new List<MyToolButton>();
        }



        public int Count
        {
            get
            {
                return buttonList.Count;
            }
        }



        public void Add(MyToolButton btn)
        {
            if (btn == null || buttonList.Contains(btn)) return;
            buttonList.Add(btn);
        }



        public void Remove(MyToolButton btn)
        {
            if (btn == null) return;
            buttonList.Remove(btn);
        }



        public void RemoveAt(int index)
        {
            if (index > buttonList.Count - 1 || index < 0) return;

            buttonList.RemoveAt(index);
        }



        public MyToolButton this[int index]
        {
            get
            {
                return (index > buttonList.Count - 1 || index < 0 ? null : buttonList[index]);
            }
        }



        public void Clear()
        {
            buttonList.Clear();
        }
    }
}
