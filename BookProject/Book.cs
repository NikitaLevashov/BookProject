using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject
{
    public sealed class Book : IEquatable<Book>, IComparable<Book>, IComparable
    {
        private bool published;

        private DateTime? datePublished;

        private int totalPages;

        public string Title { get; }

        public string Publisher { get; }

        public string Author { get; }

        public string ISBN { get; }

        public double Price { get; private set; }

        public string Currency { get; private set; }

        public int Pages
        {
            get => totalPages;
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException(nameof(totalPages));
                }

                totalPages = value;
            }
        }

        /// <summary>
        /// Constructor for class <c>Book</c> with four parameters
        /// </summary>
        /// <param name="author"> Author</param>
        /// <param name="title">Title</param>
        /// <param name="publisher">Pulisher</param>
        public Book(string author, string title, string publisher)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
            Author = author ?? throw new ArgumentNullException(nameof(author));
        }

        /// <summary>
        /// Constructor for class <c>Book</c> with four parameters
        /// </summary>
        /// <param name="author"> Author</param>
        /// <param name="title">Title</param>
        /// <param name="publisher">Pulisher</param>
        /// <param name="isbn">Isbn</param>
        public Book(string author, string title, string publisher, string isbn) : this(author, title, publisher)
        {
            if (IsIsbnValid(isbn))
            {
                ISBN = isbn;
            }
            else
            {
                throw new ArgumentException(nameof(isbn), "Not correct format ISBN");
            }
        }

        /// <summary>
        /// Method set price for book.
        /// </summary>
        /// <param name="price">Price.</param>
        /// <param name="currency">Currency.</param>
        /// <returns>Info about price</returns>
        public string SetPrice(double price, string currency)
        {
            ValidatePrice(price);
            ValidateCurrency(currency);

            Price = price;
            Currency = currency;

            return $"Price: {Price}, Currency: {Currency}";
        }

        /// <summary>
        /// Method return info about publish.
        /// </summary>
        /// <param name="dateTime">Publish data</param>
        /// <returns>Info about publish.</returns>
        public string Publish(DateTime? dateTime)
        {
            ValidateData(dateTime);
            published = true;
            datePublished = dateTime;

            return $"Published: {published} - {datePublished}";
        }

        /// <summary>
        /// Method return info about publication info.
        /// </summary>
        /// <param name="publishedValue"></param>
        /// <returns>String value datePublished or NYP</returns>
        public string GetPublicationDate(bool publishedValue)
        {
            published = publishedValue;
            datePublished = new DateTime(2010, 12, 12);

            if (published == true)
            {
                return datePublished.ToString();
            }
            else
            {
                return "NYP";
            }
        }

        /// <summary>
        /// Method return info about Title and Author
        /// </summary>
        /// <returns>Info about book</returns>
        public override string ToString()
        {
            return $" {Title} by {Author} ";
        }

        /// <summary>
        /// Method check correct ISBN value
        /// </summary>
        /// <param name="isbnValue"> ISBN value</param>
        /// <returns>True if correct</returns>
        /// <exception cref="ArgumentNullException"> If ISBN valur equal null.</exception>
        /// <exception cref="ArgumentException">If ISBN noy correct format</exception>
        public bool IsIsbnValid(string isbnValue)
        {
            if (string.IsNullOrEmpty(isbnValue))
            {
                throw new ArgumentNullException(nameof(isbnValue));
            }

            string clearedIn = isbnValue.ToUpper().Replace("-", "").Replace(" ", "").Trim();

            int[] numbers = clearedIn.ToCharArray().Select(i => i == 'X' ? 10 : int.Parse(i.ToString())).ToArray();

            int sum = 0;

            if (numbers.Length == 10)
            {

                for (int i = 0; i < 10; i++)
                {
                    sum += numbers[i] * (10 - i);
                }

                if (sum % 11 == 0)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException(nameof(numbers), "Not correct format ISBN");
                }
            }

            if (numbers.Length == 13)
            {
                for (int i = 0; i < 12; i++)
                {
                    sum += (i % 2 == 0) ? numbers[i] : numbers[i] * 3;
                }

                return ((10 - (sum % 10)) % 10) == (numbers.Last() % 10);
            }

            else
            {
                throw new ArgumentException(nameof(numbers), "Not correct format ISBN");
            }
        }

        /// <summary>
        /// Method check validate price. Price can not be less zero.
        /// </summary>
        /// <param name="price"></param>
        private void ValidatePrice(double price)
        {
            if (price < 0)
            {
                throw new ArgumentException(nameof(price));
            }
        }

        /// <summary>
        /// Method check validate currency. Currency can not be null.
        /// </summary>
        /// <param name="price"></param>
        public void ValidateCurrency(string currency)
        {
            if (currency == null)
            {
                throw new ArgumentNullException(nameof(currency));
            }
        }

        /// <summary>
        /// Method check validate data. Data can not be null.
        /// </summary>
        /// <param name="price"></param>
        public void ValidateData(DateTime? data)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
        }

        /// <summary>
        /// Equal book.
        /// </summary>
        /// <param name="obj">Time obj.</param>
        /// <returns>Bool check result.</returns>
        public override bool Equals(object obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != this.GetType())
            {
                return false;
            }
            else
            {
                return this.Equals((Book)obj);
            }
        }

        /// <summary>
        /// Equal book.
        /// </summary>
        /// <param name="other">Time obj.</param>
        /// <returns>Bool check result.</returns>
        public bool Equals(Book other)
        {
            if (this.ISBN == other.ISBN)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// HashCode Book.
        /// </summary>
        /// <returns>Hash code book.</returns>
        public override int GetHashCode()
        {
            int hashCode = this.ISBN.GetHashCode();

            return hashCode;
        }

        /// <summary>
        /// Method CompareTo.
        /// </summary>
        /// <param name="other">other.</param>
        /// <returns>Integer result value.</returns>
        public int CompareTo(Book other)
        {
            if (this.Title.Length == other.Title.Length)
                return 0;
            if (this.Title.Length < other.Title.Length)
                return -1;
            else
                return 1;
        }

        /// <summary>
        /// Method CompareTo.
        /// </summary>
        /// <param name="obj">obj.</param>
        /// <returns>Integer result value.</returns>
        public int CompareTo(object obj)
        {
            if (!(obj is Book))
            {
                throw new ArgumentException("not Time ", nameof(obj));
            }

            return this.CompareTo((Book)obj);
        }
    }

}
