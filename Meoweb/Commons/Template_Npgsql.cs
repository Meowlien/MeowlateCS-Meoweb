using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Meoweb.AppLibs;

namespace Meoweb.Commons {

    /// <summary>
    /// .Net PostgreSQL 資料庫上下文-模板
    /// </summary>
    public abstract class NpgsqlDbCtxTemplate : DbCtxTemplate {

        public NpgsqlDbCtxTemplate(ILogger logger) : base(logger) { }
        public NpgsqlDbCtxTemplate(DbContextOptions options, ILogger logger) : base(options, logger) { }


        /// <summary>
        /// 資料庫連綫設定
        /// </summary>
        /// <param name="optionsBuilder">
        ///     A builder used to create or modify options for this context. Databases (and other extensions)
        ///     typically define extension methods on this object that allow you to configure the context.
        /// </param>
        protected override void Connect(DbContextOptionsBuilder optionsBuilder) {

            // 取得 App 參數設定值
            var connStr = AppSettings.DbConnectionStr;

            // 兼容無資料庫
            if (connStr == "") {
                Logger.LogInformation("No database connecting string.");
                return;
            }

            // 使用 Npgsql 建立連綫
            optionsBuilder.UseNpgsql(connStr);
        }

    }
}
