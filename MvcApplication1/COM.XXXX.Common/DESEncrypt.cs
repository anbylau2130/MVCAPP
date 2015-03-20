/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：DESEncrypt
// 文件功能描述：
//
// 创建标识：xycui 2014/7/22 14:11:02
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Com.XXXX.Common
{
    ///<summary>
    /// DES加密与解密
    ///</summary>
    public class DESEncrypt
    {

        #region DES加密

        ///<summary>
        /// 使用默认密钥加密
        ///</summary>
        ///<param name="strText"></param>
        ///<returns></returns>
        public static string Encrypt(string strText)
        {
            return Encrypt(strText, "TSF");
        }

        ///<summary>
        /// 使用给定密钥加密
        ///</summary>
        ///<param name="strText"></param>
        ///<param name="sKey">密钥</param>
        ///<returns></returns>
        public static string Encrypt(string strText, string sKey)
        {
            DESCryptoServiceProvider des =new DESCryptoServiceProvider();
            byte[] inputByteArray = Encoding.Default.GetBytes(strText);
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms =new System.IO.MemoryStream();
            CryptoStream cs =new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            StringBuilder ret =new StringBuilder();
            foreach (byte b in ms.ToArray())
            {
                ret.AppendFormat("{0:X2}", b);
            }
            return ret.ToString();
        }

        #endregion

        #region DES解密

        ///<summary>
        /// 使用默认密钥解密
        ///</summary>
        ///<param name="strText"></param>
        ///<returns></returns>
        public static string Decrypt(string strText)
        {
            return Decrypt(strText, "TSF");
        }

        ///<summary>
        /// 使用给定密钥解密
        ///</summary>
        ///<param name="strText"></param>
        ///<param name="sKey"></param>
        ///<returns></returns>
        public static string Decrypt(string strText, string sKey)
        {
            DESCryptoServiceProvider des =new DESCryptoServiceProvider();
            int len = strText.Length /2;
            byte[] inputByteArray =new byte[len];
            int x, i;
            for (x =0; x < len; x++)
            {
                i = Convert.ToInt32(strText.Substring(x *2, 2), 16);
                inputByteArray[x] = (byte)i;
            }
            des.Key = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            des.IV = ASCIIEncoding.ASCII.GetBytes(System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(sKey, "md5").Substring(0, 8));
            System.IO.MemoryStream ms =new System.IO.MemoryStream();
            CryptoStream cs =new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write);
            cs.Write(inputByteArray, 0, inputByteArray.Length);
            cs.FlushFinalBlock();
            return Encoding.Default.GetString(ms.ToArray());
        }

        #endregion
    }
}
