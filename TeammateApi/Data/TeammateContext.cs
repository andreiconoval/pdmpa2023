using Microsoft.EntityFrameworkCore;

namespace TeammateApi.Data;

public partial class TeammateContext : DbContext
{
    public TeammateContext()
    {
    }

    public TeammateContext(DbContextOptions<TeammateContext> options)
        : base(options)
    {
    }

    public virtual DbSet<UserAdressEntity> UserAdresses { get; set; }

    public virtual DbSet<UserProfileEntity> UserProfiles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserAdressEntity>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_adresses");

            entity.Property(e => e.Label).HasColumnName("label");
            entity.Property(e => e.MapLatitude).HasColumnName("map_latitude");
            entity.Property(e => e.MapLongitude).HasColumnName("map_longitude");
            entity.Property(e => e.UserUid).HasColumnName("user_uid");
        });

        modelBuilder.Entity<UserProfileEntity>(entity =>
        {
            entity.HasKey(e => e.UserUid);

            entity.ToTable("user_profile");

            entity.Property(e => e.UserUid).HasColumnName("user_uid");
            entity.Property(e => e.FirstName).HasColumnName("first_name");
            entity.Property(e => e.LastName).HasColumnName("last_name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
