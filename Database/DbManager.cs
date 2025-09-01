using Microsoft.EntityFrameworkCore;

namespace ExcelReader.Database;

public static class DbManager
{
    private static readonly ExcelDbContext _dbContext;

    static DbManager()
    {
        var connectionStringExists = AppConfig.FetchConnectionString(out var connectionString);

        if (!connectionStringExists)
        {
            throw new ArgumentNullException(nameof(connectionString));
        }

        ExcelDbContext context = new(connectionString);
        _dbContext = context;
    }

    public async static Task RefreshDatabaseAsync()
    {
        await _dbContext.Database.EnsureDeletedAsync();
        await _dbContext.Database.EnsureCreatedAsync();
    }

    public async static Task AddEntriesToDatabaseAsync(List<ExcelModel> entries)
    {
        foreach(var entry in entries)
        {
            _dbContext.Entries.Add(entry);
        }

        await _dbContext.SaveChangesAsync();
    }

    public async static Task<List<ExcelModel>> GetAllEntriesFromDatabaseAsync()
    {
        var query = _dbContext.Entries.OrderBy(e => e.Id);

        if(!query.Any())
        {
            return [];
        }

        return await query.ToListAsync();
    }
}
