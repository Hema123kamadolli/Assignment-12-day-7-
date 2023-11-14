using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace FileHandlingDMS
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.WriteLine("Choose an operation:");
                Console.WriteLine("1. Create File");
                Console.WriteLine("2. Read File");
                Console.WriteLine("3. Append to File");
                Console.WriteLine("4. Delete File");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice : ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("Enter file name: ");
                        string createFileName = Console.ReadLine();
                        Console.Write("Enter content: ");
                        string createFileContent = Console.ReadLine();
                        CreateFile(createFileName, createFileContent);
                        Console.WriteLine("File created successfully.");
                        break;

                    case "2":
                        Console.Write("Enter file name to read: ");
                        string readFile = Console.ReadLine();
                        ReadFile(readFile);
                        break;

                    case "3":
                        Console.Write("Enter file name to append: ");
                        string appendFileName = Console.ReadLine();
                        Console.Write("Enter content to append: ");
                        string appendContent = Console.ReadLine();
                        AppendToFile(appendFileName, appendContent);
                        Console.WriteLine("Content appended successfully.");
                        break;

                    case "4":
                        Console.Write("Enter file name to delete: ");
                        string deleteFileName = Console.ReadLine();
                        DeleteFile(deleteFileName);
                        Console.WriteLine("File deleted successfully.");
                        break;

                    case "5":
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please enter a number between 1 and 5.");
                        break;
                }
            }
        }

        static void CreateFile(string fileName, string content)
        {
            try
            {
                File.WriteAllText(fileName, content);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error creating file: {ex.Message}");
            }
        }

        static void ReadFile(string fileName)
        {
            try
            {
                string content = File.ReadAllText(fileName);
                Console.WriteLine($"Content of {fileName}:\n{content}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error reading file: {ex.Message}");
            }
        }

        static void AppendToFile(string fileName, string content)
        {
            try
            {
                File.AppendAllText(fileName, content);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error appending to file: {ex.Message}");
            }
        }

        static void DeleteFile(string fileName)
        {
            try
            {
                File.Delete(fileName);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine($"File '{fileName}' not found.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
            }
        }
    }
}
