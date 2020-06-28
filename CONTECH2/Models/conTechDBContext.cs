using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace CONTECH2.Models
{
    public partial class ConTechDBContext : DbContext
    {
        public ConTechDBContext()
        {
        }

        public ConTechDBContext(DbContextOptions<ConTechDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Labels> Labels { get; set; }
        public virtual DbSet<Posts> Posts { get; set; }
        public virtual DbSet<PostsLabels> PostsLabels { get; set; }
        public virtual DbSet<Teams> Teams { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersLabels> UsersLabels { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlite(@"DataSource=C:\Users\User\ConTech\ConTechDB.db;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Labels>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Posts>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Posts)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<PostsLabels>(entity =>
            {
                entity.HasKey(e => new { e.PostId, e.LabelsId });

                entity.Property(e => e.PostId).HasColumnName("PostID");

                entity.Property(e => e.LabelsId).HasColumnName("LabelsID");

                entity.HasOne(d => d.Labels)
                    .WithMany(p => p.PostsLabels)
                    .HasForeignKey(d => d.LabelsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.Post)
                    .WithMany(p => p.PostsLabels)
                    .HasForeignKey(d => d.PostId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Teams>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Anaf).IsRequired();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full name");

                entity.Property(e => e.Mador).IsRequired();

                entity.Property(e => e.Merkaz).IsRequired();

                entity.Property(e => e.TeamLeader).HasColumnName("Team leader");

                entity.Property(e => e.Yehida).IsRequired();

                entity.HasOne(d => d.TeamLeaderNavigation)
                    .WithMany(p => p.Teams)
                    .HasForeignKey(d => d.TeamLeader)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasIndex(e => e.UserName)
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasColumnName("Full name");

                entity.Property(e => e.Voip).HasColumnName("VOIP");
            });

            modelBuilder.Entity<UsersLabels>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LabelsId });

                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.LabelsId).HasColumnName("LabelsID");

                entity.HasOne(d => d.Labels)
                    .WithMany(p => p.UsersLabels)
                    .HasForeignKey(d => d.LabelsId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UsersLabels)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
