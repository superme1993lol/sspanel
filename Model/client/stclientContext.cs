using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Model.client
{
    public partial class stclientContext : DbContext
    {
        string sqlurl;

        public stclientContext(string su)
        {
            sqlurl = su;
        }


        public stclientContext(DbContextOptions<stclientContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Knowledge> Knowledge { get; set; }
        public virtual DbSet<Knowledgetype> Knowledgetype { get; set; }
        public virtual DbSet<Member> Member { get; set; }
      
        public virtual DbSet<Memberservice> Memberservice { get; set; }
        public virtual DbSet<News> News { get; set; }
        public virtual DbSet<Partner> Partner { get; set; }
        public virtual DbSet<Payorder> Payorder { get; set; }
        public virtual DbSet<Preferentialcode> Preferentialcode { get; set; }
        public virtual DbSet<Preferentialcoderef> Preferentialcoderef { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Provpnref> Provpnref { get; set; }
        public virtual DbSet<Systembase> Systembase { get; set; }
    
        public virtual DbSet<Vpnserver> Vpnserver { get; set; }
        public virtual DbSet<Workorder> Workorder { get; set; }
        public virtual DbSet<Workorderdetail> Workorderdetail { get; set; }

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
            modelBuilder.Entity<Knowledge>(entity =>
            {
                entity.ToTable("knowledge");

                entity.HasIndex(e => e.KtypeId)
                    .HasName("K_KT");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.KtypeId)
                    .HasColumnName("KTypeId")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Ktype)
                    .WithMany(p => p.Knowledge)
                    .HasForeignKey(d => d.KtypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("K_KT");
            });

            modelBuilder.Entity<Knowledgetype>(entity =>
            {
                entity.ToTable("knowledgetype");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Kname)
                    .IsRequired()
                    .HasColumnName("KName")
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Member>(entity =>
            {
                entity.ToTable("member");

                entity.HasIndex(e => e.PartnerId)
                    .HasName("Member_Partner");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Account)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsMailSend)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsRegist)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.NickName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerId).HasColumnType("int(11)");

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RegistKey)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ResetPwdKey)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Partner)
                    .WithMany(p => p.Member)
                    .HasForeignKey(d => d.PartnerId)
                    .HasConstraintName("Member_Partner");
            });

            

            modelBuilder.Entity<Memberservice>(entity =>
            {
                entity.ToTable("memberservice");

                entity.HasIndex(e => e.MemberId)
                    .HasName("MS_Member");

                entity.HasIndex(e => e.ProId)
                    .HasName("MS_Product");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.FlushTrafficDate)
                    .HasColumnType("int(10) unsigned")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.MaxOnlineUser).HasColumnType("int(11)");

                entity.Property(e => e.MemberId).HasColumnType("int(11)");

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.Property(e => e.ProId).HasColumnType("int(11)");

                entity.Property(e => e.Ssport)
                    .IsRequired()
                    .HasColumnName("SSPort")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sspwd)
                    .IsRequired()
                    .HasColumnName("SSPwd")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Token)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Traffic).HasColumnType("bigint(20)");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Memberservice)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("memberservice_ibfk_1");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Memberservice)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("memberservice_ibfk_2");
            });

            modelBuilder.Entity<News>(entity =>
            {
                entity.ToTable("news");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Partner>(entity =>
            {
                entity.ToTable("partner");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.LoginName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PartnerCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Pwd)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.RealName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(1000)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Payorder>(entity =>
            {
                entity.ToTable("payorder");

                entity.HasIndex(e => e.MemberId)
                    .HasName("PO_Member");

                entity.HasIndex(e => e.MemberServiceId)
                    .HasName("payorder_ms");

                entity.HasIndex(e => e.PreferentialCodeId)
                    .HasName("PO_PC");

                entity.HasIndex(e => e.ProId)
                    .HasName("PO_Product");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.IsNew).HasColumnType("bit(1)");

                entity.Property(e => e.MemberId).HasColumnType("int(11)");

                entity.Property(e => e.MemberServiceId).HasColumnType("int(11)");

                entity.Property(e => e.Money).HasColumnType("int(11)");

                entity.Property(e => e.OrderNum)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PayWay).HasColumnType("int(11)");

                entity.Property(e => e.PreferentialCodeId).HasColumnType("int(11)");

                entity.Property(e => e.ProId).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.TransactionNum)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Payorder)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payorder_ibfk_1");

                entity.HasOne(d => d.MemberService)
                    .WithMany(p => p.Payorder)
                    .HasForeignKey(d => d.MemberServiceId)
                    .HasConstraintName("payorder_ibfk_4");

                entity.HasOne(d => d.PreferentialCode)
                    .WithMany(p => p.Payorder)
                    .HasForeignKey(d => d.PreferentialCodeId)
                    .HasConstraintName("payorder_ibfk_2");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Payorder)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payorder_ibfk_3");
            });

            modelBuilder.Entity<Payordermemberserviceref>(entity =>
            {
                entity.ToTable("payordermemberserviceref");

                entity.HasIndex(e => e.MemberServiceId)
                    .HasName("MemberServiceId");

                entity.HasIndex(e => e.PayOrderId)
                    .HasName("PayOrderId");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.MemberServiceId).HasColumnType("int(11)");

                entity.Property(e => e.PayOrderId).HasColumnType("int(11)");

                entity.HasOne(d => d.MemberService)
                    .WithMany(p => p.Payordermemberserviceref)
                    .HasForeignKey(d => d.MemberServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payordermemberserviceref_ibfk_1");

                entity.HasOne(d => d.PayOrder)
                    .WithMany(p => p.Payordermemberserviceref)
                    .HasForeignKey(d => d.PayOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("payordermemberserviceref_ibfk_2");
            });

            modelBuilder.Entity<Preferentialcode>(entity =>
            {
                entity.ToTable("preferentialcode");

                entity.HasIndex(e => e.MemberId)
                    .HasName("PC_Member");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Code)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Discount).HasDefaultValueSql("'0'");

                entity.Property(e => e.IsDelete)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'0'");

                entity.Property(e => e.MemberId).HasColumnType("int(11)");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Preferentialcode)
                    .HasForeignKey(d => d.MemberId)
                    .HasConstraintName("PC_Member");
            });

            modelBuilder.Entity<Preferentialcoderef>(entity =>
            {
                entity.ToTable("preferentialcoderef");

                entity.HasIndex(e => e.PreferentialCodeId)
                    .HasName("PCR_PC");

                entity.HasIndex(e => e.ProId)
                    .HasName("PCR_P");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.PreferentialCodeId).HasColumnType("int(11)");

                entity.Property(e => e.ProId).HasColumnType("int(11)");

                entity.HasOne(d => d.PreferentialCode)
                    .WithMany(p => p.Preferentialcoderef)
                    .HasForeignKey(d => d.PreferentialCodeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PCR_PC");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Preferentialcoderef)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PCR_P");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.DurationDate)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.FlushTrafficDate)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'30'");

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.MaxOnlineUser)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'2'");

                entity.Property(e => e.Price).HasColumnType("int(11)");

                entity.Property(e => e.ProName)
                    .IsRequired()
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Traffic).HasColumnType("bigint(20)");
            });

            modelBuilder.Entity<Provpnref>(entity =>
            {
                entity.ToTable("provpnref");

                entity.HasIndex(e => e.ProId)
                    .HasName("PVR_P");

                entity.HasIndex(e => e.Vpnid)
                    .HasName("PVR_V");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.ProId).HasColumnType("int(11)");

                entity.Property(e => e.Vpnid)
                    .HasColumnName("VPNId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Pro)
                    .WithMany(p => p.Provpnref)
                    .HasForeignKey(d => d.ProId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PVR_P");

                entity.HasOne(d => d.Vpn)
                    .WithMany(p => p.Provpnref)
                    .HasForeignKey(d => d.Vpnid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("PVR_V");
            });

            modelBuilder.Entity<Systembase>(entity =>
            {
                entity.ToTable("systembase");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.IsView)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Key)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Value)
                    .HasMaxLength(2000)
                    .IsUnicode(false);
            });

             

            modelBuilder.Entity<Vpnserver>(entity =>
            {
                entity.ToTable("vpnserver");

           

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Country)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Domain)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.IsUse)
                    .HasColumnType("bit(1)")
                    .HasDefaultValueSql("b'1'");

                entity.Property(e => e.Method)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Obfs)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Passwd)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Port)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Protocol)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.ProxyType)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ServerName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

              
                
            });

            modelBuilder.Entity<Workorder>(entity =>
            {
                entity.ToTable("workorder");

                entity.HasIndex(e => e.MemberId)
                    .HasName("WO_Member");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.MemberId).HasColumnType("int(11)");

                entity.Property(e => e.State)
                    .HasColumnType("int(11)")
                    .HasDefaultValueSql("'1'");

                entity.HasOne(d => d.Member)
                    .WithMany(p => p.Workorder)
                    .HasForeignKey(d => d.MemberId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WO_Member");
            });

            modelBuilder.Entity<Workorderdetail>(entity =>
            {
                entity.ToTable("workorderdetail");

                entity.HasIndex(e => e.Woid)
                    .HasName("WOD_WO");

                entity.Property(e => e.Id).HasColumnType("int(11)");

                entity.Property(e => e.Content).IsRequired();

                entity.Property(e => e.WodType).HasColumnType("int(11)");

                entity.Property(e => e.Woid)
                    .HasColumnName("WOId")
                    .HasColumnType("int(11)");

                entity.HasOne(d => d.Wo)
                    .WithMany(p => p.Workorderdetail)
                    .HasForeignKey(d => d.Woid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("WOD_WO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
