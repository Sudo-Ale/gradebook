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

            if (String.IsNullOrEmpty(readerName)) throw new ArgumentException("There is no name");

            var book = new InMemoryBook(readerName);
            var diskBook = new DiskBook(readerName);

            EnterGrades(diskBook);

            book.GradeAdded += OnAddedGrade;
            book.ShowNameBook();

            Console.WriteLine("Enter a grade or type 'q / Q' to quit");

            EnterGrades(book);

            Console.WriteLine("Done, Calculating grades..");

            var stats = book.GetStatistics();
            var statsInDisk = diskBook.GetStatistics();

            Console.WriteLine($"The avarege is:{stats.Avarage:N1}");
            Console.WriteLine($"The highest is:{stats.High:N1}");
            Console.WriteLine($"The lowest is:{stats.Low:N1}");
            Console.WriteLine($"The letter is:{stats.Letter}");
        }

        private static void EnterGrades(IBook book)
        {
            while (true)
            {
                var input = Console.ReadLine();

                if (input == "Q" || input == "q") break;
                if (String.IsNullOrEmpty(input)) throw new ArgumentException("There is no values");

                try
                {
                    var grade = double.Parse(input);
                    book.AddGrade(grade);
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (FormatException e)
                {
                    Console.WriteLine(e.Message);
                }
                finally
                {
                    Console.WriteLine("**");
                }
            }
        }

        static void OnAddedGrade(object sender, EventArgs e)
        {
            Console.WriteLine("A grade was added");
        }
    }
}