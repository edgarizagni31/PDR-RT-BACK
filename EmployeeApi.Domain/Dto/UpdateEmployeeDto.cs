using System.ComponentModel.DataAnnotations;

namespace EmployeeApi.Domain.Dto
{
  public class UpdateEmployeeDto
  {
    [StringLength(100, ErrorMessage = "El nombre debe tener un máximo de 100 caracteres.")]
    public string FirstName { get; set; } = string.Empty;

    [StringLength(100, ErrorMessage = "El apellido debe tener un máximo de 100 caracteres.")]
    public string LastName { get; set; } = string.Empty;

    [Range(1, double.MaxValue, ErrorMessage = "El salario debe ser un número positivo.")]
    public decimal? Salary { get; set; }
    public string? ContractDate { get; set; }
    public string? BirthDate { get; set; }
    public int? JobId { get; set; }
    public int? AfpId { get; set; }
  }
}