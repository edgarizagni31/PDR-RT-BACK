using EmployeeApi.Application.Services;
using EmployeeApi.Domain.Dto;
using EmployeeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Api.Controllers
{
  [ApiController]
  [Route("/api/afps")]
  public class AFPsController : ControllerBase
  {
    private readonly AFPService _afpService;

    public AFPsController(AFPService afpService)
    {
      _afpService = afpService;
    }

    [HttpGet]
    public async Task<IActionResult> ListAFP()
    {
      var afps = await _afpService.ListAFPAsync();

      var apiResponse = new ApiResponse<List<AFP>>()
      {
        Success = true,
        Message = "lista de afps",
        Data = afps
      };

      return Ok(apiResponse);
    }
  }
}