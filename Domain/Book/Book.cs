using LibraryApplication.API.Domain.User;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace LibraryApplication.API.Domain.Book
{
    public class Book
    {
        // INFO ABOUT BOOK
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; private set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string ISBN { get; set; }
        public float Price { get; set; }

        // BOOKING DETALIS
        public bool IsRent { get; set; }
        public DateOnly DateStartRent { get; set; }
        public int DaysRent { get; set; }
        // o sa fac update dupa
        //public ushort DaysRent { get; set; } // nu avem de numere foarte mari pentru zile (merge pana la 65k)
        public DateOnly DateStopRent { get; set; }

        // WHO RENTED THE BOOK
        public Guid? UserId { get; set; } = null;


        protected Book()
        {
            this.Title = string.Empty;
            this.Author = string.Empty;
            this.ISBN = string.Empty;
        }


        // Nu citim si datele de inchiriere ale cartii ca na....
        public Book(string title, string author, string isbn, float price)
        {
            this.Id = Guid.NewGuid();
            this.Title = title;
            this.Author = author;
            this.ISBN = isbn;
            this.Price = price;
        }

    }
}
