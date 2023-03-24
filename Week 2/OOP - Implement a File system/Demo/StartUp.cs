namespace Demo
{
    using OOP___Implement_a_File_system;
    internal class StartUp
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Green; //to look more badass
            
            FileSystem fs = new FileSystem();
            fs.Cmd();
        }
    }
}