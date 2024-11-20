using CMCS2.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CMCS2.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Claim> Claims { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Create Role GUIDs
            var superUserRoleId = Guid.NewGuid().ToString();
            var lecturerRoleId = Guid.NewGuid().ToString();
            var coordinatorRoleId = Guid.NewGuid().ToString();
            var managerRoleId = Guid.NewGuid().ToString();

            // Seed Roles with GUIDs
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole { Id = lecturerRoleId, Name = "Lecturer", NormalizedName = "LECTURER" },
                new IdentityRole { Id = coordinatorRoleId, Name = "Coordinator", NormalizedName = "COORDINATOR" },
                new IdentityRole { Id = managerRoleId, Name = "Manager", NormalizedName = "MANAGER" },
                new IdentityRole { Id = superUserRoleId, Name = "SuperUser", NormalizedName = "SUPERUSER" }
            );

            // Seed an Admin User
            var adminId = Guid.NewGuid().ToString();
            var adminUser = new ApplicationUser
            {
                Id = adminId,
                UserName = "admin@yourapp.com",
                Email = "admin@yourapp.com",
                Name = "Admin",
                Surname = "User",
                EmailConfirmed = true,
                NormalizedEmail = "ADMIN@YOURAPP.COM",
                NormalizedUserName = "ADMIN@YOURAPP.COM"
            };

            // Set password for the admin user
            var passwordHasher = new PasswordHasher<ApplicationUser>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin@123");

            // Seed the admin user
            builder.Entity<ApplicationUser>().HasData(adminUser);

            // Assign the admin user to SuperUser role using the correct RoleId (GUID)
            builder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = superUserRoleId, // Use the actual GUID for the SuperUser role
                UserId = adminId
            });
        }
    }
}
