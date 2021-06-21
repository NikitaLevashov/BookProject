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

        public FakeBookListStorage(List<Book> book)
        {
            BookList = book;
        }
        public List<Book> Load()
        {
            return BookList;
        }

        public void Save(List<Book> books)
        {
            BookList.AddRange(books);   
        }
    }
}
