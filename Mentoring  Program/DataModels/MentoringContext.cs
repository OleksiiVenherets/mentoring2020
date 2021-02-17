using Microsoft.EntityFrameworkCore;

#nullable disable

namespace MentoringProgram.DataModels
{
    public partial class MentoringContext : DbContext
    {
        public MentoringContext()
        {
        }

        public MentoringContext(DbContextOptions<MentoringContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Game> Games { get; set; }

        public virtual DbSet<GameCreator> GameCreators { get; set; }

        public virtual DbSet<GamePublisher> GamePublishers { get; set; }

        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#pragma warning disable CS1030 // #warning directive
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=EPUALVIW0355;Database=Mentoring;Trusted_Connection=True;");
#pragma warning restore CS1030 // #warning directive
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Ukrainian_CI_AS");

            modelBuilder.Entity<Game>(entity =>
            {
                entity.ToTable("Game");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Description).HasColumnType("text");

                entity.Property(e => e.DeveloperId).HasColumnName("DeveloperID");

                entity.Property(e => e.FullSupportLanguage).HasColumnType("text");

                entity.Property(e => e.Genres).HasColumnType("text");

                entity.Property(e => e.InterfaceLanguages).HasColumnType("text");

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PublisherId).HasColumnName("PublisherID");

                entity.Property(e => e.ReleaseDate).HasColumnType("text");

                entity.Property(e => e.SystemRequirenments).HasColumnType("text");

                entity.HasOne(d => d.Developer)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.DeveloperId)
                    .HasConstraintName("FK__Game__DeveloperI__4BAC3F29");

                entity.HasOne(d => d.Publisher)
                    .WithMany(p => p.Games)
                    .HasForeignKey(d => d.PublisherId)
                    .HasConstraintName("FK__Game__PublisherI__4CA06362");
            });

            modelBuilder.Entity<GameCreator>(entity =>
            {
                entity.ToTable("GameCreator");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Owner)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<GamePublisher>(entity =>
            {
                entity.ToTable("GamePublisher");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Address).HasColumnType("text");

                entity.Property(e => e.Country)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Owner)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Login)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Password)
                    .HasMaxLength(30)
                    .IsFixedLength(true);

                entity.Property(e => e.Surname)
                    .HasMaxLength(30)
                    .IsFixedLength(true);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
