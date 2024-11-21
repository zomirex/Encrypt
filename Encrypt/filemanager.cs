using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Encrypt
{

    public class TXTManager
    {
        public void FileWriter(string path, string text)
        {
            if (File.Exists(path))
            {
                // Create a file to write to.
                File.Delete(path);
            }
            using (StreamWriter sw = File.CreateText(path))
            {

                sw.WriteLine(text);
            }
        }
        public string Filereder(string path)
        { return File.ReadAllText(path); }
    }
    public class CSVManager
    {
        Regex r = new Regex(@"\.csv");
        public void FileWriter(string path, string text)

        {
            
            if (r.IsMatch(path))
            {
                if (File.Exists(path))
                {
                    // Create a file to write to.
                    File.Delete(path);
                }
                using (StreamWriter sw = File.CreateText(path))
                {

                    sw.WriteLine(text);
                }
            }
            else
                throw new Exception("thats nota csv file");

        }
        public string Filereder(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            if(!r.IsMatch(path))
                throw new FileNotFoundException("file is not csv");
            return File.ReadAllText(path); 
        }
    }
    public class INIManager
    {
        string Path;
        string EXE = Assembly.GetExecutingAssembly().GetName().Name;

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern long WritePrivateProfileString(string Section, string Key, string Value, string FilePath);

        [DllImport("kernel32", CharSet = CharSet.Unicode)]
        static extern int GetPrivateProfileString(string Section, string Key, string Default, StringBuilder RetVal, int Size, string FilePath);

        public INIManager(string IniPath = null)
        {
            Path = new FileInfo(IniPath ?? EXE + ".ini").FullName;
        }

        public void FileWriter(string Key, string Value, string Section = null)
        {
            WritePrivateProfileString(Section ?? EXE, Key, Value, Path);
        }
        public string Filereder(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
    }
}
