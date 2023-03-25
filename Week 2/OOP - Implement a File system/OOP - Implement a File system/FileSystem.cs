namespace OOP___Implement_a_File_system;

public class FileSystem
{
    public Folder CurrentFolder { get; set; }
    public Stack<Folder> Path { get; set; }
    public FileSystem()
    {
        CurrentFolder = new Folder("/");

        Path = new Stack<Folder>();
        Path.Push(CurrentFolder);
    }
    public void Cmd()
    {
        string inputCmd;
        while ((inputCmd = Console.ReadLine()) != "exit")
        {
            string[] inputCmdArgs = inputCmd.Split();
            string command = inputCmdArgs[0];

            if (command == "cd")
            {
                CurrentFolder = Command.CD(CurrentFolder, inputCmdArgs, Path) ?? new Folder("/");
            }
            else if (command == "mkdir")
            {
                Command.MkDir(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "create_file")
            {
                Command.CreateFile(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "cat")
            {
                Command.Cat(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "tail")
            {
                Command.Tail(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "write")
            {
                Command.Write(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "ls")
            {
                Command.Ls(CurrentFolder, inputCmdArgs, Path);
            }
            else if (command == "size")
            {
                Console.WriteLine(Command.GetSize(CurrentFolder));
            }
            else if ((command == "folder"))
            {
                Console.WriteLine(CurrentFolder.Name);
            }
            else if (command == "clear")
            {
                Console.Clear();
            }
            else if (command == "wc")
            {
                Command.Wc(CurrentFolder, inputCmdArgs, Path, String.Empty);
            }


        }
    }
}
