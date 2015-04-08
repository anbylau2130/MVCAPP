using COM.XXXX.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ICONTools
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog ofd = new FolderBrowserDialog();

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                txtfilepath.Text = ofd.SelectedPath;
            }
        }
        public  string DicPath = string.Empty; 

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtfilename.Text))
                {
                    MessageBox.Show("请输入文件名！");
                }
                if (string.IsNullOrEmpty(txtfilepath.Text))
                {
                    MessageBox.Show("请选择文件路径！");
                }
                DirectoryInfo dir = new DirectoryInfo(txtfilepath.Text);
                DicPath = dir.FullName;

                string content = GetIconCss(dir).ToString();

                FileWriter.Write(DicPath + "\\" + txtfilename.Text.Trim(), content);

                OpenFolderAndSelectFile(DicPath + "\\" + txtfilename.Text.Trim());
               
                MessageBox.Show("文件已经生成");
            }
            catch(Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }


        /// <summary>
        /// 打开并选中指定文件
        /// </summary>
        /// <param name="fileFullName"></param>
        private void OpenFolderAndSelectFile(String fileFullName)
        {
            System.Diagnostics.ProcessStartInfo psi = new System.Diagnostics.ProcessStartInfo("Explorer.exe");
            psi.Arguments = "/e,/select," + fileFullName;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// 遍历文件夹
        /// </summary>
        /// <param name="dir"></param>
        private StringBuilder GetIconCss(DirectoryInfo directory) {
            
            FileInfo[] files = directory.GetFiles();
            StringBuilder sb=new StringBuilder();
            foreach (FileInfo file in files)
            {

                string name = file.FullName.Replace(DicPath + "\\", "").Replace("\\", "-").Replace("_","-").Split('.')[0];
                string path = file.FullName.Replace(DicPath+"\\","").Replace("\\","/");

                if (file.Name.Contains('_'))
                {
                    name += name.Replace('_', '-');
                }

                 sb.AppendLine(".icon-"+name+"{background:url('icons/"+path+"') no-repeat center center;}");
            }

            DirectoryInfo[] dirs = directory.GetDirectories();

            foreach (DirectoryInfo dir in dirs)
            {
                sb.Append(GetIconCss(dir));
            }
            return sb;
        }


        private void button2_Click(object sender, EventArgs e)
        {
           
            try
            {
                if (string.IsNullOrEmpty(txtfilename.Text))
                {
                    MessageBox.Show("请输入文件名！");
                }
                if (string.IsNullOrEmpty(txtfilepath.Text))
                {
                    MessageBox.Show("请选择文件路径！");
                }
                DirectoryInfo dir = new DirectoryInfo(txtfilepath.Text);
                DicPath = dir.FullName;

                #region 如果新图标文件夹存在，则删除，否则自动创建
                DirectoryInfo dirnewIcon = new DirectoryInfo(DicPath + @"/NewIcon/");
                if (dirnewIcon.Exists == true)
                {
                    dirnewIcon.Delete(true);
                }
                else {
                    dirnewIcon.Create();
                }
                #endregion

                #region 文件重命名，只生成根目录下文件
                FileInfo[] files= dir.GetFiles();
                for (int i = 0; i < files.Length; i++)
			    {
                    files[i].CopyTo(Path.Combine(DicPath + @"/NewIcon/"+i+files[i].Extension));
                }
                #endregion
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

  
    }
}
