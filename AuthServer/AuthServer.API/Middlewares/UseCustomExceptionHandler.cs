using AuthServer.API.CustomResponses;
using AuthServer.Application.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using System.Net;
using System.Text.Json;

namespace AuthServer.API.Middlewares
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

                    var errorFeature = context.Features.Get<IExceptionHandlerFeature>();

                    if (errorFeature != null)
                    {
                        var ex = errorFeature.Error;

                        ErrorResponse errorResponse = null;

                        var statusCode = errorFeature.Error switch
                        {
                            ApplicationException => (int)HttpStatusCode.InternalServerError, //-- 500
                            ClientSideException => (int)HttpStatusCode.BadRequest, //-- 400
                            NotFoundException => (int)HttpStatusCode.NotFound,// -- 404,
                            KeyNotFoundException => (int)HttpStatusCode.BadRequest, // -- 400
                            _ => 500
                        };

                        context.Response.StatusCode = statusCode;

                        if (statusCode != 500)
                        {
                            errorResponse = new ErrorResponse(ex.Message, true);
                        }
                        else
                        {
                            errorResponse = new ErrorResponse(ex.Message, false);
                        }

                        var response = CustomResponse<NoContentResponse>.Fail(errorResponse, statusCode);

                        await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                    }
                });
            });
        }
    }

}

