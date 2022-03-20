using System;
using System.Collections.Generic;

namespace GradeBook
{
    class Program
    {
        static void Main(string[] args)
        {
            var book = new Book("Alessio's book");
            book.ShowNameBook();

            Console.WriteLine("Enter a grade or type 'q' or 'Q' to quit");
            while(true)
            {
                var input = Console.ReadLine();

                if (input == "Q" || input == "q") break;

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
            Console.WriteLine($"The avarege is:{stats.Avarage:N1}");
            Console.WriteLine($"The highest is:{stats.High:N1}");
            Console.WriteLine($"The lowest is:{stats.Low:N1}");
            Console.WriteLine($"The letter is:{stats.Letter}");
        }
    }
}