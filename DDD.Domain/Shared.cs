using System.Configuration;

namespace DDD.Domain
{
    /// <summary>
    /// Shared
    /// </summary>
    public static class Shared
    {
        /// <summary>
        /// Fakeの時True
        /// </summary>
        public static bool IsFake { get; } =
            ConfigurationManager.AppSettings["IsFake"] == "1";

        /// <summary>
        /// Fakeのパス
        /// </summary>
        public static string FakePath { get; } =
            ConfigurationManager.AppSettings["FakePath"];

        /// <summary>
        /// ログインID
        /// </summary>
        public static string LoginId { get; set; } = string.Empty;
    }
}
