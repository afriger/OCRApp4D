using System;
using System.Diagnostics;
using System.IO;

namespace nsutils
{
    public static class ExtensionZone
    {
        public const int _NOTRACE = -1;
        public const int _TRACE = 0;
        public const int _COMPARE = 5;
        public const int _S2AVETOFILE = 7;
        private const int m_ERROR = 0;//errors to console
        private static string m_path;
        public static (int, int) m_score = (0, 0);
        public static (int, int) Score { get => m_score; set => m_score = value; }
        public static string path { get => m_path; set => m_path = value; }

        public static (int, int) add(this (int, int) a, (int, int) b)
        {
            return (a.Item1 + b.Item1, a.Item2 + b.Item2);
        }
        public static void err(this int k, string format, params object[] parms)
        {
            string msg = string.Format(format, parms);
            err(k, msg);
        }
        public static void err(this int k, Exception e)
        {
            StackTrace stackTrace = new StackTrace(true);
            try
            {
                StackFrame stackframe = stackTrace.GetFrame(1);
                string fn = System.IO.Path.GetFileName(stackframe.GetFileName());
                string method = stackframe.GetMethod().Name;
                int line = stackframe.GetFileLineNumber();
                int col = stackframe.GetFileColumnNumber();
                string msg = ($"{fn}::{method}({line},{col}):{e.Source}::{e.Message}");
                err(k, msg);
            }
            catch
            {
                Console.WriteLine("{0}::Exception occurs", e.GetType().Name);
            }
        }
        public static void err(this int k, string msg)
        {
            Console.ForegroundColor = ConsoleColor.DarkRed;
            m_ERROR.log(msg);//Always to console
            Console.ResetColor();
        }
        public static void log(this int k, string format, params object[] parms)
        {
            string msg = string.Format(format, parms);
            log(k, msg);
        }

        public static void log(this int k, string msg)
        {
            if (k < 0)
            {
                return;
            }

            if (k == 0)
            {
                Console.WriteLine(msg);
                return;
            }
            if (k == 5)//check
            {
                try
                {
                    string pattern_of = System.IO.File.ReadAllText(path);
                    string fn = Path.GetFileNameWithoutExtension(path);
                    int kp = pattern_of.CompareTo(msg);
                    if (0 != kp)
                    {
                        m_score.Item1++;
                    }
                    m_score.Item2++;
                    Console.WriteLine("{0} - {1}", fn, (kp == 0) ? "passed" : "failed");
                }
                catch (Exception e)
                {
                    err(k, e);
                }
                return;
            }
            if (k == 7 && !path.IsBogus())//to file
            {
                Console.WriteLine(msg);
                System.IO.File.WriteAllText(path, msg);
                path = null;
                return;
            }
        }
        #region string extension
        public static bool IsBogus(this string str)
        {
            return (string.IsNullOrEmpty(str) || string.IsNullOrWhiteSpace(str));
        }
        #endregion

    }//class ExtensionZone
    public class Utils
    {


    }//class Utils
}
