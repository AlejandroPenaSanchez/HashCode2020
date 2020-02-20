using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace program
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] inputFilesName = new string[] { "a_example.txt", "b_read_on.txt", "c_incunabula.txt", "d_tough_choices.txt",  "e_so_many_books.txt"};

            Console.WriteLine("dame el nombre del ficheros");
            var filename = Console.ReadLine();
            var lines = ReadWrite.ReadFile($"../../../InputFiles/{filename}.txt").ToList();

            var line0 = lines[0].Split(" ");
            var nDifferentBooks = line0[0].ToInt();
            var nLibraries = line0[1].ToInt();
            var nDays = line0[2].ToInt();
            var scoresBooks = lines[1].Split(" ").Select(x => x.ToInt()).ToArray();

            var libraries = new List<Library>();

            for(var i = 2; i < lines.Count(); i=i+2)
            {
                if(i%100 == 0) Console.WriteLine($"Iteracion {i}");
                var linej = lines[i].Split(" ");
                var linej1 = lines[i+1].Split(" ");
                var bookIds = linej1.Select(x => x.ToInt()).ToArray();

                libraries.Add(new Library
                {
                    LibraryName = (i-2)/2,
                    NumberOfBooks = linej[0].ToInt(),
                    SingOutDays = linej[1].ToInt(),
                    Frecuency = linej[2].ToInt(),
                    BooksIds =  bookIds,
                    TotalScore = CalculateTotalScore(bookIds, scoresBooks)
                });
            }

            foreach(var library in libraries)
            {
                library.Print();
                library.MagicalNumber = CalculateMagicalNumber(library, nDays);
                Console.WriteLine($"{library.LibraryName} has {library.MagicalNumber} points");
            }

            var libraries2 = libraries.OrderBy(x => x.TotalScore);
            ReadWrite.WriteFile("./result.txt", libraries2.ToList());
            // algoritmo1 algo1 = new algoritmo1();
            // algo1.resolveProblem(inputPath, outputPath);

            // algoritmo2 algo2 = new algoritmo2();
            // algo2.resolveProblem(inputPath, outputPath);
            
        }

        private static Int64 CalculateMagicalNumber(Library library, int nDays)
        {
            Console.WriteLine(nDays - library.SingOutDays);
            return (nDays - library.SingOutDays) * library.TotalScore * library.Frecuency / 1000;
        }

        private static int CalculateTotalScore(int[] bookIds, int[] scoresBooks)
        {
            return scoresBooks.Where(x => bookIds.Contains(x)).Sum();
        }
    }
}
