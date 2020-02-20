using System;

namespace program
{
    public class Library
    {
        public int LibraryName { get; set; }
        public int NumberOfBooks { get; set; }
        public int SingOutDays { get; set; }
        public int[] BooksIds{get;set;}
        public int Frecuency { get; set; }
        public Int64 TotalScore{get;set;}
        public Int64 MagicalNumber { get; set; }

        public void Print()
        {
            Console.WriteLine($"{this.LibraryName} tiene {this.NumberOfBooks} libros, dias de registro {this.SingOutDays}, frecuencia {this.Frecuency} y un score total de {this.MagicalNumber}");
        }
    }
}