using System.Text.Json.Serialization;

namespace EmployeeApi.Domain.Entities
{
  public class SalaryHistory
  {
    public int Id { get; set; }
    public int EmployeeId { get; set; }
    public decimal OldSalary { get; set; }
    public decimal NewSalary { get; set; }
    public DateTime UpdatedAt { get; set; }

    [JsonIgnore]
    public Employee Employee { get; set; }
  }
}