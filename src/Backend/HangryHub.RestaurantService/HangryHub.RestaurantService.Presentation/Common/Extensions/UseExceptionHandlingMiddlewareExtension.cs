using HangryHub.RestaurantService.Presentation.Common.Middlewares;
using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HangryHub.RestaurantService.Presentation.Common.Extensions;

public static class UseExceptionHandlingMiddlewareExtension
{
    public static void UseExceptionHanlingMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlingMiddleware>();
    }
}
