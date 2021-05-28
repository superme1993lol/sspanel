using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.ssr
{
    public partial class stssrContext : DbContext
    {

        string sqlurl;

        public stssrContext(string su)
        {
            sqlurl = su;
        }
         

        public stssrContext(DbContextOptions<stssrContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> User { get; set; }

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
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PRIMARY");

                entity.ToTable("user");

                entity.HasIndex(e => e.Pid)
                    .HasName("pid")
                    .IsUnique();

                entity.HasIndex(e => e.Port)
                    .HasName("port")
                    .IsUnique();

                entity.Property(e => e.Pid)
                    .HasColumnName("pid")
                    .HasColumnType("int(11)");

                entity.Property(e => e.D)
                    .HasColumnName("d")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.Enable)
                    .HasColumnName("enable")
                    .HasColumnType("tinyint(4)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Maxspeed)
                    .HasColumnName("maxspeed")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Method)
                    .IsRequired()
                    .HasColumnName("method")
                    .HasMaxLength(64)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'aes-256-cfb'");

                entity.Property(e => e.Obfs)
                    .IsRequired()
                    .HasColumnName("obfs")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'plain'");

                entity.Property(e => e.Passwd)
                    .IsRequired()
                    .HasColumnName("passwd")
                    .HasMaxLength(64)
                    .IsUnicode(false);

                entity.Property(e => e.Port)
                    .HasColumnName("port")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Protocol)
                    .IsRequired()
                    .HasColumnName("protocol")
                    .HasMaxLength(128)
                    .IsUnicode(false)
                    .HasDefaultValueSql("'origin'");

                entity.Property(e => e.T)
                    .HasColumnName("t")
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1475769600'");

                entity.Property(e => e.TransferEnable)
                    .HasColumnName("transfer_enable")
                    .HasColumnType("bigint(20)");

                entity.Property(e => e.U)
                    .HasColumnName("u")
                    .HasColumnType("bigint(20)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
