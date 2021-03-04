using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WhalesAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=whalesdb;database=whales-db;user=root;password=root");
        }

        public DbSet<Whale> Whales { get; set; }

        private readonly List<Whale> Seeder = new List<Whale>
        {
            new Whale
            {
                CommonName = "Blue whale",
                ScientificName = "Balaenoptera musculus",
                Population = "10,000–25,000",
                Size = "50–150 t "
            },
            new Whale
            {
                CommonName = "Bryde's whale",
                ScientificName = "Balaenoptera brydei",
                Population = "90,000–100,000",
                Size = "14–30 t "
            },
            new Whale
            {
                CommonName = "Common minke whale",
                ScientificName = "Balaenoptera acutorostrata",
                Population = "200,000",
                Size = "2–4 t "
            },
            new Whale
            {
                CommonName = "Fin whale",
                ScientificName = "Balaenoptera physalus",
                Population = "100,000",
                Size = "30–80 t "
            },
            new Whale
            {
                CommonName = "Bowhead whale",
                ScientificName = "Balaena mysticetus",
                Population = "12,682–39,950",
                Size = "60 t"
            }
        };

        public IEnumerable<Whale> GetAllWhales()
        {
            return Whales.ToList();
        }

        public IEnumerable<Whale> AddRandom()
        {
            Random rnd = new Random();
            int r = rnd.Next(Seeder.Count);

            Whales.Add(Seeder[r]);
            SaveChanges();
            return Whales.ToList();
        }

        public void RemoveAll()
        {
            Whales.RemoveRange(Whales);
            SaveChanges();
        }

        public IEnumerable<Whale> Seed()
        {
            Whales.AddRange(Seeder);
            SaveChanges();
            return Whales.ToList();
        }
    }
}
