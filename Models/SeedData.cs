﻿using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment5.Models
{
    public class SeedData
    {
        //Checks to see if there are any entries and if not then we add some in for them
        public static void EnsurePopulated(IApplicationBuilder application)
        {
            FavBooksContext context = application.ApplicationServices.
                CreateScope().ServiceProvider.GetRequiredService<FavBooksContext>();

            if (context.Database.GetPendingMigrations().Any())
            {
                context.Database.Migrate();
            }
            if(!context.Books.Any())
            {
                context.Books.AddRange(

                    new Book
                    {
                        Title = "Les Miserables",
                        AuthorFirst = "Victor",
                        AuthorLast = "Hugo",
                        Publisher = "Signet",
                        ISBN = "978-0451419439",
                        Category = "Fiction, Classic",
                        Price = 9.95,
                        NumPages = 1488
                        
                    },

                    new Book
                    {
                        Title = "Team of Rivals",
                        AuthorFirst = "Doris",
                        AuthorMiddle = "Kearns ",
                        AuthorLast = "Goodwin",
                        Publisher = "Simon & Schuster",
                        ISBN = "978-0743270755",
                        Category = "Non-Fiction, Biography",
                        Price = 14.58,
                        NumPages = 944
                        
                    },

                    new Book
                    {
                        Title = "The Snowball",
                        AuthorFirst = "Alice",
                        AuthorLast = "Schroeder",
                        Publisher = "Bantam",
                        ISBN = "978-0553384611",
                        Category = "Non-Fiction, Biography",
                        Price = 21.54,
                        NumPages = 832
                    },

                    new Book
                    {
                        Title = "American Ulysses",
                        AuthorFirst = "Ronald",
                        AuthorMiddle = "C. ",
                        AuthorLast = " White",
                        Publisher = "Random House",
                        ISBN = "978-0812981254",
                        Category = "Non-Fiction, Biography",
                        Price = 11.61,
                        NumPages = 864
                    },

                    new Book
                    {
                        Title = "Unbroken",
                        AuthorFirst = "Laura",
                        AuthorLast = "Hillenbrand",
                        Publisher = "Random House",
                        ISBN = "978-0812974492",
                        Category = "Non-Fiction, Historical",
                        Price = 13.33,
                        NumPages = 528
                    },

                    new Book
                    {
                        Title = "The Great Train Robbery",
                        AuthorFirst = "Michael",
                        AuthorLast = "Crinton",
                        Publisher = "Vintage",
                        ISBN = "978-0804171281",
                        Category = "Fiction, Historical Fiction",
                        Price = 15.95,
                        NumPages = 288
                    },

                    new Book
                    {
                        Title = "Deep Work",
                        AuthorFirst = "Cal",
                        AuthorLast = "Newport",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455586691",
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99,
                        NumPages = 304
                    },

                    new Book
                    {
                        Title = "It's Your Ship",
                        AuthorFirst = "Michael",
                        AuthorLast = "Abrashoff",
                        Publisher = "Grand Central Publishing",
                        ISBN = "978-1455523023",
                        Category = "Non-Fiction, Self-Help",
                        Price = 14.99,
                        NumPages = 240
                    },

                    new Book
                    {
                        Title = "The Virgin Way",
                        AuthorFirst = "Richard",
                        AuthorLast = "Branson",
                        Publisher = "Portfolio",
                        ISBN = "978-1591847984",
                        Category = "Non-Fiction, Business",
                        Price = 29.16,
                        NumPages = 400
                    },

                    new Book
                    {
                        Title = "Sycamore Row",
                        AuthorFirst = "John",
                        AuthorLast = "Grisham",
                        Publisher = "Bantam",
                        ISBN = "978-0553393613",
                        Category = "Fiction, Thrillers",
                        Price = 15.03,
                        NumPages = 642
                    },

                    new Book
                    {
                        Title = "Eragon",
                        AuthorFirst = "Christopher",
                        AuthorLast = "Paolini",
                        Publisher = "Knopf",
                        ISBN = "978-0375826696",
                        Category = "Fiction",
                        Price = 6.77,
                        NumPages = 528
                    },

                    new Book
                    {
                        Title = "One up on Wall Street",
                        AuthorFirst = "Peter",
                        AuthorLast = "Lynch",
                        Publisher = "Penguin Books",
                        ISBN = "978-0140127928",
                        Category = "Non-Fiction",
                        Price = 33.96,
                        NumPages = 320
                    },

                    new Book
                    {
                        Title = "Harry Potter and the Deathly Hallows",
                        AuthorFirst = "J.K.",
                        AuthorLast = "Rowling",
                        Publisher = "Pottermore Publishing",
                        ISBN = "978-0545010221",
                        Category = "Fiction",
                        Price = 13.86,
                        NumPages = 784
                    }

                    );

                context.SaveChanges();
            }
        }
    }
}
