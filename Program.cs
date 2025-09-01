using ExcelReader;
using ExcelReader.Database;

string workingDirectory = AppContext.BaseDirectory;

Console.Write("Clearing & Creating Fresh SQL Server Database and Tables...");
await DbManager.RefreshDatabaseAsync();
Console.WriteLine(" Done!");

Console.Write("Reading Excel File Data...");
var excelEntries = await ExcelFileReader.GetEntriesFromExcelFileAsync(workingDirectory + "MOCK_DATA.xlsx");
Console.WriteLine(" Done!");

Console.Write("Saving Data To Database...");
await DbManager.AddEntriesToDatabaseAsync(excelEntries);
Console.WriteLine(" Done!");

Console.Write("Fetching Entries From Database...");
var entriesList = await DbManager.GetAllEntriesFromDatabaseAsync();
Console.WriteLine(" Done!");

Console.WriteLine("Operations Complete! Screen Will Clear Shortly, Then Display Entires.");
await Task.Delay(3000);

Console.Clear();
Console.WriteLine($"--------------------\nTotal Entries: {entriesList.Count}\n--------------------");
foreach (var entry in entriesList)
{
    Console.WriteLine(entry.ToString() + "\n");
}