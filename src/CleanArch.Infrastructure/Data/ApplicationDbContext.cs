using CleanArch.Domain.Book;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using CleanArch.Domain.Member;

namespace CleanArch.Infrastructure.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Member> Members { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}