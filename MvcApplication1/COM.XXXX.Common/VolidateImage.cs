/*----------------------------------------------------------------
// Copyright (C) 2014 郑州华粮科技股份有限公司
// 版权所有。 
//
// 文件名：VolidateImage
// 文件功能描述：
//
// 创建标识：xycui 2014/7/24 11:16:41
//
// 修改标识：
// 修改描述：
//----------------------------------------------------------------*/
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Com.XXXX.Common
{
    public class VolidateImage
    {
        public int Height { get; set; }
        public int Width { get; set; }
        public Color Background { get; set; }
        public Color FontColor { get; set; }
        public string FontFamily { get; set; }
        public int FontSize { get; set; }
        public int ForeNoise { get; set; }
        public int BackgroundNoise { get; set; }

        private const string CharSet = "abcdefghijklmnopqrstuvwxyz123456789";

        public VolidateImage(int height, int width,Color backgroundcolor,Color fontcolor,string fontFamily="",int fontsize=9,int forenoise=5,int backgroundnosie=5)
        {
            this.Height = height; 
            this.Width = width;
            this.Background = backgroundcolor;
            this.FontColor = fontcolor;
            this.FontFamily = fontFamily;
            this.FontSize = fontsize;
            this.BackgroundNoise = backgroundnosie;
            this.ForeNoise = forenoise;
        }


        /// <summary>
        /// 创建图片，绘画字符串
        /// </summary>
        /// <param name="charset"></param>
        /// <returns></returns>
        public Bitmap CreateImage(string charset)
        {
            Random rdm = new Random();
            Bitmap bitmap= new Bitmap(this.Width, this.Height);
            using (Graphics graphics = Graphics.FromImage(bitmap))
            {
                graphics.SmoothingMode=SmoothingMode.HighQuality;
                graphics.Clear(this.Background);
                using (SolidBrush solid = new SolidBrush(this.FontColor))
                {
                    AddForeNoisePoint(bitmap);
                    AddBackgroundNoisePoint(bitmap,graphics);
                    StringFormat objStringFormat = new StringFormat(StringFormatFlags.NoClip);
                    objStringFormat.Alignment = StringAlignment.Center;
                    objStringFormat.LineAlignment = StringAlignment.Center;
                    Font objFont = new Font(this.FontFamily, rdm.Next(this.FontSize - 3, this.FontSize), FontStyle.Regular);

                    graphics.TranslateTransform(12, 12);
                    graphics.RotateTransform(rdm.Next(-10,10));
                    graphics.DrawString(charset,objFont,solid,9,1,objStringFormat);
                }
            }
            return bitmap;

        }

        /// <summary>
        /// 生成4个随机字符串
        /// </summary>
        /// <returns></returns>
        public string CreateShowString()
        {
            StringBuilder sb=new StringBuilder();
            char[] chars = CharSet.ToCharArray();
            for (int i = 0; i < 4; i++)
            {
                sb.Append(chars[RNG.Next(0, chars.Length-1)]);
            }
            return sb.ToString();
        }


        /// <summary>
        /// 添加前景噪点
        /// </summary>
        /// <param name="objBitmap"></param>
        private void AddForeNoisePoint(Bitmap objBitmap)
        {
            Random rdm = new Random();
            for (int i = 0; i < objBitmap.Width * this.ForeNoise; i++)
            {
                objBitmap.SetPixel(rdm.Next(objBitmap.Width), rdm.Next(objBitmap.Height), this.FontColor);
            }
        }
        /// <summary>
        /// 添加背景噪点
        /// </summary>
        /// <param name="objBitmap"></param>
        /// <param name="objGraphics"></param>
        private void AddBackgroundNoisePoint(Bitmap objBitmap, Graphics objGraphics)
        {
            Random rdm = new Random();
            using (Pen objPen = new Pen(Color.Azure, 0))
            {
                for (int i = 0; i < objBitmap.Width * 2; i++)
                {
                    objGraphics.DrawRectangle(objPen, rdm.Next(objBitmap.Width), rdm.Next(objBitmap.Height), 1, 1);
                }
            }
        }

    }
}
