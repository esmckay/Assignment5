using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//EF Repository that does something for us. Gets context from our FavBooksContext and sets the public context = to the _context
namespace Assignment5.Models
{
    public class EFBookRepository : IBookRepository
    {
        private FavBooksContext _context;

        public EFBookRepository(FavBooksContext context)
        {
            _context = context;
        }

        public IQueryable<Book> Books => _context.Books;

        public void CreateBook(Book b)
        {
            _context.Add(b);
            _context.SaveChanges();
        }
        public void DeleteBook(Book b)
        {
            _context.Remove(b);
            _context.SaveChanges();
        }
        public void SaveBook(Book b)
        {
            _context.SaveChanges();
        }
    }
}
