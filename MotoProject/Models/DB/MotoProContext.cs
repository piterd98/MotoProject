using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MotoProject.Models.DB
{
    public partial class MotoProContext : DbContext
    {
        public MotoProContext()
        {
        }

        public MotoProContext(DbContextOptions<MotoProContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Announcement> Announcements { get; set; }
        public virtual DbSet<Bill> Bills { get; set; }
        public virtual DbSet<BodyType> BodyTypes { get; set; }
        public virtual DbSet<Brand> Brands { get; set; }
        public virtual DbSet<Color> Colors { get; set; }
        public virtual DbSet<Message> Messages { get; set; }
        public virtual DbSet<Model> Models { get; set; }
        public virtual DbSet<Service> Services { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-6VJRSS0\\SQLEXPRESS;Initial Catalog=MotoPro;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Announcement>(entity =>
            {
                entity.HasKey(e => e.IdAnnouncement);

                entity.Property(e => e.IdAnnouncement).ValueGeneratedNever();

                entity.Property(e => e.Description).IsRequired();

                entity.Property(e => e.Title).IsRequired();

                entity.HasOne(d => d.IdBodyTypeNavigation)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.IdBodyType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_BodyTypes");

                entity.HasOne(d => d.IdColorNavigation)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.IdColor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_Colors");

                entity.HasOne(d => d.IdModelNavigation)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.IdModel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_Models");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Announcements)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Announcements_Users");
            });

            modelBuilder.Entity<Bill>(entity =>
            {
                entity.HasKey(e => e.IdBill);

                entity.Property(e => e.IdBill).ValueGeneratedNever();

                entity.Property(e => e.DateTo).HasColumnType("datetime");

                entity.Property(e => e.FinalValue).HasColumnType("smallmoney");

                entity.HasOne(d => d.IdAnnouncementNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdAnnouncement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bills_Announcements");

                entity.HasOne(d => d.IdServiceNavigation)
                    .WithMany(p => p.Bills)
                    .HasForeignKey(d => d.IdService)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Bills_Services");
            });

            modelBuilder.Entity<BodyType>(entity =>
            {
                entity.HasKey(e => e.IdBodyType);

                entity.Property(e => e.IdBodyType).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Brand>(entity =>
            {
                entity.HasKey(e => e.IdBrand);

                entity.Property(e => e.IdBrand).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Color>(entity =>
            {
                entity.HasKey(e => e.IdColor);

                entity.Property(e => e.IdColor).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Message>(entity =>
            {
                entity.HasKey(e => e.IdMessage);

                entity.Property(e => e.IdMessage).ValueGeneratedNever();

                entity.Property(e => e.Date).HasColumnType("smalldatetime");

                entity.Property(e => e.Message1)
                    .IsRequired()
                    .HasColumnName("Message");

                entity.HasOne(d => d.IdAnnouncementNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdAnnouncement)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Announcements");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Messages)
                    .HasForeignKey(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Messages_Users");
            });

            modelBuilder.Entity<Model>(entity =>
            {
                entity.HasKey(e => e.IdModel);

                entity.Property(e => e.IdModel).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.IdBrandNavigation)
                    .WithMany(p => p.Models)
                    .HasForeignKey(d => d.IdBrand)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Models_Brands");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.HasKey(e => e.IdService);

                entity.Property(e => e.IdService).ValueGeneratedNever();

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.Price).HasColumnType("smallmoney");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.Property(e => e.IdUser).ValueGeneratedNever();

                entity.Property(e => e.Password).IsRequired();

                entity.Property(e => e.Username).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
