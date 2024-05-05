using System.Data.Entity;

namespace WindowsFormsApp1
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DbConnection") { }
        public DbSet<User> Users { get; set; }
    }

}
