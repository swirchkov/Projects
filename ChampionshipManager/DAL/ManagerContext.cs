using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Models;
using System.Data.Common;

namespace DAL
{
    public class ManagerContext : DbContext
    {
        // public for migrations
        public ManagerContext() : base("name=defaultConnection")
        {
        }
        private ManagerContext(DbConnection connection) : base(connection, true)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Tournament> Tournaments { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<AuthehticationToken> Tokens { get; set; }
        public DbSet<ParticipateRequest> ParticipateRequests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Primary Keys
            modelBuilder.Entity<User>().HasKey(user => user.Id);
            modelBuilder.Entity<Tournament>().HasKey(tour => tour.Id);
            modelBuilder.Entity<Game>().HasKey(game => game.Id);
            modelBuilder.Entity<AuthehticationToken>().HasKey(t => t.Id);
            modelBuilder.Entity<ParticipateRequest>().HasKey(req => req.Id);

            // Foreign Keys
            modelBuilder.Entity<User>().HasMany(user => user.Tournaments).WithMany(tournament => tournament.Participates);
            modelBuilder.Entity<Tournament>().HasMany(t => t.Games).WithRequired(game => game.Tournament);
            modelBuilder.Entity<Game>().HasMany(game => game.Competitors).WithMany(user => user.Games);
            modelBuilder.Entity<AuthehticationToken>().HasRequired(t => t.User).WithMany(u => u.Tokens);
            modelBuilder.Entity<ParticipateRequest>().HasRequired(req => req.User).WithMany(u => u.ParticipateRequests);
            modelBuilder.Entity<ParticipateRequest>().HasRequired(req => req.Tournament).WithMany(t => t.ParticipateRequests);

            base.OnModelCreating(modelBuilder);
        }

        // this class must be singleton to provide correct work.
        private static ManagerContext mContext = null;
        public static ManagerContext CreateInstance()
        {
            if (mContext == null)
            {
                mContext = new ManagerContext();
            }

            return mContext;
        }
        public static ManagerContext CreateInstance(DbConnection connection)
        {
            mContext = new ManagerContext(connection);
            return mContext;
        }
    }
}
