using Meoweb.Commons;

namespace Meoweb.Exceptions {

    public class WebApiException : Exception {

        public WebApiResult.Code ResultCode { get; set; }

        public WebApiException(string message) : base(message) { }

        public void Log() { }

    }
}
