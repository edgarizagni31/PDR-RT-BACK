namespace EmployeeApi.Domain.Entities
{
  public class Audit
  {
    public int Id { get; set; }
    public string Action { get; set; } = string.Empty;
    public string TableName { get; set; } = string.Empty;
    public string OldValue { get; set; } = string.Empty;
    public string NewValue { get; set; } = string.Empty;
    public DateTime Timestamp { get; set; }
  }
}