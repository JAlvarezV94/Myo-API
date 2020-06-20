using Microsoft.EntityFrameworkCore;

namespace Myo.Models{

    public class MyoContext: DbContext{

        public MyoContext(DbContextOptions<MyoContext> options)
        :base(options)
        {}

        public DbSet<User> Users { get; set; }
        public DbSet<Myo> Myos { get; set; }
        public DbSet<Checkpoint> Checkpoints { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
            .HasMany(u => u.MyoList)
            .WithOne(m => m.Owner);

            modelBuilder.Entity<Myo>()
            .HasOne(m => m.Owner)
            .WithMany(u => u.MyoList);

            modelBuilder.Entity<Checkpoint>()
            .HasOne(m => m.Myo)
            .WithMany(c => c.CheckpointList)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}