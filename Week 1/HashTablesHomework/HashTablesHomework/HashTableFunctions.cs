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
    }
}