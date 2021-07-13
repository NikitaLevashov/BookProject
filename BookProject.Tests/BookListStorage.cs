using BookProject.interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Tests
{
    public class BookListStorage : IBookListStorage
    {
        private readonly string Path;

        /// <summary>
        /// Constructor of the books storage class
        /// </summary>
        /// <param name="filepath">path for binary file</param>
        public BookListStorage(string path)
        {
            this.Path = path;
        }

        /// <summary>
        /// Loads books from Binarystorage
        /// </summary>
        /// <returns>uploaded books list</returns>
        public IEnumerable<Book> Load()
        {
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    List<Book> books = new List<Book>();

                    while (reader.BaseStream.Position != reader.BaseStream.Length)
                    {
                        string isbn = reader.ReadString();
                        string author = reader.ReadString();
                        string title = reader.ReadString();
                        string publisher = reader.ReadString();

                        Book book = new Book(author, title, publisher, isbn);
                        if (!books.Contains(book))
                        {
                            books.Add(book);
                        }
                    }
                    return books;
                }
            }
        }       

        /// <summary>
        /// Saves books to Binarystorage
        /// </summary>
        /// <param name="books">books for save</param>
        public void Save(IEnumerable<Book> books)
        {
            if (books == null)
            {
                throw new ArgumentNullException(nameof(books));
            }
            using (FileStream stream = new FileStream(Path, FileMode.OpenOrCreate))
            {
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    foreach (var book in books)
                    {
                        writer.Write(book.Author);
                        writer.Write(book.Title);
                        writer.Write(book.Publisher);
                        writer.Write(book.ISBN);
                    }
                }
            }
        }   
    }
}
