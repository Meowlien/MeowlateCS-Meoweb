using System.Net;
using System.Text.Json;
using Meoweb.Commons.Data;

namespace Meoweb.Commons {

    /// <summary>
    /// 中間件-模板
    /// </summary>
    public abstract class MiddlewareTemplate {

        public bool IsReplyEnabled { get; protected set; }
        // 需直接改動内容，因此屬性作爲值類型並不適合, 但爲了可讀性及一致性，變數名稱依舊以屬性命名慣例
        protected Result ResponseData = new(); // { get; set; }

        protected readonly RequestDelegate next;
        protected readonly ILogger logger;


        public MiddlewareTemplate(RequestDelegate next, ILogger logger, bool isReply) {
            this.next = next;
            this.logger = logger;
            IsReplyEnabled = isReply;
        }

        public virtual async Task InvokeAsync(HttpContext context) {
            await next(context);
        }

        public virtual void BuildResult(HttpStatusCode code, string? msg = null) {
            ResponseData.ResultCode = (int)code;
            ResponseData.ResultMsg = msg ?? "";
        }

        public virtual async Task BuildJsonResponse(HttpContext context) {
            context.Response.StatusCode = ResponseData.ResultCode;
            context.Response.ContentType = "application/json";
            var json = JsonSerializer.Serialize(ResponseData);
            await context.Response.WriteAsync(json);
        }

    }
}
