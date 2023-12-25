using BlazorApp.Shared.Entityes;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace BlazorApp.Server
{
    public partial class Context : DbContext
    {

        public Context(DbContextOptions<Context> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("userdetails");
                entity.Property(e => e.Userid).HasColumnName("Userid");
                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Address)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Cellnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                entity.Property(e => e.Emailid)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
