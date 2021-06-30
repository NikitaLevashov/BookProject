using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.interfaces
{
    public interface IFindByTag
    {
        /// <summary>
        /// Check if the book match the specified value of the field.
        /// </summary>
        /// <param name="book">The book to be checked.</param>
        /// <returns>True, if the book match; otherwise, false.</returns>
        bool IsMatch(Book book);
    }
}
