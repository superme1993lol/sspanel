using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.admin
{
    public partial class stadminContext : DbContext
    {
        string sqlurl;
        public stadminContext(string su)
        {
            sqlurl = su;
        }

        public stadminContext(DbContextOptions<stadminContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Admininfo> Admininfo { get; set; }
        public virtual DbSet<Childsystem> Childsystem { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL(sqlurl);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admininfo>(entity =>
            {
                entity.ToTable("admininfo");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Childsystem>(entity =>
            {
                entity.ToTable("childsystem");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasColumnName("CName")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SqlurlSs)
                    .HasColumnName("SqlurlSS")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SqlurlWeb)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
