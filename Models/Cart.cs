using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        public virtual void AddItem(Book book, int qty)
        {
            CartLine line = Lines
                .Where(p => p.Book.BookID == book.BookID)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = book,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        public virtual void RemoveLine(Book book) =>
            Lines.RemoveAll(x => x.Book.BookID == book.BookID);

        public virtual void Clear() => Lines.Clear();

        //This is what I need to figure out next and then the Remove function then it's good to turn in
        public decimal ComputeTotalSum() => Lines.Sum(e => Convert.ToDecimal(e.Book.Price) * e.Quantity);
        //For assignment it would be e => e.Books.Price

        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity { get; set; }
        }
    }
}
