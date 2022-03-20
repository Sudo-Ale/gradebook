using System;
using Xunit;

namespace GradeBook.Tests
{
    public class BookTests
    {
        [Fact]
        public void GetStatisticsOutputValue()
        {
            var book1 = new Book("");
            Statistics result = new Statistics();
            
            book1.AddGrade(45.7);
            book1.AddGrade(72.8);
            book1.AddGrade(61.2);
            
            result = book1.GetStatistics();

            Assert.Equal(59.9, result.Avarage, 1);
            Assert.Equal(72.8, result.High, 1);
            Assert.Equal(45.7, result.Low, 1);
            Assert.Equal('F', result.Letter);
        }
        [Fact]
        public void BookAddGradeTakeOnlyZeroToHoundred()
        {
            var book1 = new Book("");
            Statistics result = new Statistics();
            
            book1.AddGrade(45.7);
            book1.AddGrade(105);
            book1.AddGrade(61.2);
            
            result = book1.GetStatistics();

            Assert.Equal(53.4, result.Avarage, 1);
            Assert.Equal(61.2, result.High, 1);
            Assert.Equal(45.7, result.Low, 1);
        }
        [Fact]
        public void BookCalculatesAnAvarageGrade()
        {   
            //arrange
            var book = new Book("");
            book.AddGrade(89.1);
            book.AddGrade(90.5);
            book.AddGrade(77.3);

            //act
            var result = book.GetStatistics();
            //assert
            Assert.Equal(85.6, result.Avarage, 1);
            Assert.Equal(90.5, result.High, 1);
            Assert.Equal(77.3, result.Low, 1);
        }
    }
}
