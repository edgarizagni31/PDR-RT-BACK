namespace EmployeeApi.Domain.Entities
{
  public class AFP
  {

    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Employee> Employees { get; set; } = new List<Employee>();
  }
}