using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace Encrypt
{
    public class FileManager  :Ihash,Icode,IcryptedNumber
    {
        public int codednumber = 0; 
        public string Hash { get; private set; }
        public byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            Hash = sb.ToString();
            return sb.ToString();
        }
        public bool CheckHash(string hash)
        {

            if (hash == Hash)
                return true;
            return false;
        }
        public int codedNumber1(string Origin, string Destination)
        {

            int EncodeNumber = 0;
            
            
            foreach(char c in Origin)
            {
                if (char.IsUpper(c))
                    EncodeNumber += 27 + c - 'A';
                else
                    EncodeNumber += 1+c - 'a';
                
            }

            foreach (char c in Destination)
            {
                if (char.IsUpper(c))
                    EncodeNumber += 27 + c - 'A';
                else
                    EncodeNumber += 1+c - 'a';
                
            }
            //EncodeNumber = EncodeNumber % 26 ;
            codednumber = EncodeNumber;
            return EncodeNumber;
        }
        public int codedNumber2(string Origin, string Destination)
        {
            int EncodeNumber = 0, og = 0, ds = 0;
            foreach (char c in Origin)
            {
                if (char.IsUpper(c))
                    EncodeNumber += 26 + c - 'A';
                else
                    EncodeNumber += 1 + c - 'a';

            }
            foreach (char c in Destination)
            {
                if (char.IsUpper(c))
                    EncodeNumber += 26 + c - 'A';
                else
                    EncodeNumber += 1 + c - 'a';
            }
            EncodeNumber = (og * ds) / (og + ds);
            codednumber = EncodeNumber;
            return EncodeNumber;
        }
        public string encoder(string FileText, int EncodeNumber)
        {

            EncodeNumber = EncodeNumber % 52;
            StringBuilder EncodedFile = new StringBuilder();
            int indexencodenumber = 0;
            char x;
            for (int i = 0; i < FileText.Length; i++)
            {
                if (char.IsLetter(FileText[i]))
                {
                    if (char.IsUpper(FileText[i]))
                    {
                        
                        indexencodenumber = 'A' + (EncodeNumber + FileText[i] - 'A') % 26;
                        x = Convert.ToChar(indexencodenumber);
                        EncodedFile.Append(x);
                    }
                    
                    //Console.WriteLine($"{indexencodenumber}    {x}   ");
                    else
                    {
                        indexencodenumber = 'a' + (EncodeNumber + FileText[i] - 'a') % 26;
                        x = Convert.ToChar(indexencodenumber);
                        EncodedFile.Append(x);
                    }
                }
                else
                {
                    x = FileText[i];
                    EncodedFile.Append(x);
                }


            }
            return EncodedFile.ToString();
        }
        public string decoder(string text, int decodenumber)
        {
            decodenumber = decodenumber % 52;
            StringBuilder DecodedFile = new StringBuilder();
            char x;
            int indexdecodenumber = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    if (char.IsUpper(text[i]))
                    {
                        indexdecodenumber = 'A' + (52 - decodenumber + (text[i] - 'A')) % 26;
                        x = Convert.ToChar(indexdecodenumber);
                        DecodedFile.Append(x);
                    }
                    else
                    {
                        indexdecodenumber = 'a' + (52 - decodenumber + (text[i] - 'a')) % 26;
                        x = Convert.ToChar(indexdecodenumber);
                        DecodedFile.Append(x);
                    }
                   
                    //Console.WriteLine($"{indexdecodenumber}    {x}   ");
                }
                else
                {
                    x = text[i];
                    DecodedFile.Append(x);
                }
            }

            return DecodedFile.ToString();
        }
    }
    public class TXTManager : FileManager
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
    public class CSVManager : FileManager 
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
        public string FileReder(string path)
        {
            if (!File.Exists(path))
                throw new FileNotFoundException();
            if(!r.IsMatch(path))
                throw new FileNotFoundException("file is not csv");
            return File.ReadAllText(path); 
        }
    }
    public class INIManager : FileManager
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
        public string FileReder(string Key, string Section = null)
        {
            var RetVal = new StringBuilder(255);
            GetPrivateProfileString(Section ?? EXE, Key, "", RetVal, 255, Path);
            return RetVal.ToString();
        }
    }
}
