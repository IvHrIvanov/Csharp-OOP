using System;
using System.Linq;

namespace _08.CollectionHierarchy
{
    public class Program
    {
        static void Main(string[] args)
        {
            IMyList myList = new MyList();
            IAddCollection addColection = new AddCollection();
            IAddRemoveCollection addRemoveColcetion = new AddRemoveCollection();
            string[] input = Console.ReadLine().Split();
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < input.Length; i++)
            {
                string current = input[i];
                myList.Add(current);
                addColection.Add(current);
                addRemoveColcetion.Add(current);
            }
            Console.WriteLine(addColection.ToString());
            Console.WriteLine(addRemoveColcetion.ToString());
            Console.WriteLine(myList.ToString());

           
            Console.WriteLine(addRemoveColcetion.Remove(n));
            Console.WriteLine(myList.Remove(n));


        }
    }
}
