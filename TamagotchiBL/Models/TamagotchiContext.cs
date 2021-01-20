using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace TamagotchiBL.Models
{
    public partial class TamagotchiContext : DbContext
    {
        public TamagotchiContext()
        {
        }

        public TamagotchiContext(DbContextOptions<TamagotchiContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<AnimalStatus> AnimalStatuses { get; set; }
        public virtual DbSet<Function> Functions { get; set; }
        public virtual DbSet<HistoryOfFunction> HistoryOfFunctions { get; set; }
        public virtual DbSet<LifeCycle> LifeCycles { get; set; }
        public virtual DbSet<Player> Players { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalBirthDate).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.AnimalCleaness).HasDefaultValueSql("((50))");

                entity.Property(e => e.AnimalHappiness).HasDefaultValueSql("((50))");

                entity.Property(e => e.AnimalHunger).HasDefaultValueSql("((50))");

                entity.Property(e => e.AnimalWeight).HasDefaultValueSql("((3))");

                entity.Property(e => e.LifeCycleId).HasDefaultValueSql("((1))");

                entity.Property(e => e.StatusId).HasDefaultValueSql("((1))");

                entity.HasOne(d => d.LifeCycle)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.LifeCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalsLifeCycle");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.PlayerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalsPlayers");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.Animals)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AnimalsStatus");
            });

            modelBuilder.Entity<AnimalStatus>(entity =>
            {
                entity.HasKey(e => e.StatusId)
                    .HasName("PK__AnimalSt__C8EE2063B2B1D3F9");
            });

            modelBuilder.Entity<Function>(entity =>
            {
                entity.HasOne(d => d.FunctionOfNavigation)
                    .WithMany(p => p.InverseFunctionOfNavigation)
                    .HasForeignKey(d => d.FunctionOf)
                    .HasConstraintName("FK_Functions");
            });

            modelBuilder.Entity<HistoryOfFunction>(entity =>
            {
                entity.HasKey(e => new { e.FunctionDate, e.AnimalId })
                    .HasName("PK");

                entity.Property(e => e.FunctionDate).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.HistoryOfFunctions)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Animals");

                entity.HasOne(d => d.Function)
                    .WithMany(p => p.HistoryOfFunctions)
                    .HasForeignKey(d => d.FunctionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_historyFunctions");

                entity.HasOne(d => d.LifeCycle)
                    .WithMany(p => p.HistoryOfFunctions)
                    .HasForeignKey(d => d.LifeCycleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LifeCycle");
            });

            modelBuilder.Entity<Player>(entity =>
            {
                entity.HasIndex(e => e.PlayerActiveAnimal, "ui")
                    .IsUnique()
                    .HasFilter("([PlayerActiveAnimal] IS NOT NULL)");

                entity.HasOne(d => d.PlayerActiveAnimalNavigation)
                    .WithOne(p => p.PlayerNavigation)
                    .HasForeignKey<Player>(d => d.PlayerActiveAnimal)
                    .HasConstraintName("FK_PlayersAnimals");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
