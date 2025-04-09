using EmployeeApi.Domain.Dto;

namespace EmployeeApi.Middleware
{
  public class ValidationMiddleware
  {
    private readonly RequestDelegate _next;

    public ValidationMiddleware(RequestDelegate next)
    {
      _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
      if (!context.Request.HasJsonContentType())
      {
        context.Response.StatusCode = StatusCodes.Status400BadRequest;

        await context.Response.WriteAsJsonAsync(new ApiResponse<string>()
        {
          Success = false,
          Message = "Content-Type no es un JSON",
          Data = null
        });

        return;
      }

      await _next(context);
    }

  }

  public static class ValidationMiddlewareExtensions
  {
    public static IApplicationBuilder UseValidationMiddleware(
        this IApplicationBuilder builder)
    {
      return builder.UseMiddleware<ValidationMiddleware>();
    }
  }

}