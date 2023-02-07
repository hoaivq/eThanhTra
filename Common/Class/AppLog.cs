﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;

namespace Common.Class
{
    public class AppLog
    {
        private string BreakLine = "==================================================";

        public void GhiLog(string Title, List<Exception> exceptions)
        {
            try
            {
                foreach (Exception ex in exceptions)
                {
                    GhiLog(Title, ex);
                }
            }
            catch { }
        }
        public void GhiLog(string Title, string ErrContent, params string[] MoreInfos)
        {
            try
            {
                StringBuilder sbMoreInfos = new StringBuilder();
                foreach (string item in MoreInfos)
                {
                    sbMoreInfos.AppendLine(item);
                }
                string FilePath = Path.Combine(MyApp.Setting.LogDir, "ActLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                File.AppendAllText(FilePath, Environment.NewLine + BreakLine + Environment.NewLine + "Title: " + Title + Environment.NewLine + "Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine + "Message: " + ErrContent + Environment.NewLine + "More Info: " + sbMoreInfos.ToString());
            }
            catch { }
        }
        public void GhiLog(string Title, Exception ex, params string[] MoreInfos)
        {
            try
            {
                StringBuilder sbMoreInfos = new StringBuilder();
                foreach (string item in MoreInfos)
                {
                    sbMoreInfos.AppendLine(item);
                }
                string FilePath = Path.Combine(MyApp.Setting.LogDir, "ErrLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                File.AppendAllText(FilePath, Environment.NewLine + BreakLine + Environment.NewLine + "Title: " + Title + Environment.NewLine + "Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine + "StackTrace: " + ex.StackTrace + ((ex.InnerException == null) ? "" : Environment.NewLine + "Inner: " + ex.InnerException) + ((sbMoreInfos.ToString() == "") ? "" : Environment.NewLine + "More Info: " + sbMoreInfos.ToString()));
            }
            catch { }
        }
        public void GhiLog(string Title, Exception ex, string TSQL, SqlParameter[] myParamArr)
        {
            try
            {
                StringBuilder sbMoreInfos = new StringBuilder(TSQL);
                if (myParamArr != null && myParamArr.Length > 0)
                {
                    foreach (var p in myParamArr)
                    {
                        sbMoreInfos.AppendLine(p.ParameterName + " : " + p.Value);
                    }

                }
                string FilePath = Path.Combine(MyApp.Setting.LogDir, "ErrLog_" + DateTime.Now.ToString("yyyyMMdd") + ".txt");
                File.AppendAllText(FilePath, Environment.NewLine + BreakLine + Environment.NewLine + "Title: " + Title + Environment.NewLine + "Date: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + Environment.NewLine + "Message: " + ex.Message + Environment.NewLine + "StackTrace: " + ex.StackTrace + ((ex.InnerException == null) ? "" : Environment.NewLine + "Inner: " + ex.InnerException) + ((sbMoreInfos.ToString() == "") ? "" : Environment.NewLine + "More Info: " + sbMoreInfos.ToString()));
            }
            catch { }
        }
    }
}
