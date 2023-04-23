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

            coolestCar = carplateOwner[coolPlateNumber];

            var result = new HashSet<string>(carplateOwner.Values
              .Where(owner => (carplateOwner.Values.Count(x => x == owner) > 1))).ToList();

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

            foreach (char c in input)
            {
                if (!charDict.ContainsKey(c))
                {
                    charDict.Add(c, 0);
                }
                charDict[c]++;
            }

            List<char> uniqueChars = charDict.Where(kvp => kvp.Value == 1).Select(kvp => kvp.Key).ToList();


            char firstUnique = uniqueChars.FirstOrDefault();
            if (firstUnique == null)
            {
                indexFirstUnique = -1;
            }
            else
            {
                indexFirstUnique = input.IndexOf(firstUnique);
            }

            return uniqueChars;
        }

        public static List<string> SpellChecker(string input, HashSet<string> allCorrectWords)
        {
            List<string> wrongWords = new List<string>();
            if (input.Length == 0)
            {
                return wrongWords;
            }

            string inputWithoutPunctuation = input.Replace(",", String.Empty)
                    .Replace(".", String.Empty)
                    .Replace("!", String.Empty)
                    .Replace("?", String.Empty);

            string[] arrayOfWords = inputWithoutPunctuation.Split();
            for (int i = 0; i < arrayOfWords.Length; i++)
            {
                if (!allCorrectWords.Contains(arrayOfWords[i].ToLower()))
                {
                    wrongWords.Add(arrayOfWords[i]);
                }
            }

            return wrongWords;
        }

        public static Dictionary<SortedSet<char>, List<string>> GroupByAnagrams(List<string> words)
        {
            Dictionary<SortedSet<char>, List<string>> groupsByAnagram = new Dictionary<SortedSet<char>, List<string>>();


            foreach(string word in words)
            {
                SortedSet<char> anagramChars = new SortedSet<char>(word.ToCharArray());

                if (groupsByAnagram.Keys.FirstOrDefault(set => set.SetEquals(anagramChars)) == null)
                {
                    groupsByAnagram[anagramChars] = new List<string>();
                    
                }
                groupsByAnagram[groupsByAnagram.Keys.FirstOrDefault(set => set.SetEquals(anagramChars))].Add(word);

            }

            return groupsByAnagram;
        }
    }
}