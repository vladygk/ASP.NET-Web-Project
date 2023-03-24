using System.Runtime.InteropServices;

namespace OOP___Implement_a_File_system;

public class Command
{


    public static int GetSize(Folder folder)
    {
        if (folder.Folders.Count == 0)
        {
            return folder.Files.Sum(f => f.Size);
        }

        return folder.Files.Sum(f => f.Size) + folder.Folders.Sum(fl => GetSize(fl));
    }
    private static string GetPath(Stack<Folder> Path)
    {

        return string.Join("/", Path.Select(f => f.Name).Reverse());
    }
    private static File? FindFile(string fileName, Folder CurrentFolder) => CurrentFolder.Files.FirstOrDefault(x => x.Name == fileName);



    public static Folder? CD(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string folderName = inputCmdArgs[1];
        if (folderName != ".." && folderName != ".")
        {
            if (!CurrentFolder.Folders.Select(f => f.Name).Contains(folderName))
            {
                Console.WriteLine("No such folder");
                return null;
            }
            else
            {
                Folder folder = CurrentFolder.Folders.First(f => f.Name == folderName);
                Path.Push(folder);


                Console.WriteLine(GetPath(Path));
                return Path.Peek();
            }

        }
        else if (folderName == ".")
        {
            //Do nothing
            Console.WriteLine(GetPath(Path));
            return Path.Peek();
        }
        else if (folderName == "..")
        {
            if (Path.Count <= 1)
            {
                Console.WriteLine("You in the root folder");
                return Path.Peek();
            }
            else
            {
                Path.Pop();
                Console.WriteLine(GetPath(Path));
                return Path.Peek();
            }
        }
        return Path.Peek();
    }

    public static void MkDir(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string dirName = inputCmdArgs[1];
        Folder newFolder = new Folder(dirName);

        CurrentFolder.Folders.Add(newFolder);
        Console.WriteLine($"Folder {dirName} created");
    }

    public static void CreateFile(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string fileName = inputCmdArgs[1];
        File newFile = new File(fileName);
        CurrentFolder.Files.Add(newFile);
        Console.WriteLine($"File {fileName} created");
    }

    public static void Cat(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string fileName = inputCmdArgs[1];
        File? file = FindFile(fileName, CurrentFolder);

        if (file == null)
        {
            Console.WriteLine("File doesn't exist");
        }
        else
        {
            foreach (var kvp in file.content)
            {
                Console.WriteLine(kvp.Value);
            }
        }
    }

    public static void Tail(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string fileName = inputCmdArgs[1];
        int optionalParam = -1;
        File? file = FindFile(fileName, CurrentFolder);

        if (inputCmdArgs.Length == 3)
        {
            optionalParam = int.Parse(inputCmdArgs[2]);
        }

        if (file == null)
        {
            Console.WriteLine("File doesn't exist");
        }
        else
        {
            List<string> lines;
            if (optionalParam == -1)
            {
                lines = file.content.Values.Skip(file.content.Count - 10).Take(10).Reverse().ToList();

            }
            else
            {
                lines = file.content.Values.Skip(file.content.Count - optionalParam).Take(optionalParam).Reverse().ToList();
            }

            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }
        }

    }

    public static void Write(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string fileName = inputCmdArgs[1];
        int lineNumber = int.Parse(inputCmdArgs[2]);
        string lineContent = String.Join(" ", inputCmdArgs.Skip(3).Take(inputCmdArgs.Length - 3));
        string optionalParam = string.Empty;
        if (inputCmdArgs.Length == 5)
        {
            optionalParam = inputCmdArgs[4];
        }

        File? file = FindFile(fileName, CurrentFolder);

        if (file == null)
        {
            Console.WriteLine("File doesn't exist");
        }
        else
        {

            if (!file.content.ContainsKey(lineNumber))
            {
                file.content.Add(lineNumber, String.Empty);

                if (optionalParam == string.Empty)
                {
                    file.content[lineNumber] += lineContent;
                    Console.WriteLine($"{lineContent} added to file {fileName} at line {lineNumber}");
                    file.Size++;
                }
                else
                {
                    file.content[lineNumber] = lineContent;
                    Console.WriteLine($"{lineContent} overwritten to file {fileName} at line {lineNumber}");

                }



            }
            else
            {
                if (optionalParam == string.Empty)
                {
                    file.content[lineNumber] += lineContent;
                    Console.WriteLine($"{lineContent} added to file {fileName} at line {lineNumber}");
                }
                else
                {
                    file.content[lineNumber] = lineContent;
                    Console.WriteLine($"{lineContent} overwritten to file {fileName} at line {lineNumber}");
                }
            }

        }
    }

    public static void Ls(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        if (inputCmdArgs.Length==3&& inputCmdArgs[2] == "desc")
        {
            if (inputCmdArgs[1] == "--sorted" && inputCmdArgs[2] == "desc")
            {
                Console.WriteLine(String.Join(Environment.NewLine, CurrentFolder
                    .Folders.OrderByDescending(f => GetSize(f)).Select(f => f.Name)));

                Console.WriteLine(String.Join(Environment.NewLine, CurrentFolder
                   .Files.OrderByDescending(f => f.Size).Select(f => f.Name)));
            }
        }
        else if (inputCmdArgs.Length == 4 && inputCmdArgs[2] == "wc")
        {
            foreach (var file in CurrentFolder.Files)
            {
                Wc(CurrentFolder, inputCmdArgs,Path,file.Name);
            }
        }
        else
        {
            foreach (Folder folder in CurrentFolder.Folders)
            {
                Console.WriteLine($"[{folder.Name}]");
            }
            foreach (File file in CurrentFolder.Files)
            {
                Console.WriteLine(file.Name);
            }
        }

    }

    public static void Wc(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path, string optionalFileName)
    {
        string fileName = String.Empty;

        if (optionalFileName != String.Empty)
        {
            fileName = optionalFileName;
        }
        else
        {
            fileName = inputCmdArgs[1];

        }

        if (fileName == "-l")
        {
            fileName = inputCmdArgs[2];
            File file = FindFile(fileName, CurrentFolder);
            if (file == null)
            {
                int countLines = string.Join(" ", inputCmdArgs.Skip(1).Take(inputCmdArgs.Length - 1)).Split(Environment.NewLine).Length;
                Console.WriteLine($"Number of lines {countLines}");
            }
            else
            {
                Console.WriteLine($"Number of lines in file: {file.Size}");
            }
        }
        else
        {
            File file = FindFile(fileName, CurrentFolder);

            if (file == null)
            {
                Console.WriteLine(inputCmdArgs.Length - 1);
            }
            else
            {
                int wordsCount = 0;
                foreach (var line in file.content)
                {
                    wordsCount += line.Value.Split(" ").Length;
                }

                Console.WriteLine($"Number of words {wordsCount} in file {fileName}");
            }
        }
    }


}
