using BookProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
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

        public List<Book> Load()
        {
            return BookList;
        }

        public void Save(List<Book> books)
        {
            BookList = books;
        }
    }
}
