using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//Inherits from the base DbContext stuff
namespace Assignment5.Models
{
    public class FavBooksContext : DbContext
    {
        public FavBooksContext(DbContextOptions<FavBooksContext> options) : base (options)
        {

        }

        public DbSet<Book> Books { get; set; }
    }
}
