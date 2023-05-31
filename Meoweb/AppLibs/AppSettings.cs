

namespace Meoweb.AppLibs {

    public static class AppSettings {

        /// <summary>
        /// 設置請求正文緩衝區大小為 1MB
        /// </summary>
        public static int MaxRequestBodyBufferSize { get; } = 1 * (1024 * 1024);

        /// <summary>
        /// 跨域-許可清單
        /// </summary>
        public static List<string> Origins { get; set; } = new() {
            "https://localhost:80",
        };

        // 資料庫-連綫口號
        public static string DbConnectionStr { get; set; } = "";

    }

}
