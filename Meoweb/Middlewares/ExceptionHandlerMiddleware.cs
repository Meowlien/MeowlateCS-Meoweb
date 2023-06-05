using System.Net;
using System.Text.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Meoweb.Commons;

namespace Meoweb.Example.Middlewares {

    public class ExceptionHandlerMiddleware : MiddlewareTemplate {

        public ExceptionHandlerMiddleware(RequestDelegate next, ILogger<ExceptionHandlerMiddleware> logger, bool isReply = false)
        : base(next, logger, isReply) {
            // do something.
        }

        public override async Task InvokeAsync(HttpContext context) {

            try {
                await next(context);
            } 
            catch (InvalidOperationException ex) {
                var source = ex.Source;

                switch (source) {
                    // Error: 注冊時
                    case "Microsoft.Extensions.DependencyInjection.Abstractions": {
                        BuildResult(HttpStatusCode.InternalServerError, ErrorInfo.ToMessage(ErrorInfo.Code.DI));
                        logger.LogError("Exception Handler >> " + ErrorInfo.ToMessage(ErrorInfo.Code.DI));
                        break;
                    }
                    // Error: 預設定義
                    default: {
                        BuildResult(HttpStatusCode.InternalServerError, ex.Message);
                        logger.LogError("Exception Handler >> " + ex.Message);
                        break;
                    }
                }

            }
            catch (Exception ex) {
                // 处理异常，例如记录日志、返回自定义错误响应等
                BuildResult(HttpStatusCode.InternalServerError, ex.Message);
                logger.LogError("Exception Handler >> " + ex.Message);
            } 
            finally {
                if (IsReplyEnabled) {
                    await BuildJsonResponse(context);
                }
            }
        }

    }

    // 錯誤資訊
    public static class ErrorInfo {

        public enum Code {
            DI = 0
        }

        public static string? ToMessage(this Code code) {
            return code switch {
                Code.DI => $"({(int)Code.DI}) Code.DI", // 找不到指定類型的服務(例如：資料庫上下文未注冊)
                _ => null, //           /*  XXX */ => $"Undefine Message Info",
            };
        }

    }


}
