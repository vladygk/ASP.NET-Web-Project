using System.Collections.Generic;
using System.Text;

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

    private static File? FindFile(string fileName, Folder CurrentFolder)
    {
        return CurrentFolder.Files.FirstOrDefault(x => x.Name == fileName);
    }

    public static Folder? CD(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        Folder? result = null;
        string folderName = inputCmdArgs[1];

        if (folderName != ".." && folderName != ".")
        {
            if (!CurrentFolder.Folders.Select(f => f.Name).Contains(folderName))
            {
                Console.WriteLine("No such folder");
                result = null;
            }
            else
            {
                Folder folder = CurrentFolder.Folders.First(f => f.Name == folderName);
                Path.Push(folder);
                Console.WriteLine(GetPath(Path));
                result = Path.Peek();
            }
        }
        else if (folderName == ".")
        {
            //Do nothing
            Console.WriteLine(GetPath(Path));
            result = Path.Peek();
        }
        else if (folderName == "..")
        {
            if (Path.Count <= 1)
            {
                Console.WriteLine("You in the root folder");
                result = Path.Peek();
            }
            else
            {
                Path.Pop();
                Console.WriteLine(GetPath(Path));
                result = Path.Peek();
            }
        }

        return result;
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

    public static string Cat(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path, bool print)
    {
        string fileName;
        StringBuilder result = new StringBuilder();
        fileName = inputCmdArgs[1];

        if (inputCmdArgs.Length == 2)
        {
            File? file = FindFile(fileName, CurrentFolder);

            if (file == null)
            {
                Console.WriteLine("File doesn't exist");
                return String.Empty;
            }
            else
            {
                foreach (var kvp in file.content)
                {
                    if (print)
                    {
                        Console.WriteLine($"Line {kvp.Key}: {kvp.Value}");
                    }

                    result.AppendLine(kvp.Value);
                }
            }
        }
        else
        {
            // cat fileName | wc
            string text = Cat(CurrentFolder, inputCmdArgs.Take(2).ToArray(), Path, false);

            Wc(CurrentFolder, inputCmdArgs.Skip(3).ToArray(), Path, text);
        }

        return result.ToString().Trim();
    }

    public static string Tail(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path, bool print)
    {
        // tail fileName
        // tail fileName opt
        // tail fileName | wc
        //tail fileName opt | wc
        //tail fileName | wc -l
        StringBuilder result = new StringBuilder();


        if (inputCmdArgs.Length == 2)
        {

            string fileName = inputCmdArgs[1];
            File? file = FindFile(fileName, CurrentFolder);

            if (file == null)
            {
                Console.WriteLine("File doesn't exist");
                return String.Empty;
            }
            else
            {
                Dictionary<int, string> lines;

                lines = file.content.Skip(file.content.Count - 10).Take(10).Reverse().ToDictionary(x => x.Key, x => x.Value);

                foreach (var line in lines)
                {
                    if (print)
                    {
                        Console.WriteLine($"Line {line.Key}: {line.Value}");
                    }

                    result.AppendLine(line.Value);
                }
            }



        }
        else if (inputCmdArgs.Length == 3)
        {
            int optionalParam = int.Parse(inputCmdArgs[2]);

            string fileName = inputCmdArgs[1];
            File? file = FindFile(fileName, CurrentFolder);

            if (file == null)
            {
                Console.WriteLine("File doesn't exist");
                return String.Empty;
            }
            else
            {
                Dictionary<int, string> lines;

                lines = file.content.Skip(file.content.Count - optionalParam).Take(optionalParam).Reverse().ToDictionary(x => x.Key, x => x.Value);

                foreach (var line in lines)
                {
                    if (print)
                    {
                        Console.WriteLine($"Line {line.Key}: {line.Value}");
                    }

                    result.AppendLine(line.Value);
                }
            }
        }
        else if (inputCmdArgs.Length == 4)
        {
            string optionalFileName = Tail(CurrentFolder, inputCmdArgs.Take(2).ToArray(), Path, false);

            Wc(CurrentFolder, inputCmdArgs.Skip(3).ToArray(), Path, optionalFileName);
        }
        else if (inputCmdArgs.Length == 5 && inputCmdArgs[2] == "|")
        {
            string optionalFileName = Tail(CurrentFolder, inputCmdArgs.Take(2).ToArray(), Path, false);

            Wc(CurrentFolder, inputCmdArgs.Skip(3).ToArray(), Path, optionalFileName);
        }
        else if (inputCmdArgs.Length == 5 && inputCmdArgs[3] == "|")
        {
            string optionalFileName = Tail(CurrentFolder, inputCmdArgs.Take(3).ToArray(), Path, false);

            Wc(CurrentFolder, inputCmdArgs.Skip(4).ToArray(), Path, optionalFileName);
        }
        else if (inputCmdArgs.Length == 6)
        {
            string optionalFileName = Tail(CurrentFolder, inputCmdArgs.Take(3).ToArray(), Path, false); //tail file1 opt | wc -l

            Wc(CurrentFolder, inputCmdArgs.Skip(4).ToArray(), Path, optionalFileName);
        }







        return result.ToString();
    }

    public static void Write(Folder CurrentFolder, string[] inputCmdArgs, Stack<Folder> Path)
    {
        string fileName = inputCmdArgs[1];
        int lineNumber = int.Parse(inputCmdArgs[2]);
        string lineContent = String.Join(" ", inputCmdArgs.Skip(3).Take(inputCmdArgs.Length - 3));
        string optionalParam = string.Empty;

        if (inputCmdArgs.Length == 5 && inputCmdArgs[4] == "-o")
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
        if (inputCmdArgs.Length == 3
            && inputCmdArgs[1] == "--sorted"
            && inputCmdArgs[2] == "desc")
        {

            Console.WriteLine(String.Join(Environment.NewLine, CurrentFolder
                .Folders.OrderByDescending(f => GetSize(f)).Select(f => f.Name)));

            Console.WriteLine(String.Join(Environment.NewLine, CurrentFolder
               .Files.OrderByDescending(f => f.Size).Select(f => f.Name)));

        }
        else if (inputCmdArgs.Length == 4 && inputCmdArgs[2] == "wc" && inputCmdArgs[3] == "-l")
        {
            foreach (var file in CurrentFolder.Files)
            {
                Wc(CurrentFolder, inputCmdArgs.Skip(2).ToArray(), Path, file.Name);
            }
        }
        else if (inputCmdArgs.Length == 3 && inputCmdArgs[2] == "wc")
        {
            foreach (var file in CurrentFolder.Files)
            {
                Wc(CurrentFolder, inputCmdArgs.Skip(2).ToArray(), Path, file.Name);
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

        if (inputCmdArgs.Length == 1)
        {
            if (optionalFileName == String.Empty)
            {
                Console.WriteLine("Number of words: 0");
            }
            else
            {

                fileName = optionalFileName;


                File file = FindFile(fileName, CurrentFolder);

                if (file == null)
                {
                    int wordsCount = 0;

                    foreach (var line in fileName.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries))
                    {
                        wordsCount += line.Split().Length;
                    }

                    Console.WriteLine($"Number of words: {wordsCount}");
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
        else if (inputCmdArgs.Length == 2 && inputCmdArgs[1] == "-l")
        {
            if (optionalFileName == String.Empty)
            {
                Console.WriteLine("Number of lines: 0");
            }
            else
            {

                fileName = optionalFileName;


                File file = FindFile(fileName, CurrentFolder);
                if (file == null)
                {
                    int countLines = fileName.Split(Environment.NewLine,StringSplitOptions.RemoveEmptyEntries).Length;

                    Console.WriteLine($"Number of lines: {countLines}");
                }
                else
                {
                    Console.WriteLine($"Number of lines in file: {file.Size}");
                }
            }
        }
        else if (inputCmdArgs.Length == 2 && inputCmdArgs[1] != "-l")
        {
            fileName = inputCmdArgs[1];
            File file = FindFile(fileName, CurrentFolder);
            if (file == null)
            {
                int countLines = string.Join(" ", inputCmdArgs.Skip(2).Take(inputCmdArgs.Length - 2)).Split(Environment.NewLine).Length;
                Console.WriteLine($"Number of lines {countLines}");
            }
            else
            {
                Console.WriteLine($"Number of lines in file: {file.Size}");
            }
        }
        else if (inputCmdArgs.Length == 3 && inputCmdArgs[1] == "-l")
        {
            fileName = inputCmdArgs[2];

            File file = FindFile(fileName, CurrentFolder);
            if (file == null)
            {
                int countLines = string.Join(" ", inputCmdArgs.Skip(1).Take(inputCmdArgs.Length - 1))
                    .Split(Environment.NewLine).Length;
                Console.WriteLine($"Number of lines: {countLines}");
            }
            else
            {
                Console.WriteLine($"Number of lines in file: {file.Size}");
            }
        }

    }
}
