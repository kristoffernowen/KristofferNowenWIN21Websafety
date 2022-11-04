using Microsoft.EntityFrameworkCore;
using WebSafetyExam2.Entities;

namespace WebSafetyExam2
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }

        public DbSet<BlogEntity> Blog { get; set; }
    }
}
