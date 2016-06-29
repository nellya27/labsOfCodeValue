using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApp
{
    public class MultiDictionary<K, V> : IMultiDictionary<K, V>,IEnumerable<KeyValuePair<K,V>>
    {
       private Dictionary<K,LinkedList<V>> Dictionary=new Dictionary<K,LinkedList<V>>();

        public int Count
        {
            get
            {
               int itemTotal = 0;
               foreach(K key in Keys)
                {
                    itemTotal += Dictionary[key].Count;
                }

                return itemTotal + Dictionary.Count;
            }
        }

        public ICollection<K> Keys
        {
            get
            {
                return  Dictionary.Keys;
            }
        }

        public ICollection<V> Values
        {
            get
            {
             
               ICollection<V> valueCollection =new List<V>();
               foreach(K key in Keys)
                {
                    foreach(V value in Dictionary[key])
                    {
                        valueCollection.Add(value);
                    }                                                   
                }

                return valueCollection;             
            }
        }

        public void Add(K key, V value)
        {
          
            if(Dictionary.ContainsKey(key))
            {
                Dictionary[key].AddLast(value);
            }
            else
            {
                LinkedList<V> newLinkedList = new LinkedList<V>();
                newLinkedList.AddLast(value);
                Dictionary.Add(key, newLinkedList);
            }
        }

        public void Clear()
        {
            Dictionary.Clear();
        }

        public bool ContainKey(K key)
        {
            bool isContain = false;

            if (Dictionary.ContainsKey(key))
            {
                isContain = true;
            }
            else
                isContain = false;

            return isContain;
        }

        public bool Contains(K key, V value)
        {
            bool isContain = false;

            if (Dictionary.ContainsKey(key))
            {
                if (Dictionary[key].Contains(value))
                {
                    isContain = true;
                }
                else
                    isContain = false;
            }
            else
                isContain = false;

            return isContain;
        }

        public IEnumerator<KeyValuePair<K, V>> GetEnumerator()
        {
            foreach(K key in Keys)
            {
                foreach(V value in Dictionary[key])
                {
                    yield return new KeyValuePair<K, V>(key, value);
                }
            }
        }

        public bool Remove(K key)
        {
            bool isRemoved = false;

            if (Dictionary.Remove(key))
            {
                isRemoved = true;
            }
            else
                isRemoved = false;

            return isRemoved;
        }

        public bool Remove(K key, V value)
        {
            bool IsRemoved = false;

            if (Dictionary.ContainsKey(key))
            {
                if (Dictionary[key].Remove(value))
                {
                    IsRemoved = true;
                }
                else
                    IsRemoved = false;
            }
            else
                IsRemoved = false;

            return IsRemoved;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
           return GetEnumerator();
        }
    }
}
