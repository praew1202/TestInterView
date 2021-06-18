using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace API.Models
{
    public partial class DemoContext : DbContext
    {
        public DemoContext()
        {
        }

        public DemoContext(DbContextOptions<DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CardScan> CardScans { get; set; }
        public virtual DbSet<Fruit> Fruits { get; set; }
        public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=Demo;Trusted_Connection=false;User ID=sa;Password=123Pr4a5ew");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<CardScan>(entity =>
            {
                entity.ToTable("CardScan");

                entity.Property(e => e.CardScanId).ValueGeneratedNever();

                entity.Property(e => e.Clock).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");
            });

            modelBuilder.Entity<Fruit>(entity =>
            {
                entity.ToTable("Fruit");

                entity.Property(e => e.FruitId).ValueGeneratedNever();

                entity.Property(e => e.FruitName).HasMaxLength(250);
            });

            modelBuilder.Entity<WorkSchedule>(entity =>
            {
                entity.HasKey(e => e.WorkSchedule1)
                    .HasName("PK__WorkSche__2D4D53E352A5B25D");

                entity.ToTable("WorkSchedule");

                entity.Property(e => e.WorkSchedule1)
                    .ValueGeneratedNever()
                    .HasColumnName("WorkSchedule");

                entity.Property(e => e.BeginTime).HasColumnType("datetime");

                entity.Property(e => e.EmployeeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmployeeID");

                entity.Property(e => e.EndTime).HasColumnType("datetime");

                entity.Property(e => e.WorkDate).HasColumnType("date");

                entity.HasOne(d => d.CardScan)
                    .WithMany(p => p.WorkSchedules)
                    .HasForeignKey(d => d.CardScanId)
                    .HasConstraintName("FK__WorkSched__CardS__4AB81AF0");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
