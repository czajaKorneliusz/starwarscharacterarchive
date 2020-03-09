using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StarWarsCharacterArchive.Models;
using System;
using System.Collections.Generic;

namespace StarWarsCharacterArchive
{
    public class CharacterContext : DbContext
    {
        public CharacterContext()
        {

        }

        public CharacterContext(DbContextOptions options)
           : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Method intentionally left empty.
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var splitStringConverter = new ValueConverter<IEnumerable<string>, string>(v => string.Join(";", v), v => v.Split(new[] { ';' }));
            modelBuilder.Entity<Character>().Property(nameof(Character.Episodes)).HasConversion(splitStringConverter);

            modelBuilder.Entity<Friend>()
            .HasOne(a => a.Character)
            .WithMany(a => a.Friends);
        }

        public DbSet<Character> Characters { get; set; }
    }
}
