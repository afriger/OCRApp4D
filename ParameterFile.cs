using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nsutils
{
    public class ParameterFile
    {

        static public Dictionary<string, string> FilePropertiesToDictionary(string fileName)
        {
            Dictionary<string, string> properties = new Dictionary<string, string>();
            string[] lines;
            try
            {
                lines = System.IO.File.ReadAllLines(fileName);
                foreach (string singleline in lines)
                {
                    string line = singleline.Trim();
                    if (CheckComment(line))
                    {
                        continue;
                    }
                    int pos = line.IndexOf('=');
                    if (pos < 0)
                    {
                        continue;
                    }
                    string key = line.Substring(0, pos);
                    string value = line.Substring(pos + 1);
                    if (!String.IsNullOrEmpty(key))
                    {
                        properties.Add(key.Trim(), value.Trim());

                    }
                    continue;
                }
            }
            catch (System.IO.FileNotFoundException exnotfound)
            {
                Console.WriteLine("EXC:ParameterFile: {0}", exnotfound.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("EXC:ParameterFile: {0}", ex.Message);
            }

            return properties;
        }

        private static string[] CommentSymbols = { "//", ";", "#" };
        static protected bool CheckComment(string line)
        {
            foreach (string commemt_symbol in CommentSymbols)
            {
                if (0 == line.IndexOf(commemt_symbol))
                {
                    return true;
                }
            }
            return false;
        }

    }// class ParameterFile
}
