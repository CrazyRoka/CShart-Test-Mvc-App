using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MenuPlaner.Models
{
    public class MenuCardsContext : DbContext
    {
        public MenuCardsContext(DbContextOptions<MenuCardsContext> options) : base(options)
        {
        }

        public DbSet<Menu> Menus { get; set; }
        public DbSet<MenuCard> MenuCards { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>().Property(m => m.Text)
                .HasMaxLength(50).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
