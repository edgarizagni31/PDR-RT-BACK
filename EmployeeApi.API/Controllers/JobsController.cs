using EmployeeApi.Application.Services;
using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Api.Controllers
{
  [ApiController]
  [Route("/api/jobs")]
  public class JobsController : ControllerBase
  {
    private readonly JobService _jobService;

    public JobsController(JobService jobService)
    {
      _jobService = jobService;
    }

    [HttpGet]
    public async Task<IActionResult> ListJob()
    {
      var jobs = await _jobService.ListJobAsync();

      var apiResponse = new ApiResponse<List<Job>>()
      {
        Success = true,
        Message = "lista de cargos",
        Data = jobs
      };

      return Ok(apiResponse);
    }
  }
}