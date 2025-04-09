namespace EmployeeApi.Domain.Entities
{
  public class Job
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public int DeparmentId { get; set; }

    public Department Deparment { get; set; } = new Department();

    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
  }
}