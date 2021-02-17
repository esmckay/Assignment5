using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Creates an iqueryable for Book in Books
namespace Assignment5.Models
{
    public interface IBookRepository
    {
        IQueryable<Book> Books { get; }
    }
}
