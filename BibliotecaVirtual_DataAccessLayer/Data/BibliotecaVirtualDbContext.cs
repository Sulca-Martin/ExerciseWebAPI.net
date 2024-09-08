using BibliotecaVirtual_DataAccessLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaVirtual_DataAccessLayer.Data
{
    public class BibliotecaVirtualDbContext: DbContext
    {
        public BibliotecaVirtualDbContext(DbContextOptions<BibliotecaVirtualDbContext> options) : base(options) 
        { 
        
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Loan> Loans { get; set; }
        public DbSet<LoanItem> loanItems { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Category> Categorys { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseSqlServer(
        }
    }
}
