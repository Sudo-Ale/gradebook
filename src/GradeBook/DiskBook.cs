using System;
using System.IO;

namespace GradeBook
{
    public class DiskBook : Book
    {
        public DiskBook(string name) : base(name) {}

        public override event GradeAddedDelegate GradeAdded;
        public override void AddGrade(double grade)
        {
            if(grade <= 100 && grade >=0)
            {
                string path = @$"C:\\Users\\a.maggio\\Desktop\\{Name}.txt";

                var writer = File.AppendText(path);
                var gradeLine = grade.ToString();

                writer.WriteLine(gradeLine);
                writer.Close();
            }
            else
            {
                throw new ArgumentException($"Invalid {nameof(grade)}");
            }
        }

        public override Statistics GetStatistics()
        {
            throw new NotImplementedException();
        }
    }
}