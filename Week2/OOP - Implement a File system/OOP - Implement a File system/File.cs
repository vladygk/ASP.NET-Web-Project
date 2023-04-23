namespace OOP___Implement_a_File_system
{
    public class File
    {
        public SortedDictionary<int, string> content;
        public int Size { get; set; }
        public string Name { get; set; }
        public File(string name)
        {
            this.Size = 0;
            content = new SortedDictionary<int, string>();
            Name = name;
        }
    }
}