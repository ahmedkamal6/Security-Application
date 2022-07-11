using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    class Ceasar
    {
        public string Encrypt(string plainText, int key)
        {
            String alphabets = "abcdefghijklmnopqrstuvwxyz";
            String cipherText = "";
            int index;
            int result;
            for (int i = 0; i < plainText.Length; i++)
            {
                index = alphabets.IndexOf(plainText[i].ToString().ToLower());
                result = (key + index) % 26;
                cipherText += alphabets[result];
            }
            return cipherText;
        }

        public string Decrypt(string cipherText, int key)
        {
            String alphabets = "abcdefghijklmnopqrstuvwxyz";
            String plainText = "";
            int index;
            int result;
            for (int i = 0; i < cipherText.Length; i++)
            {
                index = alphabets.IndexOf(cipherText[i].ToString().ToLower());
                if (key > index)
                {
                    index += 26;
                    result = (index - key) % 26;
                }
                else
                {
                    result = (index - key) % 26;
                }
                plainText += alphabets[result];
            }
            return plainText;
        }

        public int Analyse(string plainText, string cipherText)
        {
            String alphabets = "abcdefghijklmnopqrstuvwxyz";
            int indexOne = alphabets.IndexOf(plainText[0].ToString().ToLower());
            int indexTwo = alphabets.IndexOf(cipherText[0].ToString().ToLower());
            int key = 0;
            while (true)
            {
                if (indexTwo == ((indexOne + key) % 26))
                {
                    return key;
                }
                else
                {
                    key += 1;
                }
            }
        }
    }
}
