using BookProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Tests
{
    public class FakeBookListStorage : IBookListStorage
    {
        public List<Book> BookList { get; set; }

        public FakeBookListStorage()
        {
            BookList = new List<Book>();
        }

        public FakeBookListStorage(List<Book> list)
        {
            BookList = list;
        }

        public void Save(IEnumerable<Book> books)
        {
            BookList = books.ToList();
        }

        public IEnumerable<Book> Load()
        {
            return BookList;
        }
    }
}
