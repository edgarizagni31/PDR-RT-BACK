using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace EmployeeApi.Domain.Dto
{
  public class CreateEmployeeDto
  {
    [JsonPropertyName("firstName")]
    [Required(ErrorMessage = "Nombre es requerido")]
    [StringLength(100, ErrorMessage = "Nombre debe tener como máximo 100 caracteres")]
    public string FirstName { get; set; } = string.Empty;

    [JsonPropertyName("lastName")]
    [Required(ErrorMessage = "Apellido es requerido")]
    [StringLength(100, ErrorMessage = "Apellido debe tener como máximo 100 caracteres")]
    public string LastName { get; set; } = string.Empty;

    [JsonPropertyName("salary")]
    [Required(ErrorMessage = "Salario es requerido")]
    [Range(1, double.MaxValue, ErrorMessage = "Salario debe ser un número positivo")]
    public decimal Salary { get; set; }

    [JsonPropertyName("contractDate")]
    [Required(ErrorMessage = "Fecha de contrato es requerida.")]
    public String ContractDate { get; set; } = string.Empty;

    [JsonPropertyName("birthDate")]
    [Required(ErrorMessage = "Fecha de cumpleaños es requerida.")]
    public String BirthDate { get; set; } = string.Empty;

    [JsonPropertyName("jobId")]
    [Required(ErrorMessage = "Job ID is required")]
    public int JobId { get; set; }

    [JsonPropertyName("afpId")]
    [Required(ErrorMessage = "AFP ID is required")]
    public int AfpId { get; set; }
  }
}