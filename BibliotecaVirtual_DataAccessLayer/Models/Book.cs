using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BibliotecaVirtual_DataAccessLayer.Models
{
    public class Book
    {
        //Properties
        public int Id { get; set; }
        public string Title { get; set; }
        public string? Synopsis { get; set; }
        public int Amount { get; set; }
        public DateTime PublicationDate { get; set; }

        //Relationships
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }

        //Builder
        public Book() { }

    }
}
