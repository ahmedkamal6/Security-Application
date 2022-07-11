using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    class Monoalphabetic
    {
        public string Analyse(string plainText, string cipherText)
        {
            string key = "";
            plainText = plainText.ToLower();
            cipherText = cipherText.ToLower();

            char[] plain = plainText.ToCharArray();
            char[] cipher = cipherText.ToCharArray();

            Dictionary<char, char> keys = new Dictionary<char, char>();
            int count = 0;
            while (count < plain.Length)
            {
                keys[plain[count]] = cipher[count];
                count++;
            }
            char count2 = 'a';
            char place_holder = '0';
            while (count2 <= 'z')
            {
                if (keys.ContainsKey(count2))
                {
                    key += keys[count2];
                }
                else
                {
                    key += place_holder;
                    place_holder++;
                }
                count2++;
            }
            return key;
        }

        public string Decrypt(string cipherText, string key)
        {
            cipherText = cipherText.ToLower();
            key = key.ToLower();
            Dictionary<char, char> dec = new Dictionary<char, char>();
            char[] key_chars = key.ToCharArray();
            char count = 'a';
            int i = 0;
            while (count <= 'z')
            {
                dec[key_chars[i]] = count;
                i++;
                count++;
            }
            string plain = "";
            foreach (char ch in cipherText)
            {
                plain += dec[ch];
            }
            return plain;
        }

        public string Encrypt(string plainText, string key)
        {
            plainText = plainText.ToLower();
            key = key.ToLower();
            Dictionary<char, char> dec = new Dictionary<char, char>();
            char[] key_chars = key.ToCharArray();
            char count = 'a';
            int i = 0;
            while (count <= 'z')
            {
                dec[count] = key_chars[i];
                i++;
                count++;
            }
            string cipher = "";
            foreach (char ch in plainText)
            {
                cipher += dec[ch];
            }
            return cipher.ToUpper();
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
        //{'E', 'T', 'A', 'O', 'I',
        //'N', 'S', 'R', 'L', 'H', 'D', 'C', 'M', 'P', 'U', 'F',
        //'G', 'W', 'Y', 'B', 'V', 'K', 'J', 'X', 'Q', 'Z' };


        public string AnalyseUsingCharFrequency(string cipher)
        {
            string key = "";
            char[] alpha = {'E', 'T', 'A', 'O', 'I',
                'N', 'S', 'R', 'L', 'H', 'D', 'C', 'M', 'P', 'U', 'F',
                'G', 'W', 'Y', 'B', 'V', 'K', 'J', 'X', 'Q', 'Z' };
            Dictionary<char, int> freqs = new Dictionary<char, int>();
            foreach (char c in cipher)
            {
                if (freqs.ContainsKey(c))
                    freqs[c] += 1;
                else
                    freqs[c] = 1;
            }
            var myList = freqs.ToList();
            myList.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            Dictionary<char, char> res = new Dictionary<char, char>();
            int count = 25;
            foreach (var kvp in myList)
            {
                res[alpha[count]] = kvp.Key;
                Console.WriteLine(alpha[count] + " " + kvp.Key);
                count--;

            }
            char count2 = 'A';
            foreach (var kvp in res)
            {
                key += res[count2];
                count2++;
            }
            string plain = Decrypt(cipher, key);
            return plain;
        }
    }
}
