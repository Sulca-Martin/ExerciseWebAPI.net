using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual_DataAccessLayer.Models
{
    public class User
    {
        //Properties
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Docket { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        //Relationships
        //public List<Loan> Loans { get; set; }

        //Builder
        public User() { }

    }
}
