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
        [Required]
        public int BookID { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string AuthorFirst { get; set; }
        public string? AuthorMiddle { get; set; } = "";
        [Required]
        public string AuthorLast { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required]
        [RegularExpression(@"^\d{3}-\d{10}$", ErrorMessage = "Invalid IBN")]
        public string ISBN { get; set; }
        [Required]
        public string Category {get; set;}
        [Required]
        public double Price { get; set; }
        [Required]
        public int NumPages { get; set; }

    }
}
