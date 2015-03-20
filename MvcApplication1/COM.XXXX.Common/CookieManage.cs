/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：CookieManage
// 文件功能描述：
//
// 创建标识：xycui 2014/7/21 16:44:41
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Com.XXXX.Common
{
    /// <summary> 
    /// Cookie操作类
    /// </summary>
    public class CookieManage
    {
        private HttpResponse Response {
            get { return HttpContext.Current.Response; }
        }
        private HttpRequest Request
        {
            get { return HttpContext.Current.Request; }
        }
        /// <summary>
        /// 将键值对写入cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expires"></param>
        public void WriteCookie(string key, string value, double expires = 0)
        {
            var mycookie = new HttpCookie(key)
            {
                Value = value,
                Expires = DateTime.Now.AddDays(expires)
            };
            Response.AppendCookie(mycookie);
        }

        /// <summary>
        /// 将键值对读出
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public string ReadCookie(string key)
        {
            if (Request.Cookies.Get(key) != null)
            {
                var httpCookie = Request.Cookies[key];
                if (httpCookie != null) return httpCookie.Value;
            }
            return string.Empty;
        }

        /// <summary>
        /// 将对象写入到Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="obj"></param>
        /// <param name="expires"></param>
        public void WriteObject2Cookie(string key, object obj, double expires=0)
        {
            using (var ms = new MemoryStream())
            {
                new BinaryFormatter().Serialize(ms, obj);
                ms.Flush();
                var cookie = new HttpCookie(key)
                                        {
                                            Expires = DateTime.Now.AddDays(expires),
                                            Value = System.Convert.ToBase64String(ms.ToArray())
                                        };

                Response.Cookies.Add(cookie);
            }
        }

        /// <summary>
        /// 将对象从Cookie中读出
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public object ReadFromCookie(string key)
        {
            var httpCookie = Request.Cookies[key];
            if (httpCookie != null)
            {
                byte[] bytes = System.Convert.FromBase64String(httpCookie.Value);  //将得到的字符串根据相同的编码格式分成字节数组

                var ms = new MemoryStream(bytes, 0, bytes.Length);  //从字节数组中得到内存流

                if (bytes.Length == 0) return null;

                return new BinaryFormatter().Deserialize(ms);  //反序列化得到对象
            }
            return null;
        }

        public void Clear()
        {
            Request.Cookies.Clear();
            Response.Cookies.Clear();
        }
    }
}
