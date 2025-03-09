using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DemoCQRS.Domain.Users;

public class UserEntityConfiguration
    : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("users");
        builder.HasKey(k => k.Id);

        builder.HasIndex(i => i.Email, "idx_users_email")
            .IsUnique();

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .HasColumnType("uuid")
            .ValueGeneratedOnAdd()
            .IsRequired();

        builder.Property(p => p.Name)
            .HasColumnName("name")
            .HasColumnType("character varying(100)")
            .IsRequired();

        builder.Property(p => p.Email)
            .HasColumnName("email")
            .HasColumnType("character varying(100)")
            .IsRequired();

        builder.Property(p => p.Phone)
            .HasColumnName("phone")
            .HasColumnType("character varying(100)");

        builder.Property(p => p.Status)
            .HasColumnName("status")
            .HasColumnType("user_status")
            .IsRequired();

        builder.Property(p => p.CreatedAt)
            .HasColumnName("created_at")
            .HasColumnType("timestamp without time zone")
            .HasDefaultValueSql("now()")
            .IsRequired();

        builder.Property(p => p.UpdatedAt)
            .HasColumnName("updated_at")
            .HasColumnType("timestamp with time zone")
            .IsRequired();
    }
}
