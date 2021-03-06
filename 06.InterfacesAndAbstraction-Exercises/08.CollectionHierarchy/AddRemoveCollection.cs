using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddRemoveCollection : IAddRemoveCollection
    {
        private List<string> data;
        public AddRemoveCollection()
        {
            data = new List<string>();
        }
        public void Add(string add)
        {
            data.Insert(0, add);
        }

        public string Remove(int n)
        {
            List<string> remove = new List<string>();
            for (int i = 0; i < n; i++)
            {

                remove.Add(data[data.Count-1]);
                data.RemoveAt(data.Count - 1);
            }
            return $"{string.Join(" ", remove)}";
        }

        public override string ToString()
        {
            List<int> output = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                output.Add(0);
            }
            return $"{string.Join(" ", output)}";
        }

    }
}
