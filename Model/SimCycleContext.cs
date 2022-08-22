using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace SimCycle.Model
{
    public partial class SimCycleContext : DbContext
    {
        public SimCycleContext()
        {
        }

        public SimCycleContext(DbContextOptions<SimCycleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cycle> Cycles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=SimCycle;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cycle>(entity =>
            {
                entity.ToTable("cycle");

                entity.Property(e => e.FrontWheelSize).HasColumnName("Front_WheelSize");

                entity.Property(e => e.RearWheelSize).HasColumnName("Rear_WheelSize");

                entity.Property(e => e.RearwheelCircumference).HasColumnName("Rearwheel_Circumference");

                entity.Property(e => e.TotalGearLevels)
                    .IsUnicode(false)
                    .HasColumnName("Total_GearLevels");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
