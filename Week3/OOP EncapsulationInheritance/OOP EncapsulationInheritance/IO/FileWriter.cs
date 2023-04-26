namespace OOP_EncapsulationInheritance.IO;

    public class FileWriter : IWriter
    {
        public static IWriter Instance = new FileWriter();

        private FileWriter()
        {
        }

        public void Write(string text)
        {
             File.WriteAllText("output.txt", text);
        }
    }