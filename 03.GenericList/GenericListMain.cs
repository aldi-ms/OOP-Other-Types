using System;
using _04.VersionAttribute;

namespace _03.GenericList
{
    public class GenericListMain
    {
        public static void Main()
        {
            Type type = typeof(GenericList<>);
            object[] attr = type.GetCustomAttributes(false);

            foreach (var ver in attr)
            {
                if (ver.GetType() == typeof(VersionAttribute))
                {
                    Console.WriteLine("GeneriList v{0}\n",
                        (ver as VersionAttribute).Build);
                }
            }

            GenericList<int> numList = new GenericList<int>();
            
            numList.Add(23, 77, -1);
            Console.WriteLine("Create a list and add to it 3 elements:\n{0}", numList);

            numList.Add(3, 4, 123, 0, -12, 31, -245, 125, 64, -122, 11, 77, 50, 4123, -517, 7, 12, 666);
            Console.WriteLine("Add to the list another 18 elements (resizes list):\n{0}", numList);

            numList.Remove(2);
            Console.WriteLine("Remove the element at index 2:\n{0}", numList);

            numList.Insert(2, 777);
            Console.WriteLine("Add element at index 2:\n{0}", numList);

            numList.Remove(numList.Count);
            Console.WriteLine("Remove the last element:\n{0}", numList);

            numList.Insert(numList.Count, 44);
            Console.WriteLine("Insert element at last position:\n{0}", numList);

            Console.WriteLine("Search for \"11\" in the list (-1 if not found): index {0}", numList.Find(11));

            Console.WriteLine("Max element in the list: {0}", numList.Max());
            Console.WriteLine("Min element in the list {0}", numList.Min());

            Console.ReadKey();
        }
    }
}
