namespace HashTablesHomework
{
    public class HashTableFunctions
    {
        public static List<string> GetCoolestCarAndTheownersWithMoreThanOneCar(out string coolestCar)
        {
            string coolPlateNumber = "777777";
            Dictionary<string, string> carplateOwner = new Dictionary<string, string>()
            {
                { "333456","Pencho" },
                {"111111","Pesho" },
                {"222222","Ivan" },
                {"777777","Ivan"}
            };

             coolestCar =carplateOwner[coolPlateNumber]; 
           
              var result = new HashSet<string>( carplateOwner.Values
                .Where(owner => (carplateOwner.Values.Count(x=>x==owner) > 1))).ToList();

            return result;
        }

        public static int[] FindIntersectionOfTwoArrays(int[] arrA, int[] arrB)
        {
            var hashSet1 = new HashSet<int>(arrA);
            var hashSet2 = new HashSet<int>(arrB);

            return hashSet1.Intersect(hashSet2).ToArray();
        }

        public static List<char> FindUniqueChars(string input, out int indexFirstUnique)
        {
            Dictionary<char, int> charDict = new Dictionary<char, int>();

            foreach(char c in input)
            {
                if (!charDict.ContainsKey(c))
                {
                    charDict.Add(c, 0);
                }
                charDict[c]++;
            }

            List<char> uniqueChars =  charDict.Where(kvp => kvp.Value ==1).Select(kvp=>kvp.Key).ToList();


            char firstUnique = uniqueChars.FirstOrDefault();
            if(firstUnique == null)
            {
                indexFirstUnique = -1;
            }
            else
            {
                indexFirstUnique = input.IndexOf(firstUnique);
            }

            return uniqueChars;
        }
    }
}