using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tennis.DAL.Models;
using Tennis.DAL.Models.Inteface;

namespace Tennis.DAL.Context
{
    public class TennisContext : DbContext
    {
        public DbSet<Fine> Fines { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<GameResult> GameResults { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<League> Leagues { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<MemberRole> memberRoles { get; set; }
        public DbSet<Role> Roles { get; set; }

        public TennisContext() : base() { }
        public TennisContext(DbContextOptions<TennisContext> options) : base(options) { }

        public override int SaveChanges()
        {
            ChangeTracker.DetectChanges();

            var markedAsDeleted = ChangeTracker.Entries().Where(x => x.State == EntityState.Deleted);

            foreach (var item in markedAsDeleted)
            {
                if (item.Entity is IIsDeleted entity)
                {
                    item.State = EntityState.Unchanged;
                    entity.IsDeleted = true;
                }
            }
            return base.SaveChanges();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
