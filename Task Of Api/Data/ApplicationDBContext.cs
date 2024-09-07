using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using Task_Of_Api.Model;

namespace Task_Of_Api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> option) : base(option) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<InvoiceDetails>()
            .HasOne(U => U.Unit);
            
        }

       public  DbSet<InvoiceDetails> invoiceDetails { get; set; }
       public  DbSet<Unit> Units { get; set; }

    }

   
}
