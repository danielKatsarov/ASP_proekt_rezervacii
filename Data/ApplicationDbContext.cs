using ASP_Reservacii_3_pr.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ASP_Reservacii_3_pr.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<DiningTable> Tables { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
    }
}
