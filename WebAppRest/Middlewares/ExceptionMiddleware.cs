using System.Net;
using System.Text.Json;

namespace WebAppRest.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context); // Ejecuta la siguiente capa
                // Verifica si el código de respuesta es 415 (Unsupported Media Type)
                if (context.Response.StatusCode == (int)HttpStatusCode.UnsupportedMediaType)
                {
                    await HandleUnsupportedMediaTypeAsync(context);
                }
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            //response.StatusCode = (int)HttpStatusCode.InternalServerError;
            // Código de error por defecto (500 - Internal Server Error)
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string errorType = "Internal Server Error";

            // Si la excepción es de tipo conocido, se puede personalizar el código de estado
            if (exception is UnauthorizedAccessException)
            {
                statusCode = (int)HttpStatusCode.Unauthorized;//401
                errorType = "Unauthorized";
            }
            else if (exception is ArgumentException || exception is InvalidOperationException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;//400
                errorType = "Bad Request";
            }
            else if (exception is NotSupportedException)
            {
                statusCode = (int)HttpStatusCode.UnsupportedMediaType;//415
                errorType = "Unsupported Media Type";
            }
            else if (exception is KeyNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;//404
                errorType = "Not Found";
            }
            else if (exception is HttpRequestException)
            {
                statusCode = (int)HttpStatusCode.ServiceUnavailable;//503
                errorType = "Service Unavailable";
            }

            response.StatusCode = statusCode;
            var errorResponse = new
            {
                statusCode = statusCode,
                error = errorType,
                message = "Ocurrió un error en la solicitud.",
                details = exception.Message, // En producción, evita exponer detalles internos.
                traceId = context.TraceIdentifier,
                timestamp = DateTime.UtcNow.ToString("o"), // Formato ISO 8601
                path = context.Request.Path,
                method = context.Request.Method
            };

            //var errorResponse = new
            //{
            //    mensaje = "Ocurrió un error en el servidor",
            //    detalle = exception.Message // En producción, evita mostrar detalles internos
            //};
            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }

        private static Task HandleUnsupportedMediaTypeAsync(HttpContext context)
        {
            var response = context.Response;
            response.ContentType = "application/json";
            response.StatusCode = (int)HttpStatusCode.UnsupportedMediaType;

            var errorResponse = new
            {
                error = "Unsupported Media Type",
                mensaje = "El tipo de contenido enviado no es soportado. Verifica el header 'Content-Type'."
            };
            return response.WriteAsync(JsonSerializer.Serialize(errorResponse));
        }
    }
}
