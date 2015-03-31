using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace COM.XXXX.Common
{
    public static class FileWriter
    {
        /// <summary>
        /// 将日志写入到文本内 
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Msg"></param>
        public static void Write(string Path, string Msg)
        {
            if (File.Exists(Path))
            {
                WriteFileExits(Path, Msg);
            }
            else
            {
                WriteFileNotExits(Path, Msg);
            }
        }

        /// <summary>
        /// 要写的文件存在，调用此方法进行数据追加
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Msg"></param>
        private static void WriteFileExits(string Path, string Msg)
        {
            using (FileStream fileStream = new FileStream(Path, FileMode.CreateNew))
            {
                using (BinaryWriter bw = new BinaryWriter(fileStream))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(Msg);
                    bw.Write(bytes);
                    //bw.Write("\r\n");
                    bw.Flush();
                }
            }
        }
        /// <summary>
        /// 要写的文件不存在，创建该文件，并进行写入
        /// </summary>
        /// <param name="Path"></param>
        /// <param name="Msg"></param>
        private static void WriteFileNotExits(string Path, string Msg)
        {
            using (FileStream fs = File.Create(Path))
            {
                using (BinaryWriter bw = new BinaryWriter(fs))
                {
                    byte[] bytes = Encoding.UTF8.GetBytes(Msg);
                    bw.Write(bytes);
                    //bw.Write("\r\n");
                    bw.Flush();
                }
            }
        }
    }
}
