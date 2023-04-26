namespace OOP___Implement_a_File_system;

public class Folder
{
    public Folder(string name)
    {
        this.Name = name;
        Files = new HashSet<File> ();
        Folders = new HashSet<Folder> ();
    }
    public string Name{ get; set; }
   
    public HashSet<File> Files { get; set; }

    public HashSet<Folder> Folders { get; set; }
}
