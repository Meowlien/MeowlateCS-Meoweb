using Meoweb.Commons;
using System.Net;

namespace Meoweb.Middlewares {
    public class SampleMiddleware : MiddlewareTemplate {

        public SampleMiddleware(RequestDelegate next, ILogger<SampleMiddleware> logger, bool isReply)
        : base(next, logger, isReply) {
            // do something.
        }

        public override async Task InvokeAsync(HttpContext context) {

            // todo:
            logger.LogInformation(">>>> I'm Sample Middleware");

            await next(context);
        }

    }
}
