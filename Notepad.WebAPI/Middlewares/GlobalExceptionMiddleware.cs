using System.Net;
using System.Text.Json;

namespace Notepad.WebAPI.Middlewares
{
    public class GlobalExceptionMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<GlobalExceptionMiddleware> _logger;

        public GlobalExceptionMiddleware(RequestDelegate next, ILogger<GlobalExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "İdarə olunmayan istisna baş verdi. Trace: {StackTrace}", ex.StackTrace);
                await HandleExceptionAsync(context, ex);
            }
        }

        private async Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/problem+json";

            var statusCode = exception switch
            {
                ArgumentException => (int)HttpStatusCode.BadRequest,
                KeyNotFoundException => (int)HttpStatusCode.NotFound,
                FileNotFoundException => (int)HttpStatusCode.NotFound,
                UnauthorizedAccessException => (int)HttpStatusCode.Unauthorized,
                InvalidOperationException => (int)HttpStatusCode.Conflict,
                NotImplementedException => (int)HttpStatusCode.NotImplemented,
                TimeoutException => (int)HttpStatusCode.RequestTimeout,
                _ => (int)HttpStatusCode.InternalServerError
            };
            response.StatusCode = statusCode;

            var errorResponse = new
            {
                type = "https://httpstatuses.com/" + statusCode,
                title = "Xəta baş verdi",
                status = statusCode,
                detail = exception.Message,
                instance = context.TraceIdentifier,
                message = exception switch
                {
                    ArgumentException => "Etibarsız məlumatlar daxil edildi.",
                    KeyNotFoundException => "Tələb olunan resurs tapılmadı.",
                    FileNotFoundException => "Tələb olunan fayl tapılmadı.",
                    UnauthorizedAccessException => "İcazəsiz giriş cəhdi.",
                    InvalidOperationException => "Etibarsız əməliyyat yerinə yetirildi.",
                    NotImplementedException => "Bu xüsusiyyət hələ həyata keçirilməyib.",
                    TimeoutException => "Əməliyyat vaxtı bitdi.",
                    _ => "Gözlənilməz xəta baş verdi. Zəhmət olmasa sonra yenidən cəhd edin."
                },
                inner = exception.InnerException?.Message
            };

            try
            {
                var jsonResponse = JsonSerializer.Serialize(errorResponse, new JsonSerializerOptions
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                    WriteIndented = true
                });
                await response.WriteAsync(jsonResponse);
            }
            catch (Exception serializationEx)
            {
                _logger.LogCritical(serializationEx, "Response serialization error.");
                response.StatusCode = (int)HttpStatusCode.InternalServerError;
                await response.WriteAsync("{\"status\":500,\"message\":\"Server error: Response creation failed.\"}");
            }
        }
    }
}