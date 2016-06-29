using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class Program
    {
        public static void Main()
        {
            MultiDictionary<int, string> multiDictionary = new MultiDictionary<int, string>();
            multiDictionary.Add(1, "one");
            multiDictionary.Add(2, "two");
            multiDictionary.Add(3, "three");
            multiDictionary.Add(1, "ich");
            multiDictionary.Add(2, "nee");
            multiDictionary.Add(3, "sun");

            foreach(KeyValuePair<int,string> item in multiDictionary)
            {
                Console.WriteLine("the key:{0}, the value: {1}", item.Key, item.Value);
            }

            Console.WriteLine("All the values in dictionary");
            foreach(string valueItem in multiDictionary.Values)
            {
                Console.WriteLine("{0},", valueItem);
            }
            Console.WriteLine("All the keys in the dictionary");

            foreach (int keyItem in multiDictionary.Keys)
            {
                Console.WriteLine("{0},", keyItem);
            }
            Console.WriteLine("the number of items in dictionary {0}", multiDictionary.Count);
            bool isRemoved = multiDictionary.Remove(1, "one");
            if(isRemoved)
            {
                Console.WriteLine("Dictionary after removal");
                foreach (KeyValuePair<int, string> item in multiDictionary)
                {
                    Console.WriteLine("the key:{0}, the value: {1}", item.Key, item.Value);
                }
            }
            else
            {
                Console.WriteLine("cant Remove this item");
            }

            bool isKeyRemoved = multiDictionary.Remove(1);
            if(isKeyRemoved)
            {
                Console.WriteLine("The dictionary after removal");
                foreach (KeyValuePair<int, string> item in multiDictionary)
                {
                    Console.WriteLine("the key:{0}, the value: {1}", item.Key, item.Value);
                }
            }
            else
            {
                Console.WriteLine("cant Remove this item ,its not exist");
            }

            bool isContainKey = multiDictionary.ContainKey(3);
            if(isContainKey)
            {
                Console.WriteLine("the dictionaty contains key");
            }
            else
            {
                Console.WriteLine("The key doesn't exist");
            }

            bool isContains = multiDictionary.Contains(3, null);
            if (isContains)
            {
                Console.WriteLine("The dictionary contains the value");
            }
            else
            {
                Console.WriteLine("No such value");
            }

            multiDictionary.Clear();

        }
    }
}
