using Meoweb.Commons;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Text;

namespace Meoweb.Example.Middlewares {

    public class RequestBodyReaderMiddleware : MiddlewareTemplate {

        public RequestBodyReaderMiddleware(RequestDelegate next, ILogger<RequestBodyReaderMiddleware> logger, bool isReply = false)
        : base(next, logger, isReply) {
            // do something.
        }

        public override async Task InvokeAsync(HttpContext context) {
            var request = context.Request;
            if (request.Method != HttpMethods.Post) {
                await next(context);
                return;
            }

            // 在请求正文中读取指定长度的字节
            using var memoryStream = new MemoryStream();
            await request.BodyReader.CopyToAsync(memoryStream);
            memoryStream.Seek(0, SeekOrigin.Begin);
            // 重新设置请求正文
            request.Body = memoryStream;
            //Console.WriteLine($"TTTT: {memoryStream.Length}");

            // 执行下一个中间件
            await next(context);
        }

    }

}
