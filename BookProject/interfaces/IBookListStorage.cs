using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookProject.interfaces
{
    public interface IBookListStorage
    {
        /// <summary>
        /// Save books to the container.
        /// </summary>
        /// <param name="books">book.</param>
        void Save(List<Book> books);

        /// <summary>
        /// Load books to the container.
        /// </summary>
        /// <returns>List of loaded books.</returns>
        List<Book> Load();
    }
}
