using CleanArch.Domain.Member;
using CleanArch.Domain.Member.ValueObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Data.Configurations;

public class MemberConfigurations : IEntityTypeConfiguration<Member>
{
    public void Configure(EntityTypeBuilder<Member> builder)
    {
        // Table Name
        builder.ToTable("Members");

        // Primary key
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new MemberId(value));

        // Full name
        builder.OwnsOne(x => x.FullName, fullName =>
        {
            fullName.Property(x => x.FirstName).HasColumnName("FirstName").HasMaxLength(100).IsRequired();
            fullName.Property(x => x.LastName).HasColumnName("LastName").HasMaxLength(100).IsRequired();
        });

        // Email
        builder.OwnsOne(x => x.Email, email =>
        {
            email.Property(x => x.Value).HasColumnName("Email").HasMaxLength(256).IsRequired();
            email.HasIndex(x => x.Value).IsUnique();
        });

        // Is blocked
        builder.Property(x => x.IsBlocked).IsRequired();

        // Max loan count
        builder.Property(x => x.MaxLoanCount).IsRequired();
    }
}