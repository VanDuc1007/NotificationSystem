using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public class SocialMediaContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<UserFollowers> UserFollowers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // Cấu hình nhà cung cấp cơ sở dữ liệu ở đây
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-TMOCPL1\DEVDUC;Database=SocialMediaDB;Trusted_Connection=True;");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Cấu hình mối quan hệ giữa User và UserFollowers
            modelBuilder.Entity<UserFollowers>()
                .HasKey(uf => new { uf.UserId, uf.FollowerId }); // Khóa chính composite

            modelBuilder.Entity<UserFollowers>()
                .HasOne(uf => uf.User)
                .WithMany(u => u.Followers)
                .HasForeignKey(uf => uf.UserId)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.Cascade nếu muốn xóa tự động

            modelBuilder.Entity<UserFollowers>()
                .HasOne(uf => uf.Follower)
                .WithMany()
                .HasForeignKey(uf => uf.FollowerId)
                .OnDelete(DeleteBehavior.Restrict); // Hoặc DeleteBehavior.Cascade nếu muốn xóa tự động
        }
    }
}
