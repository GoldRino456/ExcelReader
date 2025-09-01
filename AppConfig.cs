﻿using Microsoft.Extensions.Configuration;

namespace ExcelReader;

public static class AppConfig
{
    public static bool FetchConnectionString(out string? connectionString)
    {
        string workingDirectory = AppContext.BaseDirectory;

        IConfiguration config = new ConfigurationBuilder()
                    .SetBasePath(workingDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();

        connectionString = config.GetConnectionString("DefaultConnection");

        return !string.IsNullOrWhiteSpace(connectionString);
    }
}
