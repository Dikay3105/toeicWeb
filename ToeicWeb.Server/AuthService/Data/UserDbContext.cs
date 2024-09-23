using Microsoft.EntityFrameworkCore;
using ToeicWeb.Server.AuthService.Models;

namespace ToeicWeb.Server.AuthService.Data
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<RolePermission> RolePermissions { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasKey(u => u.UserID);
            modelBuilder.Entity<Role>().HasKey(r => r.RoleID);
            modelBuilder.Entity<Permission>().HasKey(p => p.PermissionID);
            modelBuilder.Entity<RolePermission>().HasKey(rp => rp.RolePermissionID);
            modelBuilder.Entity<UserRole>().HasKey(ur => ur.UserRoleID);

            modelBuilder.Entity<RolePermission>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(rp => rp.RoleID);

            modelBuilder.Entity<RolePermission>()
                .HasOne<Permission>()
                .WithMany()
                .HasForeignKey(rp => rp.PermissionID);

            modelBuilder.Entity<UserRole>()
                .HasOne<User>()
                .WithMany()
                .HasForeignKey(ur => ur.UserID);

            modelBuilder.Entity<UserRole>()
                .HasOne<Role>()
                .WithMany()
                .HasForeignKey(ur => ur.RoleID);
        }
    }
}
