using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

namespace program
{
    public static class ReadWrite
    {
        
        public static IEnumerable<string> ReadFile(string filePath)
        {
            var frequencies = new List<int>();
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), filePath);

            return File.ReadLines(path);
        }

        public static void WriteFile(string path, List<Library> result)
        {
            StreamWriter writer = new StreamWriter(path);
            writer.WriteLine(result.Count);//primera linea
            
            foreach(var line in result)
            {
                writer.WriteLine(line.LibraryName + " " + line.NumberOfBooks);//segunda linea
                foreach(var book in line.BooksIds)
                {
                    writer.Write(book + " ");
                }
                writer.WriteLine("");
            }
            writer.Close();

            Console.WriteLine("echo");
        }
    }
}
        
            