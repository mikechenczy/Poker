using System;

namespace Poker.Utils
{
    /// <summary>
    /// 文件辅助类
    /// </summary>
    internal static class FileUtil
    {


        /// <summary>
        /// 从当前执行程序集资源文件中抽取资源文件
        /// </summary>
        /// <param name="resFileName">输出文件路径</param>
        /// <param name="b">文件内容</param>
        public static void ExtractResFile(string path, byte[] b)
        {
            FileManager.UncompressFile(path, b);
        }

        internal static void ExtractResFile(string v, object v2ray)
        {
            throw new NotImplementedException();
        }
    }
}
