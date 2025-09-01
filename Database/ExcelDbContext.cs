using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Database;

public class ExcelDbContext : DbContext
{
    public DbSet<ExcelModel> Entries { get; set; }

    public readonly string _connectionString;

    public ExcelDbContext(string connectionString)
    {
        if(string.IsNullOrWhiteSpace(connectionString))
        {
            throw new ArgumentException("ConnectionString was null or empty.", nameof(connectionString));
        }

        _connectionString = connectionString;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_connectionString);
}
