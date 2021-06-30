using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.interfaces
{
    /// <summary>
    /// interface IBookListStrorage
    /// </summary>
    public interface IBookListStorage
    {
        /// <summary>
        /// Save books to the container.
        /// </summary>
        /// <param name="books">book.</param>
        void Save(IEnumerable<Book> books);

        /// <summary>
        /// Load books to the container.
        /// </summary>
        /// <returns>Enumerable source of loaded books.</returns>
        IEnumerable<Book> Load();
    }
}
