namespace EmployeeApi.Domain.Entities
{
  public class Department
  {
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
  }
}
