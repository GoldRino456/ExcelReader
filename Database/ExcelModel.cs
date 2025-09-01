using System.ComponentModel.DataAnnotations.Schema;

namespace ExcelReader.Database;

public class ExcelModel
{
    [DatabaseGenerated(DatabaseGeneratedOption.None)]
    public int Id { get; set; }
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string? Email { get; set; }
    public string? Phone {  get; set; }
    public string? Department { get; set; }

    public override string ToString()
    {
        return $"ID# {Id}: {LastName}, {FirstName} of {Department}. Can be reached by {Phone} or via email at {Email}.";
    }
}
