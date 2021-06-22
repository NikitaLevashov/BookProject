using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Tests.Comparators
{
    /// <summary>
    /// Compare by Author
    /// </summary>
    public class AuthorCompare : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(firstBook));
            }
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(secondBook));
            }
            if (firstBook.Author.Length > secondBook.Author.Length)
            {
                return 1;
            }
            if (firstBook.Author.Length == secondBook.Author.Length)
            {
                return 0;
            }
            return -1;
        }
    }
    

    /// <summary>
    /// Compare by Pages
    /// </summary>
    public class PageCompare : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(firstBook));
            }
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(secondBook));
            }
            if (firstBook.Pages > secondBook.Pages)
            {
                return 1;
            }
            if (firstBook.Pages == secondBook.Pages)
            {
                return 0;
            }
            return -1;
        }
    }

    /// <summary>
    /// Compare by price
    /// </summary>
    public class PriceCompare : IComparer<Book>
    {
        public int Compare(Book firstBook, Book secondBook)
        {
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(firstBook));
            }
            if (firstBook == null || secondBook == null)
            {
                throw new ArgumentNullException(nameof(secondBook));
            }
            if (firstBook.Price > secondBook.Price)
            {
                return 1;
            }
            if (firstBook.Price == secondBook.Price)
            {
                return 0;
            }
            return -1;
        }
    }
}
