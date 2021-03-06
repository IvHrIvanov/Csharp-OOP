using System;
using System.Collections.Generic;
using System.Text;

namespace _08.CollectionHierarchy
{
    public class AddCollection : IAddCollection
    {
        private Stack<string> data;

        public AddCollection()
        {
            data = new Stack<string>();
        }
        public void Add(string input)
        {
            data.Push(input);
        }
        public override string ToString()
        {
            List<int> output = new List<int>();
            for (int i = 0; i < data.Count; i++)
            {
                output.Add(i);
            }
            return $"{string.Join(" ", output)}";
        }
    }
}
