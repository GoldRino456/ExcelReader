using ExcelReader.Database;
using OfficeOpenXml;

namespace ExcelReader;

public static class ExcelFileReader
{
    static ExcelFileReader()
    {
        ExcelPackage.License.SetNonCommercialPersonal("GoldRino456");
    }

    public static async Task<List<ExcelModel>> GetEntriesFromExcelFileAsync(string filePath)
    {
        var entries = new List<ExcelModel>();
        var file = new FileInfo(filePath);

        using var package = new ExcelPackage(file);
        await package.LoadAsync(file);

        var ws = package.Workbook.Worksheets[0];

        int row = 2;
        int column = 1;
        while (string.IsNullOrWhiteSpace(ws.Cells[row, column].Value?.ToString()) == false)
        {
            ExcelModel newEntry = new()
            {
                Id = int.Parse(ws.Cells[row, column].Value.ToString()),
                FirstName = ws.Cells[row, column + 1].Value.ToString(),
                LastName = ws.Cells[row, column + 2].Value.ToString(),
                Email = ws.Cells[row, column + 3].Value.ToString(),
                Phone = ws.Cells[row, column + 4].Value.ToString(),
                Department = ws.Cells[row, column + 5].Value.ToString()
            };
            
            entries.Add(newEntry);
            row++;
        }

        return entries;
    }
}
