using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebTetrisScoreSystem.Data
{
    public partial class TetrisDBContext : DbContext
    {
        public TetrisDBContext()
        {
        }

        public TetrisDBContext(DbContextOptions<TetrisDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<PlayerScore> PlayerScores { get; set; }
        public virtual DbSet<Score> Scores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.;Database=TetrisDB;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Player>(entity =>
            {
                entity.Property(e => e.Nickname).IsRequired();
            });

            modelBuilder.Entity<PlayerScore>(entity =>
            {
                entity.HasKey(e => new { e.PlayerId, e.ScoreId });

                entity.HasIndex(e => e.ScoreId, "IX_PlayerScores_ScoreId");

                entity.HasOne(d => d.Player)
                    .WithMany(p => p.PlayerScores)
                    .HasForeignKey(d => d.PlayerId);

                entity.HasOne(d => d.Score)
                    .WithMany(p => p.PlayerScores)
                    .HasForeignKey(d => d.ScoreId);
            });

            modelBuilder.Entity<Score>(entity =>
            {
                entity.Property(e => e.Points).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
