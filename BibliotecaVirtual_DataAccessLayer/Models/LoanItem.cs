using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual_DataAccessLayer.Models
{
    public class LoanItem
    {
        //Properties
        public int Id { get; set; }
        public int Amount { get; set; }

        //Relationship
        public int BookId { get; set; }
        public Book Books { get; set; }
        public int LoanId { get; set; }
        public Loan Loans { get; set; }

    }
}
