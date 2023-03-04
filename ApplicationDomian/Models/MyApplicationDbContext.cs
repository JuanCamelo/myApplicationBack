using Microsoft.EntityFrameworkCore;

namespace ApplicationDomian.Models;

public partial class MyApplicationDbContext : DbContext
{
    public MyApplicationDbContext()
    {
    }

    public MyApplicationDbContext(DbContextOptions<MyApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<TypeContact> TypeContacts { get; set; }

    public virtual DbSet<User> Users { get; set; }
      

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Position>(entity =>
        {
            entity.ToTable("Position");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<TypeContact>(entity =>
        {
            entity.ToTable("TypeContact");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.CreationDate).HasColumnType("datetime");
            entity.Property(e => e.Gmail)
                .HasMaxLength(30)
                .IsFixedLength();
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.User1)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("User");
            entity.Property(e => e.UserName)
                .HasMaxLength(60)
                .IsUnicode(false);

            entity.HasOne(d => d.IdPositionNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdPosition)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_Position");

            entity.HasOne(d => d.IdTypeContactNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdTypeContact)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_TypeContact");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
