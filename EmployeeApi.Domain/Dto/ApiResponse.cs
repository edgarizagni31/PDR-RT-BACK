namespace EmployeeApi.Domain.Dto
{
  public class ApiResponse<T>
  {
    public bool Success { get; set; }
    public T? Data { get; set; }

    public string Message { get; set; } = string.Empty;
  }
}