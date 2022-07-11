using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityApp
{
    class Columnar
    {
        public List<int> stringKeytoList(string key)
        {
            List<int> newKey = new List<int>();
            HashSet<int> set = new HashSet<int>();
            string[] keyChars = key.Split(',',' ');
            foreach(string k in keyChars)
            {
                try 
                {
                    if(!set.Contains(int.Parse(k)))
                        set.Add(int.Parse(k));
                    else
                    {
                        MessageBox.Show("columnar key can't have duplicate numbers. default 1,2,3");
                        return new List<int>() { 1, 2, 3 };
                    }
                    newKey.Add(int.Parse(k));
                     
                }
                catch(Exception)
                {
                    MessageBox.Show("columnar key must be comma seperated numbers includes all numbers in interval [1,MaxNumberofColumns]" +
                            "example \"4,3,1\" is wrong but \"4,3,1,2\" is right ");
                }
            }
            int max = newKey.Max();
            for (int i = 1; i < max; i++)
            {
                if (!newKey.Contains(i))
                {
                    MessageBox.Show("columnar key must be comma seperated numbers includes all numbers in interval [1,MaxNumberofColumns]" +
                           "example \"4,3,1\" is wrong but \"4,3,1,2\" is right. default:1,2,3 ");
                    return new List<int>() { 1, 2, 3 };

                }
            }
            return newKey;
        }
        public List<int> Analyse(string plainText, string cipherText)
        {
            //throw new NotImplementedException();
            int n = cipherText.Length;
            cipherText = cipherText.ToLower();
            List<int> rows = new List<int>();
            List<int> cols = new List<int>();
            SortedDictionary<int, int> pairs = new SortedDictionary<int, int>();
            for (int i = 2; i < n; i++)
            {
                if (n % i == 0)
                {
                    rows.Add(i);
                    cols.Add(n / i);
                }
            }
            for (int i = 0; i < rows.Count; i++)
            {
                int r = rows[i];
                int c = cols[i];
                char[,] matrix = new char[r, c];
                int count = 0;
                for (int j = 0; j < r; j++)
                {
                    for (int k = 0; k < c; k++)
                    {
                        if (count < plainText.Length)
                        {
                            matrix[j, k] = plainText[count];
                            count++;
                        }
                        else
                            matrix[j, k] = 'x';
                    }
                }
                bool rightmat = true;
                for (int j = 0; j < c; j++)
                {
                    string s = "";
                    for (int k = 0; k < r; k++)
                    {
                        s += matrix[k, j];
                    }
                    if (!cipherText.Contains(s))
                    {
                        rightmat = false;
                        break;
                    }
                }
                if (!rightmat)
                    continue;
                else
                {
                    for (int o = 0; o < cipherText.Length; o += r)
                    {
                        string s = "";
                        for (int j = o; j < o + r; j++)
                            s += cipherText[j];

                        string s2 = "";
                        int pos = 0;
                        for (int j = 0; j < c; j++)
                        {
                            s2 = "";
                            for (int k = 0; k < r; k++)
                            {
                                s2 += matrix[k, j];
                            }
                            pos = j;
                            if (s.Equals(s2))
                                break;
                        }
                        pairs[pos + 1] = (o / r) + 1;
                    }
                }
            }
            List<int> res = new List<int>();
            foreach (var key in pairs.Keys)
            {
                res.Add(pairs[key]);
                Console.WriteLine(pairs[key]);
            }
            if (res.Count == 0)
                return new List<int> { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
            return res;
        }

        public string Decrypt(string cipherText, List<int> key)
        {
            //throw new NotImplementedException();
            string plain = "";
            int row = (int)Math.Ceiling((decimal)cipherText.Length / key.Count);
            int col = key.Count;
            char[,] matrix = new char[row, col];
            int count = 0;
            for (int i = 1; i <= key.Count; i++)
            {
                int pos = key.IndexOf(i);
                for (int j = 0; j < row; j++)
                {
                    if (count < cipherText.Length)
                    {
                        matrix[j, pos] = cipherText[count];
                        count++;
                    }
                    else
                    {
                        matrix[j, pos] = 'X';
                    }
                }
            }
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {

                    plain += matrix[i, j];
                }
            }

            return plain.ToLower();
        }

        public string Encrypt(string plainText, List<int> key)
        {
            //throw new NotImplementedException();
            string cipher = "";
            int count = 0;
            char[,] matrix = new char[(int)Math.Ceiling((decimal)plainText.Length / key.Count), key.Count];
            for (int i = 0; i < Math.Ceiling((decimal)plainText.Length / key.Count); i++)
            {
                for (int j = 0; j < key.Count; j++)
                {
                    if (count < plainText.Length)
                    {
                        matrix[i, j] = plainText[count];
                        count++;
                    }
                    else
                        matrix[i, j] = 'x';
                    Console.Write(matrix[i, j]);
                }
                Console.WriteLine();
            }
            for (int j = 1; j <= key.Count; j++)
            {
                int pos = key.IndexOf(j);
                for (int i = 0; i < Math.Ceiling((decimal)plainText.Length / key.Count); i++)
                {
                    cipher += matrix[i, pos];
                }
            }

            return cipher.ToUpper();
        }
    }
}
