/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：Log4NetHelper
// 文件功能描述：
//
// 创建标识：xycui 2014/9/24 9:48:10
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Com.Cngrain.SmartDepotMonitorOnLine.WindowsServer
{
    public class Log4NetHelper
    {
        private static readonly log4net.ILog logerror = log4net.LogManager.GetLogger("logerror");

        private  static  Log4NetHelper log4NetHelper=new Log4NetHelper();

        private Log4NetHelper()
        {
        }

        public static Log4NetHelper CreateInstance()
        {
            return log4NetHelper;
        } 

      

        public  void SetConfig()
        {
            log4net.Config.DOMConfigurator.Configure();
        }

        public  void SetConfig(FileInfo configFile)
        {
            log4net.Config.DOMConfigurator.Configure(configFile);
        }

        public  void WriteLog(string info)
        {
            if (logerror.IsInfoEnabled)
            {
                logerror.Error(info);
            }
        }

        public  void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}
