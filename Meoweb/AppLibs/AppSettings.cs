

namespace Meoweb.AppLibs {

    /// <summary>
    /// 設置請求正文緩衝區大小為 1MB
    /// </summary>
    public static class AppSettings {

        /// <summary>
        /// 設置請求正文緩衝區大小為 1MB
        /// </summary>
        public static int MaxRequestBodyBufferSize { get; set; } = 1 * (1024 * 1024);

        /// <summary>
        /// 資料庫-連綫口號
        /// </summary>
        public static string DbConnectionStr { get; set; } = "";

    }

}
