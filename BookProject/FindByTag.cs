using BookProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    /// <summary>
    /// Determines if the book contains the specified ISBN
    /// </summary>
    public class IsbnTags : IFindByTag
    {
        public string ISBN { get; set; }
        public IsbnTags(string isbn)
        {
            ISBN = isbn;
        }
        public bool Contain(Book book)
        {
            return (book.ISBN == this.ISBN) ? true : false;
        }
    }

    /// <summary>
    /// Determines if the book contains the specified Author
    /// </summary>
    public class AuthorTags : IFindByTag
    {
        public string Author { get; set; }
        public AuthorTags(string autor)
        {
            Author = autor;
        }
        public bool Contain(Book book)
        {
            return (book.Author == this.Author) ? true : false;
        }
    }

    /// <summary>
    /// Determines if the book contains the specified Title
    /// </summary>
    public class TitleTags : IFindByTag
    {
        public string Title { get; set; }
        public TitleTags(string title)
        {
            Title = title;
        }
        public bool Contain(Book book)
        {
            return (book.Title == this.Title) ? true : false;
        }
    }

    /// <summary>
    /// Determines if the book contains the specified Publishing house
    /// </summary>
    public class PublichingHouseTags : IFindByTag
    {
        public string Publisher { get; set; }
        public PublichingHouseTags(string publishingHouse)
        {
            Publisher = publishingHouse;
        }
        public bool Contain(Book book)
        {
            return (book.Publisher == this.Publisher) ? true : false;
        }
    }
}
