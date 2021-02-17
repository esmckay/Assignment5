using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


//Book class to get and set the necessary fields. As well as setting BookID as they key and making sure the IBSN is correct
namespace Assignment5.Models
{
    public class Book
    {
        [Key]
        public int BookID { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "Invalid IBN")]
        public string ISBN { get; set; }
        public string Category {get; set;}
        public string Price { get; set; }
    }
}
