using BookProject.interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace BookProject.Tests
{
    public class Tests
    {
        private readonly Book book = new Book("Nikita", "C# forever book", "Main  publisher", "978-1734314502");
        private readonly Book book1 = new Book("Misha", "F# book", "Main  publisher", "0-306-40615-2");
        private readonly Book book2 = new Book("Alex", "F# Skitt", "Main  publisher", "0-306-40615-2");

        /// <summary>
        /// Check method ToString with correct parametres.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void ToString_WithCorrectProperty_ReturnInfoAboutBook()
        {
            Assert.That(this.book.ToString(), Is.EqualTo(" C# forever book by Nikita "));
        }

        /// <summary>
        /// Check method ToString with correct parametres.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void ToString2_WithCorrectProperty_ReturnInfoAboutBook()
        {
            Assert.That(this.book1.ToString(), Is.EqualTo(" F# book by Misha "));
        }

        /// <summary>
        /// Check method ToString with authoe equal null.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void ToString3_WithCorrectProperty_ReturnInfoAboutBook()
        {
            Assert.That(this.book2.ToString(), Is.EqualTo(" F# Skitt by Alex "));
        }

        /// <summary>
        /// The method checks the result for if string parameter equal ISBN 13 value.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void IsIsbnValid_InputStringValueISBN13_ReturnTrue()
        {
            var result = new Book("1212", "1212", "1212").IsIsbnValid("978-1734314502");

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The method checks the result for if string parameter equal ISBN 10 value.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void IsIsbnValid_InputStringValueISBN10_ReturnTrue()
        {
            var result = new Book("1212", "1212", "1212").IsIsbnValid("0-306-40615-2");

            Assert.IsTrue(result);
        }

        /// <summary>
        /// The method checks the result for if price less 0.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void SetPrice_CrateWithNegativePrice_ThrowArgumentException()
        => Assert.Throws<ArgumentException>(() => new Book("Nikita", "C# forever", "Main  publisher", "0-306-40615-8").SetPrice(-232, "US"));

        /// <summary>
        /// The method checks the result for if currency equal null.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void SetPrice_CrateWithCurrencyNull_ThrowArgumentException()
        => Assert.Throws<ArgumentNullException>(() => new Book("Nikita", "C# forever", "Main  publisher", "0-306-40615-2").SetPrice(232, null));

        /// <summary>
        /// Check method SetPrece with correct parameters.
        /// </summary>
        /// <param name="price"> Price.</param>
        /// <param name="currency"> Currency.</param>
        /// <returns> Info about price.</returns>
        [TestCase(12.1, "USD", ExpectedResult = "Price: 12,1, Currency: USD")]
        [TestCase(513.3, "BLR", ExpectedResult = "Price: 513,3, Currency: BLR")]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public string SetPrice_WithCorrectParameters_ReturnInfo(double price, string currency)
           => new Book("qwqw", "2323", "1212").SetPrice(price, currency);

        /// <summary>
        /// Check method SetPrice with correct data parameter.
        /// </summary>
        /// <param name="data">Data.</param>
        /// <returns>Info about published.</returns>
        [TestCase("2012-1-20", ExpectedResult = "Published: True - 20.01.2012 0:00:00")]
        [TestCase("2018-4-20", ExpectedResult = "Published: True - 20.04.2018 0:00:00")]
        [TestCase("2011-1-26", ExpectedResult = "Published: True - 26.01.2011 0:00:00")]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public string Publish_WithCorrectParameter_ReturnInfo(DateTime data)
           => new Book("qwqw", "2323", "1212").Publish(data);

        /// <summary>
        /// The method checks the result for if price less 0.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void Publish_CrateWithDataNull_ThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new Book("Nikita", "C# forever", "Main  publisher", "0-306-40615-2").Publish(null));

        /// <summary>
        /// The method checks the result for if price less 0.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void SetPrice_CrateWithNegative_ThrowArgumentException()
        => Assert.Throws<ArgumentException>(() => new Book("Nikita", "C# forever", "Main  publisher", "0-306-40615-8").SetPrice(-232, "US"));

        /// <summary>
        /// Check method ToString with correct parametres.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void SetPrice_WithCorrectProperty_ReturnInfoAboutPrice()
        {
            Assert.That(this.book.SetPrice(12.2, "USA"), Is.EqualTo("Price: 12,2, Currency: USA"));
        }

        /// <summary>
        /// Method check with ISBN equal null.
        /// </summary>
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        [Test]
        public void BooksTest_CreateWithNullISBN_ThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new Book("sss", "sdsd", "abc", null));

        /// <summary>
        /// Method check with ISBN equal empty.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithEmptyISBN_ThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new Book("sss", "sdsd", "abc", string.Empty));

        /// <summary>
        /// Method check with not correct format ISBN.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithNotCorrectISBN_ThrowArgumentException()
        => Assert.Throws<ArgumentException>(() => new Book("sss", "sdsd", "abc", "1212122211"));

        /// <summary>
        /// Method check with author equal null.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithAuthurNull_ThrowArgumentNullException()
        => Assert.Throws<ArgumentNullException>(() => new Book(null, "sdsd", "abc", "1212122211"));

        /// <summary>
        /// Method check with title equal null.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithTitleNull_ThrowArgumentNullException()
       => Assert.Throws<ArgumentNullException>(() => new Book("asasa", null, "abc", "1212122211"));

        /// <summary>
        /// Method check with publisher equal null.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithPublisherNull_ThrowArgumentNullException()
       => Assert.Throws<ArgumentNullException>(() => new Book("sdsd", "sdsd", null, "1212122211"));

        /// <summary>
        /// Check method GetPublicationDate with parameter equal false.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void GetPublicationDate_WithDataEqualFalse_ReturnNYP()
        {
            Assert.That(this.book.GetPublicationDate(false), Is.EqualTo("NYP"));
        }

        /// <summary>
        /// Check method GetPublicationDate with parameter equal true.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void GetPublicationDate_WithDataEqualTrue_ReturnData()
        {
            Assert.That(this.book.GetPublicationDate(true), Is.EqualTo("12.12.2010 0:00:00"));
        }

        /// <summary>
        /// Method check with Pages equal zero.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithPagesEqualZero_ThrowArgumentNullException1()
       => Assert.Throws<ArgumentException>(() => this.book.Pages = 0);

        /// <summary>
        /// Method check with Pages equal int.MinValue.
        /// </summary>
        [Test]
        [SuppressMessage("Naming", "CA1707:Identifiers should not contain underscores", Justification = "Unit test name")]
        public void BooksTest_CreateWithPagesEqualIntMinValue_ThrowArgumentNullException1()
       => Assert.Throws<ArgumentException>(() => this.book.Pages = int.MinValue);

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForEquals))]
        public void ObjectEquals_ForEqualValues_ReturnTrue(Book lhs, object rhs)
        {
            Assert.IsTrue(lhs.Equals(rhs));
        }

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForNotEquals))]
        public void ObjectEquals_ForDifferentValues_ReturnFalse(Book lhs, object rhs)
        {
            Assert.IsTrue(!lhs.Equals(rhs));
        }

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForEquals))]
        public void GetHashCode_ForEqualValues_ReturnEqualCode(Book lhs, Book rhs)
        {
            Assert.IsTrue(lhs.Equals(rhs) && lhs.GetHashCode() == rhs.GetHashCode());
        }

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCompareToLessZero))]
        public void NotGenericCompareTo_LeftHandSideOperandLessThanRightHandSideOperand_ReturnIntegerLessZero(Book lhs,
       object rhs)
        {
            Assert.IsTrue(((IComparable)lhs).CompareTo(rhs) < 0);
        }

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForCompareToMoreZero))]
        public void NotGenericCompareTo_LeftHandSideOperandMoreThanRightHandSideOperand_ReturnTrue(Book lhs, object rhs)
        {
            Assert.IsTrue(((IComparable)lhs).CompareTo(rhs) > 0);
        }

        [Test, TestCaseSource(typeof(TestCasesSource), nameof(TestCasesSource.TestCasesForEqualsTitle))]
        public void NotGenericCompareTo_LeftHandSideOperandIsEqualToRightHandSideOperand_ReturnZero(Book lhs, Book rhs)
        {
            IComparable comparable = lhs;
            object obj = rhs;
            Assert.IsTrue(comparable.CompareTo(obj) == 0);
        }

        [Test]
        public void Tests_ToLoad_LoadBook_()
        {
            List<Book> fakeList = new List<Book> { book1, book, book2 };
            FakeBookListStorage fake = new FakeBookListStorage(fakeList);
            var listLoad = fake.Load();
    
            Assert.AreEqual(listLoad, fakeList);
        }

        [Test]
        public void Tests_ToSave_SaveBook_()
        {
            List<Book> fakeList = new List<Book> { book1, book, book2 };
            FakeBookListStorage fake = new FakeBookListStorage(fakeList);
            fake.Save(fakeList);

            var excpected = 6;

            Assert.AreEqual(fakeList.Count, excpected);
        }

        [Test]
        public void Add_WithRepetitiveBook_ThrowArgumentException()
        {
            BookListService service = new BookListService(book1, book, book2);
              Assert.Throws<ArgumentException>(() => service.Add(book));
        }


        [Test]
        public void Tests_AddNewBook()
        {
            BookListService service = new BookListService(book1, book2);
            service.Add(book);

            var excpected = 3;

            Assert.AreEqual(service.Books.Count, excpected);
        }

        [Test]
        public void Tests_RemoveBook()
        {
            BookListService service = new BookListService(book1, book2, book);
            service.Remove(book);

            var excpected = 2;

            Assert.AreEqual(service.Books.Count, excpected);
        }

        [Test]
        public void Tests_SortBook()
        {
            BookListService service = new BookListService(book1, book, book2);
            List<Book> list = new List<Book>() { book1, book2, book };
            service.Sort();

            CollectionAssert.AreEqual(list, service.Books);
        }

        [Test]
        public void Tests_FindByTag_ByTitle()
        {
            BookListService service = new BookListService(book1, book, book2);
            var resultBool = new TitleTags("C# forever book").Contain(book);
            var excpected = true;

            Assert.AreEqual(excpected, resultBool);
        }

        [Test]
        public void Tests_FindByTag_ByAuthor()
        {
            BookListService service = new BookListService(book1, book, book2);
            var resultBool = new AuthorTags("Alex").Contain(book2);
            var excpected = true;

            Assert.AreEqual(excpected, resultBool);
        }

        [Test]
        public void Tests_FindByTag_ByIsbn()
        {
            BookListService service = new BookListService(book1, book, book2);
            var resultBool = new IsbnTags("0-306-40615-2").Contain(book2);
            var excpected = true;

            Assert.AreEqual(excpected, resultBool);
        }


        private Mock<IBookListStorage> mock;

        [OneTimeSetUp]
        public void SetUp()
        {
            mock = new Mock<IBookListStorage>();
        }

        [Test]
        public void LoadListBookOnceTime()
        {
            mock.Setup(provider => provider.Load());               

            IBookListStorage provider = mock.Object;

            var transformer = new BookListService(book1, book2);

            transformer.Load(provider);

            mock.Verify(transformer => transformer.Load(), Times.Once());
        }

        [Test]
        public void SaveListBookOnceTime()
        {
            mock.Setup(provider => provider.Save(It.IsAny<List<Book>>()));

            IBookListStorage provider = mock.Object;

            var transformer = new BookListService(book1, book2);

            transformer.Save(provider);

            mock.Verify(transformer => transformer.Save(It.IsAny<List<Book>>()), Times.Once());
        }


    }
}