using System.Text.Json.Serialization;

namespace EmployeeApi.Domain.Entities
{
  public class Employee
  {
    public int Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public DateTime ContractDate { get; set; }
    public DateTime BirthDate { get; set; }
    public decimal Salary { get; set; }
    public int AfpId { get; set; }
    public int JobId { get; set; }
    public bool Status { get; set; }

    [JsonIgnore]
    public Job Job { get; set; } = new Job();

    [JsonIgnore]
    public AFP Afp { get; set; } = new AFP();

    public List<SalaryHistory> SalaryHistories { get; set; } = [];
  }
}

