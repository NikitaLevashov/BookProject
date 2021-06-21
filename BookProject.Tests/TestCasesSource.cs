using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.Tests
{
    internal class TestCasesSource
    {
        public static IEnumerable<TestCaseData> TestCasesForEquals
        {
            get
            {
                yield return new TestCaseData(new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"), new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title232", "Rosman1212", "0-306-40615-2"), new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title12323", "Rosman", "978-1734314502"), new Book("Pushkin123", "Title1", "Rosman", "978-1734314502"));
                yield return new TestCaseData(new Book("Pushkin", "Title1", "Rosman1212", "978-1734314502"), new Book("Pushkin1212", "Title1", "Rosman", "978-1734314502"));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForEqualsTitle
        {
            get
            {
                yield return new TestCaseData(new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"), new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title23", "Rosman1212", "0-306-40615-2"), new Book("Pushkin", "Title12", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title12323", "Rosman", "978-1734314502"), new Book("Pushkin123", "Title12345", "Rosman", "978-1734314502"));
                yield return new TestCaseData(new Book("Pushkin", "Title12", "Rosman1212", "978-1734314502"), new Book("Pushkin1212", "Title12", "Rosman", "978-1734314502"));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForNotEquals
        {
            get
            {
                yield return new TestCaseData(new Book("Pushkin12", "Title1", "Rosman", "0-306-40615-2"), new Book("Pushkin", "Title1", "Rosman", "978-1734314502"));
                yield return new TestCaseData(new Book("Pushkin12", "Title1", "Rosman12", "978-1734314502"), new Book("Pushkin", "Title1", "Rosman121", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title12", "Rosman1212", "0-306-40615-2"), new Book("Pushkin", "Title1", "Rosman12", "978-1734314502"));
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title1", "Rosman", "0-306-40615-2"));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForCompareToLessZero
        {
            get
            {
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title112", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title112", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title112", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title112", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title13", "Rosman", "978-1734314502"), new Book("Pushkin", "Title112", "Rosman", "0-306-40615-2"));
            }
        }

        public static IEnumerable<TestCaseData> TestCasesForCompareToMoreZero
        {
            get
            {
                yield return new TestCaseData(new Book("Pushkin", "Title131", "Rosman", "978-1734314502"), new Book("Pushkin", "Title12", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title131", "Rosman", "978-1734314502"), new Book("Pushkin", "Title13", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title131", "Rosman", "978-1734314502"), new Book("Pushkin", "Title14", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title131", "Rosman", "978-1734314502"), new Book("Pushkin", "Title11", "Rosman", "0-306-40615-2"));
                yield return new TestCaseData(new Book("Pushkin", "Title131", "Rosman", "978-1734314502"), new Book("Pushkin", "Title11", "Rosman", "0-306-40615-2"));
            }
        }
    }

}
