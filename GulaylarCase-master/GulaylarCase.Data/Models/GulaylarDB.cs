using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GulaylarCase.Data.Models
{
    public class GulaylarDb : DbContext
    {
        public GulaylarDb() : base("name=GulaylarDB")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Course> Course { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Subscribe> Subscribe { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<WatchHistory> WatchHistory { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();




            modelBuilder.Entity<Course>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Slug)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .Property(e => e.VideoUrl)
                .IsUnicode(false);

            modelBuilder.Entity<Course>()
                .HasMany(e => e.Subscribe)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Course>()
                .HasMany(e => e.WatchHistory)
                .WithOptional(e => e.Course)
                .HasForeignKey(e => e.CourseId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<Role>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Role>()
                .HasMany(e => e.User)
                .WithOptional(e => e.Role)
                .HasForeignKey(e => e.RoleId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.LastName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .HasMany(e => e.Subscribe)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();

            modelBuilder.Entity<User>()
                .HasMany(e => e.WatchHistory)
                .WithOptional(e => e.User)
                .HasForeignKey(e => e.UserId)
                .WillCascadeOnDelete();
        }
    }
}
