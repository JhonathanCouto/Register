using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Register.Domain;

namespace Register.Infrastructure;

public sealed class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("user");

        builder.HasKey(entity => entity.Id);

        builder.Property(entity => entity.Id).HasColumnName("id").ValueGeneratedOnAdd().IsRequired();

        builder.Property(entity => entity.Name).HasColumnName("name").HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Email).HasColumnName("email").HasMaxLength(100).IsRequired();

        builder.Property(entity => entity.Cpf).HasColumnName("cpf").HasMaxLength(11).IsFixedLength().IsRequired();

        builder.Property(entity => entity.CreatedAt).HasColumnName("created_at").IsRequired();
    }
}
