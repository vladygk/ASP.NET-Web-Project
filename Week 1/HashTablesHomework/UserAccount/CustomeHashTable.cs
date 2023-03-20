using System;


namespace ClassTasks
{
    public class CustomeHashTable<T1, T2>
    {
        static LinkedList<KeyValuePair<T1, T2>>[] table;
         const int initialSize = 100;
        const int hashMagicNumber = 33;

        public CustomeHashTable()
        {
            Count = 0;
            table = new LinkedList<KeyValuePair<T1, T2>>[initialSize];
            for (int i = 0;i< initialSize; i++)
            {
                table[i] = new LinkedList<KeyValuePair<T1, T2>>();
            }
        }

        private static int Hash(T1 key)
        {
            return key.ToString().Length* hashMagicNumber % table.Length;
        }

        private static double LoadFactor()
        {
            return table.Where(x => x != default).Count() / table.Length;
        }

        private static void Resize()
        {
            var newTable = new LinkedList<KeyValuePair<T1, T2>>[table.Length * 2];

            for (int i = 0; i < table.Length * 2; i++)
            {
                newTable[i] = new LinkedList<KeyValuePair<T1, T2>>();
            }
            for (int i = 0; i < table.Length; i++)
            {
                newTable[i] = table[i];
            }
            table = newTable;
        }

        public int Count { get; set; }
        public void Insert(T1 key, T2 value)
        {
            if (LoadFactor() > 0.8)
            {
                Resize();
            }
            int hashedIndex = Hash(key);
           
            table[hashedIndex].AddLast(new KeyValuePair<T1, T2>(key, value));
            Count++;
        }

        public KeyValuePair<T1, T2> Find(T1 key)
        {
            int index = Hash(key);
            KeyValuePair<T1, T2> value;
            try
            {
                value = table[index].First(x => x.Key.Equals(key));

            }
            catch
            {
                return new KeyValuePair<T1, T2>();
            }


            return value;
        }

        public T2 FindValue(T1 key)
        {
            int index = Hash(key);
            KeyValuePair<T1, T2> value;
            try
            {
                value = table[index].First(x => x.Key.Equals(key));

            }
            catch
            {
                return default(T2);
            }


            return value.Value;
        }
        public T2 this[T1 key]
        {
            get =>FindValue(key);
        }

        public bool Delete(T1 key)
        {
            KeyValuePair<T1, T2> toRemove = Find(key);

            if (toRemove.Key.Equals(default(T1)))
            {
                return false;

            }


            int index = Hash(key);
            table[index].Remove(toRemove);
            Count--;
            return true;

        }
    }
}
