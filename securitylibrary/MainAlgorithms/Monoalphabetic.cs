using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityLibrary
{
    public class Monoalphabetic : ICryptographicTechnique<string, string>
    {
        public string Analyse(string plainText, string cipherText)
        { 
            cipherText = cipherText.ToLower();
            char[] arr = new char[26];// To Store the result KEY and return it at the end of the function
            bool[] ar = new bool[26];//boolean array to store the status of the char if it found in array or not
            bool[] aray = new bool[1000];//To check if the cipher is found or not
            for (int i = 0; i < plainText.Length; i++)//loop on the plain Text 
            {
                int ind = (int)plainText[i] - 'a';//To get the index of the char by subtract its ascci code from the start char a 
                arr[ind] = cipherText[i];//To store the index of the char in the array and store the cipher in it
                ar[ind] = true;//make the index visited 
                aray[cipherText[i]] = true;//make the cipher visited
            }
            for (int i = 0; i < 26; i++)// loop for the alphapete 
            {
                if (ar[i] == false)//check if the index is not visited
                {
                    for (int j = 0; j < 26; j++)//loop for all alpha
                    {
                        if (aray[(int)('a' + j)] != true)//break at the first not visited char and get its value
                        {
                            arr[i] = (char)(97 + j);
                            ar[i] = true;
                            aray[97 + j] = true;
                            break;
                        }
                    }
                }
            }
            // After all steps finally i have the key 
            string ret = String.Join("", arr);//To convert the char array to string that help me to print it and to return
            Console.WriteLine(arr);
            return ret;
        }

        public string Decrypt(string cipherText, string key)
        {
            string chars = "";//To Store the plain text in it and return it 
            cipherText = cipherText.ToLower();//To convert All Chars in cipher to lower
            for (int i = 0; i < cipherText.Length; i++)
            {
                int j = key.IndexOf(cipherText[i]) + 'a' ;//To get the ascci code of the cipertext[i] and add it to string
                chars+=(char)j;//adding to the string
                
            }
            return chars;
    
}

        public string Encrypt(string plainText, string key)
        {
            string ciph = "";//To store the cipher text and return it
            plainText = plainText.ToLower();//to convert the plain text to lower
            for (int i = 0; i < plainText.Length; i++)
            {
                int j = plainText[i] -'a';//di bt3rfni tarteb el7arf f el 7rof english 
                //ex : if plain is b so j must be 1 second char in english the assci code of b is 98 if i subtact the assci code of char 'a' i will get j
                //so j=1 //Tarteb el plain f english
                ciph +=(key[j]);//adding it to ciph
            }
            return ciph;
        }

        /// <summary>
        /// Frequency Information:
        /// E   12.51%
        /// T	9.25
        /// A	8.04
        /// O	7.60
        /// I	7.26
        /// N	7.09
        /// S	6.54
        /// R	6.12
        /// H	5.49
        /// L	4.14
        /// D	3.99
        /// C	3.06
        /// U	2.71
        /// M	2.53
        /// F	2.30
        /// P	2.00
        /// G	1.96
        /// W	1.92
        /// Y	1.73
        /// B	1.54
        /// V	0.99
        /// K	0.67
        /// X	0.19
        /// J	0.16
        /// Q	0.11
        /// Z	0.09
        /// </summary>
        /// <param name="cipher"></param>
        /// <returns>Plain text</returns>
        /// 

        public string AnalyseUsingCharFrequency(string cipher)
        {

            //throw new NotImplementedException();
            /*    string alphabetFreq = "ETAOINSRHLDCUMFPGWYBVKXJQZ".ToLower();
                 Dictionary<char, int> CAlphaFreq = new Dictionary<char, int>();
                 SortedDictionary<char, char> keyTable = new SortedDictionary<char, char>();
                 cipher = cipher.ToLower();
                 int CTLength = cipher.Length;
                 string key = "";
                 for (int i = 0; i < CTLength; i++)
                 {
                     if (!CAlphaFreq.ContainsKey(cipher[i]))
                     {
                         CAlphaFreq.Add(cipher[i], 0);
                     }
                     else
                     {
                         CAlphaFreq[cipher[i]]++;
                     }
                 }

                 CAlphaFreq = CAlphaFreq.OrderBy(x => x.Value).Reverse().ToDictionary(x => x.Key, x => x.Value);
                 int counter = 0;
                 foreach (var item in CAlphaFreq)
                 {
                     keyTable.Add(item.Key, alphabetFreq[counter]);
                     counter++;
                 }
                 for (int i = 0; i < CTLength; i++)
                 {
                     key += keyTable[cipher[i]];
                 }

                 return key; */

            /*
            string alphabetFreq = "ETAOINSRHLDCUMFPGWYBVKXJQZ".ToLower();
            char[] arrChar = new char[26];
            bool[] arrBool = new bool[26];
            cipher = cipher.ToLower();
            int CTLength = cipher.Length;
            int cnt = 0; 
            for (int i = 0; i < CTLength; i++) {
                if (!arrChar.Contains(cipher[i])) {
                    arrChar[cnt] = cipher[i];
                    arrBool[cnt] = false;
                    cnt++; 
                }else
                {
                    arrBool[cnt] = true; 
                }
            }
            */
            string Freq = "ETAOINSRHLDCUMFPGWYBVKXJQZ".ToLower();
            string alpha = "abcdefghijklmnopqrstuvwxyz";
            char[] al = alpha.ToCharArray();
            // Cipher = cipher.ToLower();



            char[] arrcipher = cipher.ToLower().ToCharArray();
            int[] arr2count = new int[26];
            char[] arr3 = Freq.ToCharArray();
            char[] arrmax = new char[26];
            int y = 0;
            char[] plaintext = new char[cipher.Length];
            for (char i = 'a'; i <= 'z'; i++)
            {
                int count = 0;

                for (int j = 0; j < cipher.Length; j++)
                {
                    if (i == arrcipher[j])
                    {
                        count++;//90 --- //80
                    }
                }
                arr2count[y] = count;
                y++;
            }
            int ind;

            
            
            for (int k = 0; k < arr2count.Length; k++)
            {
                int kk = arr2count.Max();
                ind = arr2count.ToList().IndexOf(kk);
                arrmax[k] = al[ind];
                arr2count.SetValue(-1, ind);
            }
            for (int j = 0; j < cipher.Length; j++)
            {
                if (arrcipher[j] == arrmax[0])
                {
                    plaintext[j] += 'e';
                }
                if (arrcipher[j] == arrmax[1])
                {
                    plaintext[j] += 't';
                }
                if (arrcipher[j] == arrmax[2])
                {
                    plaintext[j] += 'a';
                }
                if (arrcipher[j] == arrmax[3])
                {
                    plaintext[j] += 'o';
                }
                if (arrcipher[j] == arrmax[4])
                {
                    plaintext[j] += 'i';
                }
                if (arrcipher[j] == arrmax[5])
                {
                    plaintext[j] += 'n';
                }
                if (arrcipher[j] == arrmax[6])
                {
                    plaintext[j] += 's';
                }
                if (arrcipher[j] == arrmax[7])
                {
                    plaintext[j] += 'r';
                }
                if (arrcipher[j] == arrmax[8])
                {
                    plaintext[j] += 'h';
                }
                if (arrcipher[j] == arrmax[9])
                {
                    plaintext[j] += 'l';
                }
                if (arrcipher[j] == arrmax[10])
                {
                    plaintext[j] += 'd';
                }
                if (arrcipher[j] == arrmax[11])
                {
                    plaintext[j] += 'c';
                }
                if (arrcipher[j] == arrmax[12])
                {
                    plaintext[j] += 'u';
                }
                if (arrcipher[j] == arrmax[13])
                {
                    plaintext[j] += 'm';
                }
                if (arrcipher[j] == arrmax[14])
                {
                    plaintext[j] += 'f';
                }
                if (arrcipher[j] == arrmax[15])
                {
                    plaintext[j] += 'p';
                }
                if (arrcipher[j] == arrmax[16])
                {
                    plaintext[j] += 'g';
                }
                if (arrcipher[j] == arrmax[17])
                {
                    plaintext[j] += 'w';
                }
                if (arrcipher[j] == arrmax[18])
                {
                    plaintext[j] += 'y';
                }
                if (arrcipher[j] == arrmax[19])
                {
                    plaintext[j] += 'b';
                }
                if (arrcipher[j] == arrmax[20])
                {
                    plaintext[j] += 'v';
                }
                if (arrcipher[j] == arrmax[21])
                {
                    plaintext[j] += 'k';
                }
                if (arrcipher[j] == arrmax[22])
                {
                    plaintext[j] += 'x';
                }
                if (arrcipher[j] == arrmax[23])
                {
                    plaintext[j] += 'j';
                }
                if (arrcipher[j] == arrmax[24])
                {
                    plaintext[j] += 'q';
                }
                if (arrcipher[j] == arrmax[25])
                {
                    plaintext[j] += 'z';
                }
            }
            Console.WriteLine(plaintext);
            return new string(plaintext);

        }
    }
}
