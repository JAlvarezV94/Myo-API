using Microsoft.EntityFrameworkCore;

namespace Myo.Models{

    public class MyoContext: DbContext{

        public MyoContext(DbContextOptions<MyoContext> options)
        :base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Myo> Myos { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }
    }
}