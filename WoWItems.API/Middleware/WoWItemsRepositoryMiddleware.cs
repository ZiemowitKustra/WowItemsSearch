using Newtonsoft.Json;
using WoWItems.API.Services;

namespace WoWItems.API.Middleware
{
    public class WoWItemsSecurityHeadersMiddleware
    {
        private readonly RequestDelegate _next;

        public WoWItemsSecurityHeadersMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext, PaginationMetadata metadata)
        {
            IHeaderDictionary headers = httpContext.Request.Headers;
            //headers["X-Pagination"] = JsonSerializer.Serialize(metadata, PaginationMetadata, httpContext);
        }
    }
}
