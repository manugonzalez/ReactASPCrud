using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Helpers;

namespace ReactASPCrud.Helpers
{
    public static class JwtMiddlewareExtension
    {
        public static IApplicationBuilder UseJwtMiddlewsare(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<JwtMiddleware>();
        }
    }
}
