namespace OOP_EncapsulationInheritance.IO;

    public class ConsoleWriter : IWriter
    {
        public static IWriter Instance = new ConsoleWriter();

        private ConsoleWriter()
        {
        }

        public void Write(string text)
        {
            Console.WriteLine(text);
        }
    }