namespace EmployeeApi.Domain.Dto
{
  public class EmployeeWhitAfpAndJob
  {
    public int EmployeeId { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public decimal Salary { get; set; }
    public DateTime ContractDate { get; set; }
    public DateTime BirthDate { get; set; }
    public string JobName { get; set; } = string.Empty;
    public string AfpName { get; set; } = string.Empty;
    public int JobId {get; set; }
    public int AfpId {get; set; }
    public bool Status { get; set; } = true;
  }
}