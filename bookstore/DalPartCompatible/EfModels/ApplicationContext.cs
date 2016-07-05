namespace DalPart
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using DalPart.Models;

    public partial class ApplicationContext : DbContext
    {
        public ApplicationContext()
            : base("name=ApplicationContext")
        {
        }

        public ApplicationContext(string connection) : base(connection)
        {
        }

        public virtual DbSet<C__EFMigrationsHistory> C__EFMigrationsHistory { get; set; }
        public virtual DbSet<AspNetRoleClaims> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetRoles> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaims> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogins> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUsers> AspNetUsers { get; set; }

        public DbSet<Book> Books { get; set; }
        public DbSet<Note> Notes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRoles>()
                .HasMany(e => e.AspNetRoleClaims)
                .WithOptional(e => e.AspNetRoles)
                .HasForeignKey(e => e.RoleId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserClaims)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetUserLogins)
                .WithOptional(e => e.AspNetUsers)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUsers>()
                .HasMany(e => e.AspNetRoles)
                .WithMany(e => e.AspNetUsers)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("UserId").MapRightKey("RoleId"));

            modelBuilder.Entity<AspNetUsers>().HasMany(u => u.Books).WithRequired(b => b.Author).HasForeignKey(b => b.AuthorId);

            modelBuilder.Entity<Book>().HasMany(b => b.Notes).WithRequired(n => n.Book).HasForeignKey(n => n.BookId).WillCascadeOnDelete(true);
        }

        private static ApplicationContext instance;

        public static ApplicationContext Create(string connection)
        {
            if (instance == null)
            {
                instance = new ApplicationContext(connection);
            }
            return instance ?? new ApplicationContext(connection);
        }
    }
}
