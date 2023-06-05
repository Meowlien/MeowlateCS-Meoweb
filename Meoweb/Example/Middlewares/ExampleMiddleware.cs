using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Net;
using Meoweb.Commons;


namespace Meoweb.Example.Middlewares {
    public class ExampleMiddleware : MiddlewareTemplate {

        public ExampleMiddleware(RequestDelegate next, ILogger<ExampleMiddleware> logger, bool isReply)
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

