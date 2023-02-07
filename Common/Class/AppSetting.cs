using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Common.Class
{
    public class AppSetting
    {
        public string AppPath
        {
            get
            {
                if (ConfigurationManager.AppSettings["AppPath"] != null)
                {
                    return ConfigurationManager.AppSettings["AppPath"].ToString();
                }
                else
                {
                    return Application.StartupPath;
                }
            }
        }

        private string _LogDir;
        public string LogDir
        {
            get
            {
                if (string.IsNullOrEmpty(_LogDir))
                {
                    _LogDir = MyApp.Common.PathCombine(AppPath, "Logs");
                }

                if (Directory.Exists(_LogDir) == false)
                {
                    Directory.CreateDirectory(_LogDir);
                }
                return _LogDir;
            }
        }

        private string _DBConnStr = string.Empty;
        public string DBConnStr
        {
            get
            {
                if (string.IsNullOrEmpty(_DBConnStr))
                {
                    _DBConnStr = ConfigurationManager.ConnectionStrings["DBConnStr"].ConnectionString;
                }
                return _DBConnStr;
            }
        }

        public string EncryptionKey
        {
            get { return ConfigurationManager.AppSettings["EncryptionKey"].ToString(); }
        }

        public string APIUrl
        {
            get { return ConfigurationManager.AppSettings["APIUrl"].ToString(); }
        }

        public int TimeOut
        {
            get { return ConfigurationManager.AppSettings["TimeOut"].ToInt(); }
        }

        public bool IsOnline { get { return true; } }
    }
}
