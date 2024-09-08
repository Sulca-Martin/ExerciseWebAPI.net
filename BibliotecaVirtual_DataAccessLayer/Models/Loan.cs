using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual_DataAccessLayer.Models
{
    public class Loan
    {
        //Properties
        public int Id { get; set; }
        public string LoanNumber {get; set;}
        public DateTime LoanDate { get; set; }
        //public DateTime? ReturnDate { get; set; }
        public string? Description { get; set; }

        //Relationships
        public int UserId { get; set; }
        public User Users { get; set; }
        public int ReturnDateId { get; set; }
        public ReturnDate ReturnDates { get; set; }
        public List<LoanItem> LoanItems { get; set; }

        //Builder
        public Loan() { }
    }
}
