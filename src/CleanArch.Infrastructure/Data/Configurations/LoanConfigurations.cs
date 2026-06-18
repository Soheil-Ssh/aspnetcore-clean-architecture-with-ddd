using CleanArch.Domain.Book;
using CleanArch.Domain.Loan;
using CleanArch.Domain.Member;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Data.Configurations;

public class LoanConfigurations : IEntityTypeConfiguration<Loan>
{
    public void Configure(EntityTypeBuilder<Loan> builder)
    {
        // Table name
        builder.ToTable("Loans");

        // Primary key
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new LoanId(value));

        // Member id
        builder.Property(x => x.MemberId)
            .HasConversion(id => id.Value, value => new MemberId(value))
            .IsRequired();

        // Book copy id
        builder.Property(x => x.BookCopyId)
            .HasConversion(id => id.Value, value => new BookCopyId(value))
            .IsRequired();

        // Borrowed at
        builder.Property(x => x.BorrowedAt).IsRequired();

        // Due date
        builder.Property(x => x.DueDate).IsRequired();

        // Returned at
        builder.Property(x => x.ReturnedAt);

        // Renewal count
        builder.Property(x => x.RenewalCount).IsRequired();

        // Create at
        builder.Property(x => x.CreatedAt).IsRequired();

        // Update at
        builder.Property(x => x.UpdatedAt);

        // Ignore is returned (computed)
        builder.Ignore(x => x.IsReturned);

        // Indexes
        builder.HasIndex(x => x.MemberId);
        builder.HasIndex(x => x.BookCopyId);
        builder.HasIndex(x => x.DueDate);
    }
}