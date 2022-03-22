using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hi, type the name of your book");
            var readerName = Console.ReadLine();

            var book = new Book(readerName);            
            book.ShowNameBook();

            Console.WriteLine("Enter a grade or type 'q' or 'Q' to quit");
            while(true)
            {
                var input = Console.ReadLine();

                if (input == "Q" || input == "q") break;
                if (String.IsNullOrEmpty(input)) throw new ArgumentException("There is no values");

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch(ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch(FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    //...
                }
            }
            Console.WriteLine("Done, Calculating grades..");

            var stats = book.GetStatistics();
            
            Console.WriteLine(Book.CATEGORY);
            Console.WriteLine($"The avarege is:{stats.Avarage:N1}");
            Console.WriteLine($"The highest is:{stats.High:N1}");
            Console.WriteLine($"The lowest is:{stats.Low:N1}");
            Console.WriteLine($"The letter is:{stats.Letter}");
        }
    }
}