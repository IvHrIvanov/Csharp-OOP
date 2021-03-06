using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class MyList : IMyList
    {
        private List<string> data;
        public MyList()
        {
            
            data = new List<string>();
        }

        public int Used { get { return data.Count; } }
        public void Add(string add)
        {
            data.Insert(0, add);
        }

        public string Remove(int n)
        {
            List<string> removePrint = new List<string>();
            for (int i = 0; i < n; i++)
            {
                removePrint.Add(data[0]);
                data.RemoveAt(0);
            }
            return $"{string.Join(" ",removePrint)}";
        }
        public override string ToString()
        {
            List<int> output = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                output.Add(0);
            }
            return $"{string.Join(" ",output)}";
        }

    }
}
