using Banking_Application.Models;
using Business.Models;
using Microsoft.EntityFrameworkCore;
using Registration.Models;

namespace Business.Data
{
    public class BusinessContext : DbContext
    {
        public BusinessContext(DbContextOptions<BusinessContext> options): base(options) { }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Busines> Businesses { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LoginRequest> loginRequests { get; set; }
    }
}
