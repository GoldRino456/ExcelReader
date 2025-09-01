
namespace ExcelReader;

public static class DbManager
{
    public async static Task<bool> RefreshDatabase()
    {
        var connectionStringExists = AppConfig.FetchConnectionString(out var connectionString);

        if(!connectionStringExists)
        {
            return false;
        }

        ExcelDbContext context = new(connectionString);
        
        await context.Database.EnsureDeletedAsync();
        await context.Database.EnsureCreatedAsync();
        
        return true;
    }
}
