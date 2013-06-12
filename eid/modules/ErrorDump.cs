using System;
using System.Linq;
using System.Text;
using System.IO;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Collections.Generic;

namespace eid
{
    class ErrorDump
    {
        # region 'Constructor
        public ErrorDump()
        {

        }

        public ErrorDump(string ErrorLogFileNamePath)
        {
            mErrorFileNameAndPath = ErrorLogFileNamePath;
        }

        # endregion 'Constructor

        # region 'PublicAndPrivateVariables

        public enum ErrorDumpErrorLogType
        {
            Information = 0, Warning = 1, Critical = 2
        }
                
        private string mcCompany=Application.CompanyName;     
        private static string mErrorFile = "\\Errorlog.txt";
        private string mcProductName = Application.ProductName;      
        private string mcProductVersion = Application.ProductVersion;
        private static string _ExecutablePath = Application.StartupPath;
        private string mErrorFileNameAndPath = _ExecutablePath + mErrorFile;
        private static string mErrorLogFileNamePath = _ExecutablePath + mErrorFile;
        private string mAppInfo = Application.ProductName + "Version:" + Application.ProductVersion;

        # endregion 'PublicAndPrivateVariables

        # region 'PublicMethods
        public void WriteToErrorLog(ErrorDumpErrorLogType LogType, Exception ex_param, string Comment)
        {
            FileStream fs = null;
            StreamWriter sw = null;
            string t = string.Empty;

            if (ex_param == null || Comment.Trim().Length == 0)
            {
                //do nothing
            }
            else
            {
                try
                {
                    fs = new FileStream(mErrorFileNameAndPath, FileMode.Append, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    switch (LogType)
                    {
                        case ErrorDumpErrorLogType.Critical:
                            t = "Critical";
                            break;
                        case ErrorDumpErrorLogType.Warning:
                            t = "Warning";
                            break;
                        case ErrorDumpErrorLogType.Information:
                            t = "Information";
                            break;
                    }

                    sw.Write("App:" + mAppInfo);
                    sw.Write(" ");
                    sw.Write("Type:" + t);
                    sw.Write(" ");
                    sw.Write("Message" + ex_param);
                    sw.Write(" ");
                    sw.Write("Comment" + Comment);
                    sw.Write(" ");
                    sw.Write("TargetSite" + ex_param.TargetSite);
                    sw.Write(" ");
                    sw.Write("StackTrace" + ex_param.StackTrace);
                    sw.Write(" ");
                    sw.Write("Date/Time" + DateTime.Now.ToString() + "UTC:" + DateTime.UtcNow);
                    sw.Write(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

            public void WriteToSQLErrorLog(ErrorDumpErrorLogType LogType, MySqlException ex_param, string Comment)
            {
            FileStream fs = null;
            StreamWriter sw = null;
            string t = string.Empty;

            if (ex_param == null || Comment.Trim().Length == 0)
            {
                //do nothing
            }
            else
            {
                try
                {
                    fs = new FileStream(mErrorFileNameAndPath, FileMode.Append, FileAccess.Write);
                    sw = new StreamWriter(fs);
                    switch (LogType)
                    {
                        case ErrorDumpErrorLogType.Critical:
                            t = "Critical";
                            break;
                        case ErrorDumpErrorLogType.Warning:
                            t = "Warning";
                            break;
                        case ErrorDumpErrorLogType.Information:
                            t = "Information";
                            break;
                    }

                    sw.Write("App:" + mAppInfo);
                    sw.Write(" ");
                    sw.Write("Type:" + t);
                    sw.Write(" ");
                    sw.Write("Message" + ex_param);
                    sw.Write(" ");
                    sw.Write("Comment" + Comment);
                    sw.Write(" ");
                    sw.Write("TargetSite" + ex_param.TargetSite);
                    sw.Write(" ");
                    sw.Write("Native" + ex_param.Source);
                    sw.Write(" ");
                    sw.Write("StackTrace" + ex_param.StackTrace);
                    sw.Write(" ");
                    sw.Write("Date/Time" + DateTime.Now.ToString() + "UTC:" + DateTime.UtcNow);
                    sw.Write(" ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            # endregion Property
        }
    }
}