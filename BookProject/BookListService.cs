using BookProject.interfaces;
using System;
using System.Collections.Generic;

namespace BookProject
{
    public class BookListService
    {
        private readonly IBookListStorage _storage;

        /// <summary>
        /// Initializes a new instance of the BookListService class.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        public BookListService(IBookListStorage storage)
        {
            _storage = storage;
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
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        public void Add(Book book)
        {
            Books = _storage.Load();

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (Books.IndexOf(book) >= 0)
            {
                throw new ArgumentException("The book has been added.", nameof(book));
            }

            Books.Add(book);
            Save();
        }

        /// <summary>
        /// Remove the book.
        /// </summary>
        /// <param name="book">Book to be removed.</param>
        /// <exception cref="ArgumentException">Thrown when the book couldn't be found.</exception>
        /// <exception cref="ArgumentNullException">Thrown when the argument is null.</exception>
        public void Remove(Book book)
        {
            Books = _storage.Load();

            if (Books.Count == 0)
            {
                throw new ArgumentException("The storage empty, you can not remove book", nameof(book));
            }

            if (book == null)
            {
                throw new ArgumentNullException(nameof(book));
            }

            if (Books.IndexOf(book) == -1)
            {
                throw new ArgumentException("The storage doesn't contain the book.", nameof(book));
            }

            Books.Remove(book);
            Save();
        }

        /// <summary>
        /// Sort books using the given comparator.
        /// </summary>
        public void Sort()
        {
            Books = _storage.Load();
            Books.Sort();
            Save();           
        }

        public void Sort(IComparer<Book> comparator)
        {
            Books = _storage.Load();
            Books.Sort(comparator);
            Save();
        }

        /// <summary>
        /// Find books by some field
        /// </summary>
        /// <param name="searcher">searcher</param>
        /// <param name="tag">book field</param>
        /// <returns></returns>
        public IEnumerable<Book> FindByTag(IFindByTag finder)
        {
            Books = _storage.Load();

            foreach (Book book in Books)
            {
                if (finder.Contain(book))
                {
                    yield return book;
                }
            }
        }

        /// <summary>
        /// Save books to the specified storage.
        /// </summary>
        /// <param name="books">Books to be stored.</param>
        public void Save()
        {
            _storage.Save(Books);
        }

        /// <summary>
        /// Load books from the specified storage.
        /// </summary>
        /// <param name="storage">Storage to load books from.</param>
        public void Load()
        {
            Books = _storage.Load();
        }
    }
}
