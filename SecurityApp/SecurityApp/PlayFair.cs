using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SecurityApp
{
    class PlayFair
    {
        // matrix 2D array 
        char[,] matrix = new char[5, 5];
        // Matrix function 
        public void createMatrix(string key)
        {
            string checkToken = "";
            int keyIndex = 0;
            int keyLen = key.Length;
            char letter = 'a';
            int j = 0;

            for (int i = 0; i < 5; i++)
            {
                while (j < 5)
                {
                    //if all key chars not added 
                    if (keyIndex < keyLen)
                    {
                        //if the chat not taked add to matrix
                        if (!checkToken.Contains(key[keyIndex]))
                        {
                            //add char to matrix
                            matrix[i, j] = key[keyIndex];
                            // add char to token string 
                            checkToken = String.Concat(checkToken, key[keyIndex]);
                            //increment the key string index 
                            keyIndex++;
                        }
                        else
                        {
                            keyIndex++;
                            continue;
                        }

                    }
                    //if key letters add fill the matrix 
                    else
                    {

                        if (!key.Contains(letter) && letter != 'j')
                        {
                            matrix[i, j] = letter;
                            letter++;
                        }
                        else
                        {
                            letter++;
                            continue;
                        }

                    }
                    j++;
                }
                j = 0;
            }
        }
        public string Decrypt(string cipherText, string key)
        {
            //throw new NotImplementedException();
            key = key.ToLower();
            createMatrix(key);
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
            char c1, c2;
            int x = 0;
            string en = "";
            cipherText = cipherText.ToLower();
            //cipherText.Replace('j', 'i');
            if (x < cipherText.Length)
            {
                while (x < cipherText.Length)
                {

                    c1 = cipherText[x];
                    x++;
                    if ((x) == cipherText.Length)
                    {
                        c2 = 'x';
                    }
                    else
                    {
                        c2 = cipherText[x];
                        x++;
                        // c1 == c2 
                        if (c1 == c2)
                        {
                            c2 = 'x';
                            x--;
                        }
                    }


                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (matrix[i, j] == c1)
                            {
                                i1 = i;
                                j1 = j;
                            }
                            if (matrix[i, j] == c2)
                            {
                                i2 = i;
                                j2 = j;
                            }
                        }
                    }

                    //same row 
                    if (i1 == i2)
                    {
                        j1 = (j1 + 4) % 5;
                        j2 = (j2 + 4) % 5;

                        en = string.Concat(en, matrix[i1, j1]);
                        en = string.Concat(en, matrix[i1, j2]);
                    }
                    //same column
                    else if (j1 == j2)
                    {
                        i1 = (i1 + 4) % 5;
                        i2 = (i2 + 4) % 5;
                        en = string.Concat(en, matrix[i1, j1]);
                        en = string.Concat(en, matrix[i2, j2]);

                    }
                    //diffrent
                    else
                    {
                        en = string.Concat(en, matrix[i1, j2]);
                        en = string.Concat(en, matrix[i2, j1]);
                    }



                }
            }
            string de = "";
            if (en[en.Length - 1] == 'x')
            {
                en = en.Remove(en.Length - 1, 1);
            }
            for (int i = 0; i < en.Length; i++)
            {
                if (i < (en.Length) - 2)
                {
                    ////@
                    if (en[i] == en[i + 2] && en[i + 1] == 'x' && ((i + 1) % 2 != 0))
                    {
                        de = string.Concat(de, en[i]);
                        de = string.Concat(de, en[i + 2]);
                        i += 2;
                    }
                    else
                    {
                        de = string.Concat(de, en[i]);
                    }
                }

                else
                {
                    de = string.Concat(de, en[i]);
                }
            }
            return de.ToLower();
        }

        public string Encrypt(string plainText, string key)
        {
            //throw new NotImplementedException();
            plainText = plainText.ToLower();
            key = key.ToLower();
            createMatrix(key);
            int i1 = 0, j1 = 0, i2 = 0, j2 = 0;
            char c1, c2;
            int x = 0;
            string en = "";
            plainText = plainText.ToLower(); 
            plainText.Replace('j', 'i');
            while (x < plainText.Length)
            {

                c1 = plainText[x];
                x++;
                if ((x) == plainText.Length)
                {
                    c2 = 'x';
                }
                else
                {
                    c2 = plainText[x];
                    x++;
                    // c1 == c2 
                    if (c1 == c2)
                    {
                        c2 = 'x';
                        x--;
                    }
                }


                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (matrix[i, j] == c1)
                        {
                            i1 = i;
                            j1 = j;
                        }
                        if (matrix[i, j] == c2)
                        {
                            i2 = i;
                            j2 = j;
                        }
                    }
                }

                //same row 
                if (i1 == i2)
                {
                    j1 = (j1 + 1) % 5;
                    j2 = (j2 + 1) % 5;

                    en = string.Concat(en, matrix[i1, j1]);
                    en = string.Concat(en, matrix[i1, j2]);


                }
                //same column
                else if (j1 == j2)
                {
                    i1 = (i1 + 1) % 5;
                    i2 = (i2 + 1) % 5;
                    en = string.Concat(en, matrix[i1, j1]);
                    en = string.Concat(en, matrix[i2, j2]);

                }
                //diffrent
                else
                {
                    en = string.Concat(en, matrix[i1, j2]);
                    en = string.Concat(en, matrix[i2, j1]);
                }



            }
            return en.ToUpper();
        }
    }
}
