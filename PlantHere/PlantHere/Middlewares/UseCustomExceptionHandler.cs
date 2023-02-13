using Microsoft.AspNetCore.Diagnostics;
using PlantHere.Application.Exceptions;
using PlantHere.WebAPI.CustomResults;
using System.Net;

namespace PlantHere.WebAPI.Middlewares
{
    public static class UseCustomExceptionHandler
    {
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ApplicationException => (int)HttpStatusCode.InternalServerError, //-- 400
                        ClientSideException => (int)HttpStatusCode.BadRequest, // -- 400,
                        NotFoundException => (int)HttpStatusCode.NotFound,// -- 404,
                        CustomValidationException => (int)HttpStatusCode.BadRequest, // -- 400,
                        KeyNotFoundException => (int)HttpStatusCode.BadRequest, // -- 400
                        ConflictException => (int)HttpStatusCode.Conflict, // -- 409
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = CustomResult<NoContentResult>.Fail(statusCode, exceptionFeature.Error.Message);

                    await context.Response.WriteAsync(System.Text.Json.JsonSerializer.Serialize(response));

                });

            });
        }
    }
}
