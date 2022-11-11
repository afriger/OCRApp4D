using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Media.Imaging;
using static nsutils.ExtensionZone;

namespace Tesseractexe
{
    public class TesseractUsing
    {
        //@"C:\Program Files\Tesseract-OCR\tesseract.exe";
        //private readonly string m_default_tesseract_exe_path = @"C:\dev\OCR\cmd\tesseract-ocr-w64-setup-v5.2.0.20220712";//\tesseract.exe";
        private int Trace = 0;
        private readonly string m_tesseract_exe_path;
        private readonly string m_tesseract_exe = "tesseract.exe";

        private readonly string m_config = "config";
        private readonly string m_tessdata = "tessdata";

        private readonly string m_default_language = "eng+hes";
        private readonly string m_oem = "--oem 1";
        private readonly string m_proc_dir_name = "proc";
        private readonly string m_proc_dir;
        private readonly string m_outputFile;
        private static string m_inputFile;

        private string m_err_message = null;
        private string m_language;
        public static string InputFile { get => m_inputFile; }
        public string ErrorMessage { get => m_err_message; }
        public string Language { get => m_language; set => m_language = value; }


        public TesseractUsing()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            Dictionary<string, string> config = nsutils.ParameterFile.FilePropertiesToDictionary(Path.Combine(currentDirectory, m_config));
            if (config.Count != 0)
            {
                if (config.ContainsKey("tesseract_exe_path"))
                {
                    string path = config["tesseract_exe_path"];
                    string fn = Path.Combine(path, m_tesseract_exe);
                    if (!File.Exists(fn))
                    {
                        Trace.err($"Path '{fn}' not exists.");
                        throw new Exception($"Path '{fn}' not exists.");
                    }
                    m_tesseract_exe_path = path;
                }
                else
                {
                    Trace.err("Path to file \"tesseract.exe\" is unknown.");
                    throw new Exception("Path to file \"tesseract.exe\" is unknown.");
                }
                if (config.ContainsKey("language"))
                {
                    m_language = config["language"];
                }
                else
                {
                    m_language = m_default_language;
                }
            }

            m_proc_dir = Path.Combine(currentDirectory, m_proc_dir_name);
            if (!Directory.Exists(m_proc_dir))
            {
                Directory.CreateDirectory(m_proc_dir);
            }
            m_inputFile = Path.Combine(m_proc_dir, "img.png");
            m_outputFile = Path.Combine(m_proc_dir, "img");

            GetLangs();
            Trace.log("m_proc_dir:{0}", m_proc_dir);
        }
        public string GetInputFile()
        {
            return m_inputFile;
        }
        public string go()
        {
            var output = string.Empty;
            try
            {
                if (!File.Exists(m_inputFile))
                {
                    throw new Exception("Can't find the input image file.");
                }
                var info = new ProcessStartInfo
                {
                    FileName = Path.Combine(m_tesseract_exe_path, m_tesseract_exe),
                    Arguments = $"\"{m_inputFile}\" \"{m_outputFile}\" {m_oem} -l {m_language}",
                    RedirectStandardError = true,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true,
                    UseShellExecute = false
                };
                Trace.log("Arguments:{0}", info.Arguments);
                using (var ps = Process.Start(info))
                {
                    ps.WaitForExit();

                    var exitCode = ps.ExitCode;

                    if (exitCode == 0)
                    {
                        output = File.ReadAllText(m_outputFile + ".txt");
                    }
                    else
                    {
                        var stderr = ps.StandardError.ReadToEnd();
                        throw new InvalidOperationException(stderr);
                    }
                }
            }
            catch (Exception e)
            {
                m_err_message = e.Message;
                Trace.log(e.Message);
            }
            finally
            {
                //Directory.Delete(tempPath, true);
            }
            Trace.log(output);
            return output;
        }

        public List<string> GetLangs()
        {
            string tessdata = Path.Combine(m_tesseract_exe_path, m_tessdata);
            string[] files = Directory.GetFiles(tessdata, "*.traineddata");
            List<string> langs = new List<string>();
            foreach (string file in files)
            {
                string fn = Path.GetFileNameWithoutExtension(file);
                if (fn.Equals("osd", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }
                langs.Add(fn);
                Trace.log("Langs:{0}", file);
            }
            return langs;
        }
        public bool IsLeftToRight(string strCompare)
        {

            char[] chars = strCompare.ToCharArray();
            foreach (char ch in chars)
            {
                if (ch >= '\u0591' && ch <= '\u07FF') return true;
            }
            return false;
        }

        public bool ImageFromClipboard()
        {
            System.Windows.IDataObject d = System.Windows.Clipboard.GetDataObject();
            if (d.GetDataPresent(System.Windows.DataFormats.Bitmap))
            {
                BitmapSource b = (BitmapSource)d.GetData(System.Windows.Forms.DataFormats.Bitmap, true);
                Bitmap bmp = GetBitmap(b);
                bmp.Save(m_inputFile);
                return true;
            }
            return false;
        }

        public static Bitmap GetBitmap(BitmapSource source)
        {
            Bitmap bmp = new Bitmap(
              source.PixelWidth,
              source.PixelHeight,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            BitmapData data = bmp.LockBits(
              new System.Drawing.Rectangle(System.Drawing.Point.Empty, bmp.Size),
              ImageLockMode.WriteOnly,
              System.Drawing.Imaging.PixelFormat.Format32bppPArgb);
            source.CopyPixels(
              Int32Rect.Empty,
              data.Scan0,
              data.Height * data.Stride,
              data.Stride);
            bmp.UnlockBits(data);
            return bmp;
        }

        public void Screenshot()
        {
            Screen[] zz = Screen.AllScreens;
            return;
        }

    }//TesseractUsing
}
