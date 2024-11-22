using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Encrypt
{
    interface Icode
    {
        public string encoder(string FileText, int EncodeNumber);
        public string decoder(string text, int decodenumber);

    }
    interface IcryptedNumber
    {
        public int codedNumber1(string Origin, string Destination);
        public int codedNumber2(string Origin, string Destination);
    }
    interface Ihash
    {
        public  byte[] GetHash(string inputString);
        public  string GetHashString(string inputString);
    }
    
   /*
    public class Encoder :   Ihash ,IEncod,IcryptedNumber
    {
        public string Hash { get; private set; }
        public  byte[] GetHash(string inputString)
        {
            using (HashAlgorithm algorithm = SHA256.Create())
                return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }
        public  string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));
            Hash = sb.ToString();
            return sb.ToString();
        }
        public  int codedNumber1(string Origin, string Destination)
        {

            int EncodeNumber = 0;
            string tolower;
            tolower = Origin.ToLower();
            for (int i = 0; i < Origin.Length; i++)
            {
                EncodeNumber += tolower[i] - 'a';
            }
            tolower = Destination.ToLower();
            for (int i = 0; i < Destination.Length; i++)
            {
                EncodeNumber += tolower[i] - 'a';
            }
            //EncodeNumber = EncodeNumber % 26 ;        
            return EncodeNumber;
        }
        public  int codedNumber2(string Origin, string Destination)
        {
            int EncodeNumber = 0, og = 0, ds = 0;
            foreach (char c in Origin)
            {
                if (char.IsLetter(c))
                    og += c;
            }
            foreach (char c in Destination)
            {
                if (char.IsLetter(c))
                    ds += c;
            }
            EncodeNumber = (og * ds) / (og + ds);
            return EncodeNumber;
        }
        public  string encoder(string FileText, int EncodeNumber)
        {

            EncodeNumber = EncodeNumber % 26;
            StringBuilder EncodedFile = new StringBuilder();

            FileText = FileText.ToLower();

            int indexencodenumber = 0;
            char x;
            for (int i = 0; i < FileText.Length; i++)
            {
                if (char.IsLetter(FileText[i]))
                {

                    indexencodenumber = 'a' + (EncodeNumber + FileText[i] - 'a') % 26;
                    x = Convert.ToChar(indexencodenumber);
                    EncodedFile.Append(x);
                    //Console.WriteLine($"{indexencodenumber}    {x}   ");

                }
                else
                {
                    x = FileText[i];
                    EncodedFile.Append(x);
                }


            }
            return EncodedFile.ToString();
        }
    }*/
    /*
    public class Decoder : IDecode, Ihash , IcryptedNumber
    {
        public int codedNumber1(string Origin, string Destination)
        {

            int EncodeNumber = 0;
            string tolower;
            tolower = Origin.ToLower();
            for (int i = 0; i < Origin.Length; i++)
            {
                EncodeNumber += tolower[i] - 'a';
            }
            tolower = Destination.ToLower();
            for (int i = 0; i < Destination.Length; i++)
            {
                EncodeNumber += tolower[i] - 'a';
            }
            //EncodeNumber = EncodeNumber % 26 ;        
            return EncodeNumber;
        }
        public int codedNumber2(string Origin, string Destination)
        {
            int EncodeNumber = 0, og = 0, ds = 0;
            foreach (char c in Origin)
            {
                if (char.IsLetter(c))
                    og += c;
            }
            foreach (char c in Destination)
            {
                if (char.IsLetter(c))
                    ds += c;
            }
            EncodeNumber = (og * ds) / (og + ds);
            return EncodeNumber;
        }
        public  string decoder(string text, int decodenumber)
        {
            decodenumber = decodenumber % 26;
            StringBuilder DecodedFile = new StringBuilder();
            char x;
            int indexdecodenumber = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (char.IsLetter(text[i]))
                {
                    indexdecodenumber = 'a' + (26 - decodenumber + (text[i] - 'a')) % 26;
                    x = Convert.ToChar(indexdecodenumber);
                    DecodedFile.Append(x);
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

    }*/

}
