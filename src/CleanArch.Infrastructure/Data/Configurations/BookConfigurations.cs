using CleanArch.Domain.Book;
using CleanArch.Domain.Book.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastructure.Data.Configurations;

public class BookConfigurations : IEntityTypeConfiguration<Book>
{
    public void Configure(EntityTypeBuilder<Book> builder)
    {
        // Table Name
        builder.ToTable("Books");

        // Primary key
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id).ValueGeneratedNever()
            .HasConversion(id => id.Value, value => new BookId(value));

        // Title
        builder.Property(x => x.Title).HasMaxLength(300).IsRequired();

        // Author
        builder.Property(x => x.Author).HasMaxLength(200).IsRequired();

        // Publisher
        builder.Property(x => x.Publisher).HasMaxLength(200).IsRequired();

        // Isbn
        builder.ComplexProperty(x => x.Isbn, isbn =>
        {
            isbn.Property(x => x.Value).HasColumnName("Isbn").HasMaxLength(20).IsRequired();
        });

        // Publisher year
        builder.ComplexProperty(x => x.PublishYear, year =>
        {
            year.Property(x => x.Value).HasColumnName("PublishYear").IsRequired();
        });

        // Book copies
        builder.Navigation(x => x.Copies).UsePropertyAccessMode(PropertyAccessMode.Field);
        builder.OwnsMany(x => x.Copies, copy =>
        {
            // Table Name
            copy.ToTable("BookCopies");

            // Primary key
            copy.HasKey(x => x.Id);
            copy.Property(x => x.Id).ValueGeneratedNever()
                .HasConversion(id => id.Value, value => new BookCopyId(value));

            // Foreign key
            copy.WithOwner().HasForeignKey("BookId");

            // Status
            copy.Property(x => x.Status).IsRequired();

            // Barcode
            copy.OwnsOne(x => x.Barcode, barcode =>
            {
                barcode.Property(x => x.Value).HasColumnName("Barcode").HasMaxLength(50).IsRequired();
                barcode.HasIndex(x => x.Value).IsUnique();
            });

        });

        // Create at
        builder.Property(x => x.CreatedAt).IsRequired();

        // Update at
        builder.Property(x => x.UpdatedAt).IsRequired();
    }
}