using System;
using Xunit;

namespace GradeBook.Tests
{
    public class TypeTests
    {
        [Fact]
        public void ValueTypesAlsoPassByValue()
        {
            int x;
            x = GetInt();
            SetInt(x);

            Assert.Equal(3, x);
        }
        private int GetInt()
        {
            return 3;
        }
        private void SetInt(int num)
        {
            num = 7;
        }

        [Fact]
        public void CSharpCanPassByRef()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            GetBookSetName(out book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
            Assert.False(Object.ReferenceEquals(book1, book2));
        }
        private void GetBookSetName(out Book book, string name)
        {
            book = new Book(name);
        }
        
        [Fact]
        public void CSharpIsPassByValue()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            GetBookSetName(book1, "New Name");
            
            Assert.Equal("Book 1", book1.Name);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        private void GetBookSetName(Book book, string name)
        {
            book = new Book(name);
        }

        [Fact]
        public void CanSetNameFromReference()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;
            SetName(book1, "New Name");
            
            Assert.Equal("New Name", book1.Name);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }
        private void SetName(Book book, string name)
        {
            book.Name = name;
        }

        [Fact]
        public void StringsBehaveLikeValueTypes()
        {
            string name = "Alessio";
            var upper = MakeUpperCase(name);

            Assert.Equal("Alessio", name);
            Assert.Equal("ALESSIO", upper);
        }
        private string MakeUpperCase(string parameter)
        {
            return parameter.ToUpper();
        }

        [Fact]
        public void GetBookReturnsDifferentObjects()
        {
            var book1 = GetBook("Book 1");
            var book2 = GetBook("Book 2");

            Assert.Equal("Book 1", book1.Name);
            Assert.Equal("Book 2", book2.Name);
            Assert.NotSame(book1, book2);
        }

        [Fact]
        public void TwoVarsCanReferenceSameObject()
        {
            var book1 = GetBook("Book 1");
            var book2 = book1;

            Assert.Same(book1, book2);
            Assert.True(Object.ReferenceEquals(book1, book2));
        }

        Book GetBook(string name)
        {
            return new Book(name);
        }
    }
}
