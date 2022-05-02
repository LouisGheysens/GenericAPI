using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class SchoolDbContext: DbContext
    {
        public SchoolDbContext()
        {

        }

        public DbSet<Student> Students { get; set; }

        public DbSet<Teacher> Teachers { get; set; }
    }
}