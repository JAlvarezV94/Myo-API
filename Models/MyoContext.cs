using Microsoft.EntityFrameworkCore;

namespace Myo.Models{

    public class MyoContext: DbContext{

        public MyoContext(DbContextOptions optionsBuilder)
        :base(optionsBuilder)
        {}

        public DbSet<User> Users { get; set; }

    }
}