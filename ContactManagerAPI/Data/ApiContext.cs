using Microsoft.EntityFrameworkCore;
using ContactManagerAPI.Models;

namespace ContactManagerAPI.Data
{
    public class ApiContext : DbContext
    {

        public DbSet<Contact> Contacts { get; set; }

        public ApiContext(DbContextOptions<ApiContext> options)
            : base(options) { }

    }
}
