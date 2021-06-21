using BookProject.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    public class BookListService
    {
        /// <summary>
        /// Initializes a new instance of the BookListService class.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        public BookListService(params Book[] books)
        {
            Books = new List<Book>();

            foreach (Book book in books)
            {
                if (book == null)
                {
                    continue;
                }

                Books.Add(book);
            }
        }

        /// <summary>
        /// List of books to operate with.
        /// </summary>
        public List<Book> Books { get; private set; }

        /// <summary>
        /// Add the book.
        /// </summary>
        /// <param name="book">Book to be added.</param>
        /// <exception cref="ArgumentException">Thrown when the book has already been stored.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        public void Add(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (Books.IndexOf(book) >= 0)
            {
                throw new ArgumentException("The  book has already been stored.", nameof(book));
            }

            Books.Add(book);
        }

        /// <summary>
        /// Remove the book.
        /// </summary>
        /// <param name="book">Book to be removed.</param>
        /// <exception cref="ArgumentException">Thrown when the book couldn't be found.</exception>
        /// <exception cref="ArgumentException">Thrown when the argument is null.</exception>
        public void Remove(Book book)
        {
            if (book == null)
            {
                throw new ArgumentNullException();
            }

            if (Books.IndexOf(book) == -1)
            {
                throw new ArgumentException("The BookListStorage doesn't contain the book.", nameof(book));
            }

            Books.Remove(book);
        }

        /// <summary>
        /// Sort books using the given comparator.
        /// </summary>
        public void Sort()
        {
            Books.Sort();
        }

        /// <summary>
        /// Find books by some field
        /// </summary>
        /// <param name="searcher">searcher</param>
        /// <param name="tag">book field</param>
        /// <returns></returns>
        public List<Book> FindByTag(IFindByTag finder)
        {
            List<Book> result = new List<Book>();

            foreach (Book book in Books)
            {
                if (finder.Contain(book))
                {
                    result.Add(book);
                }
            }

            return result;
        }

        /// <summary>
        /// Save books to the specified storage.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        public void Save(IBookListStorage storage)
        {
            storage.Save(Books);
        }

        /// <summary>
        /// Load books from the specified storage.
        /// </summary>
        /// <param name="storage">Storage to load books from.</param>
        public void Load(IBookListStorage storage)
        {
            Books = storage.Load();
        }
    }
}
