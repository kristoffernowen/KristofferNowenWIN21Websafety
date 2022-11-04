using Microsoft.EntityFrameworkCore;
using WebSafeExam1.Entities;

namespace WebSafeExam1
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext>  options) : base(options)
        {
        }

        public DbSet<BlogEntity> Blog { get; set; }
    }
}
