using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    class Railfence
    {
        public int Analyse(string plainText, string cipherText)
        {
            if (plainText.Length != cipherText.Length)
                return 0;
            plainText = plainText.ToLower();
            cipherText = cipherText.ToUpper();
            int num = 1;
            while (true)
            {
                string s = Encrypt(plainText, num);
                if (s == cipherText)
                    break;
                else
                    num++;
            }
            return num;
        }

        public string Decrypt(string cipherText, int key)
        {
            cipherText = cipherText.ToLower();

            int c = (int)Math.Ceiling(cipherText.Length / (decimal)key);
            int r = key;
            string res = "";
            int count = 0;
            char[,] mat = new char[r, c];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                {
                    mat[i, j] = cipherText[count];
                    count++;
                    if (count >= cipherText.Length)
                        break;
                }
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    res += mat[j, i];
                }
            }
            return res.ToLower();
        }

        public string Encrypt(string plainText, int key)
        {
            int r = (int)Math.Ceiling(plainText.Length / (decimal)key);
            int c = key;
            string res = "";
            int count = 0;
            char[,] mat = new char[c, r];
            for (int i = 0; i < r; i++)
                for (int j = 0; j < c; j++)
                {
                    if (count >= plainText.Length)
                        mat[j, i] = '0';
                    else
                    {
                        mat[j, i] = plainText[count];
                        count++;
                    }

                }
            for (int i = 0; i < c; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    if (mat[i, j] != '0')
                        res += mat[i, j];
                }
            }
            return res.ToUpper();
        }
    }
}
