using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SecurityLibrary.DES;

namespace SecurityLibrary.DES
{
    /// <summary>
    /// If the string starts with 0x.... then it's Hexadecimal not string
    /// </summary>
    public class TripleDES : ICryptographicTechnique<string, List<string>>
    {
        DES D = new DES();

        public string Decrypt(string cipherText, List<string> key)
        {
            string pt = "";

            pt = D.Decrypt(cipherText, key[1]);
            pt = D.Encrypt(pt, key[0]);
            pt = D.Decrypt(pt, key[1]);

            return pt;
        }

        public string Encrypt(string plainText, List<string> key)
        {
            string ct = "";

            ct = D.Encrypt(plainText, key[0]);
            ct = D.Decrypt(ct, key[1]);
            ct = D.Encrypt(ct, key[0]);

            return ct;
        }

        public List<string> Analyse(string plainText, string cipherText)
        {
            throw new NotSupportedException();
        }

    }
}