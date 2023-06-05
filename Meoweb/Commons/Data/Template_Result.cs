

namespace Meoweb.Commons.Data {

    /// <summary>
    /// 資訊界面
    /// </summary>
    public interface IResult {
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; }
        public string? ToString();
    }

    /// <summary>
    /// 標準資訊容器
    /// </summary>
    public struct Result : IResult {
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; }
        public new string ToString() {
            return "\n" + base.ToString() + " {\n"
                + $"  >> ResultCode: {ResultCode}\n"
                + $"  >> ResultMsg: {ResultMsg}\n"
                + "}\n";
        }
    }

}
