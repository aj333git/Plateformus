using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
namespace Plateformus {
   public class ClassBasedMiddleWare {
        private RequestDelegate? next;

        public ClassBasedMiddleWare() {
            // do nothing
        }

        public ClassBasedMiddleWare(RequestDelegate nextDelegate) {
            next = nextDelegate;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Method == HttpMethods.Get
                        && context.Request.Query["custom"] == "true") {
                if (!context.Response.HasStarted) {
                    context.Response.ContentType = "text/plain";
                }
                await context.Response.WriteAsync("Class-based Middleware \n");
            }
            if (next != null) {
                await next(context);
            }
        }
    }
    public class GymMiddleware {
        private RequestDelegate next;
        private GymOptions options;

        public GymMiddleware(RequestDelegate nextDelegate,
                IOptions<GymOptions> opts) {
            next = nextDelegate;
            options = opts.Value;
        }

        public async Task Invoke(HttpContext context) {
            if (context.Request.Path == "/gym") {
                await context.Response
                    .WriteAsync($"{options.Machine_Name}, {options.Category_Name}");
            } else {
                await next(context);
            }
        }
    }



}
