using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Red_Social_Proyecto.Entities;

namespace Red_Social_Proyecto.Database
{
    public class TodoListDBContext : IdentityDbContext<IdentityUser>
    {
        public TodoListDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("security");

            builder.Entity<IdentityUser>().ToTable("users"); // Cambio aquí
            builder.Entity<IdentityRole>().ToTable("roles");
            builder.Entity<IdentityUserRole<string>>().ToTable("users_roles");
            builder.Entity<IdentityUserClaim<string>>().ToTable("users_claims");
            builder.Entity<IdentityUserLogin<string>>().ToTable("users_logins");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("roles_claims");
            builder.Entity<IdentityUserToken<string>>().ToTable("users_tokens");
        }

        public DbSet<UsersEntity> Users { get; set; }
        public DbSet<FollowEntity> Follows { get; set; }
        public DbSet<PublicationEntity> Publications { get; set; }
        public DbSet<InteractionEntity> Interactions { get; set; }
        public DbSet<NotificationEntity> Notifications { get; set; }
        public DbSet<CommentsEntity> Comments { get; set; }
    }
}
