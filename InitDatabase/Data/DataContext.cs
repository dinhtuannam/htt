using Microsoft.EntityFrameworkCore;
using System;

namespace InitDatabase.Data
{
    public class DataContext : DbContext
    {
        public static Random random = new Random();
        public DbSet<SqlAction>? actions { get; set; }
        public DbSet<SqlCategory>? categories { get; set; }
        public DbSet<SqlDetailOrder>? detailOrder { get; set; }
        public DbSet<SqlInvoice>? invoices { get; set; }
        public DbSet<SqlLogTable>? logTable { get; set; }
        public DbSet<SqlMenuItem>? menuItems { get; set; }
        public DbSet<SqlMenuItemStatus>? menuItemStatus { get; set; }
        public DbSet<SqlOrder>? orders { get; set; }
        public DbSet<SqlRole>? roles { get; set; }
        public DbSet<SqlTable>? tables { get; set; }
        public DbSet<SqlTableStatus>? tableStatus { get; set; }
        public DbSet<SqlUser>? users { get; set; }
        public DbSet<SqlDiscount>? discounts { get; set; }
        public DbSet<SqlIngredient>? ingredients { get; set; }
        public DbSet<SqlRecipe>? recipes { get; set; }
        public DbSet<SqlDetailRecipe>? detailRecipe { get; set; }

        public static string configSql = "Host=dpg-co1flb6ct0pc73dbnh5g-a.singapore-postgres.render.com:5432;Database=restaurant_management_a76y;Username=nam;Password=ii7c7AQD68CDzEpUgfU7rERpBfReKfHs";

        public static string randomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(s => s[random.Next(s.Length)]).ToArray());
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql(configSql);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
