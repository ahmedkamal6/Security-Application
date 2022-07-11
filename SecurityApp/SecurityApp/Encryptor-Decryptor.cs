using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SecurityApp
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string plain = String.Concat(phrase.Text.Where(c => !Char.IsWhiteSpace(c)));
            plain = plain.ToLower();
            string algorithm = algo.Text;
            string result;
            int numKey;
            string myKey;
            switch (algorithm)
            {
                case "Ceasar":
                    if (!int.TryParse(key.Text, out numKey))
                        MessageBox.Show("key must be a number");
                    else
                    {
                        Ceasar alg = new Ceasar();
                        result = alg.Encrypt(plain,numKey);
                        res.Text = result;
                    }
                    break;
                case "Monoalphabetic":
                    if (key.Text.ToString().Length != 26 || !(uniqueCharacters(key.Text.ToString())))
                        MessageBox.Show("key must be represent the 26 alphabets");
                    else
                    {
                        Monoalphabetic alg = new Monoalphabetic();
                        result = alg.Encrypt(plain, key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "Playfair":
                    if(containsNumbers(key.Text.ToString()))
                        MessageBox.Show("Key must consist of alphabetical letters");
                    else if(containsNumbers(plain.ToString()))
                        MessageBox.Show("Text must consist of alphabetical letters");
                    else
                    {
                        PlayFair alg = new PlayFair();
                        result = alg.Encrypt(plain,key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "AutokeyVignere":
                    if (containsNumbers(key.Text.ToString()))
                        MessageBox.Show("Key must consist of alphabetical letters");
                    else if (containsNumbers(plain.ToString()))
                        MessageBox.Show("Text must consist of alphabetical letters");
                    else
                    {
                        AutokeyVigenere alg = new AutokeyVigenere();
                        result = alg.Encrypt(plain, key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "Railfence":
                    if (!int.TryParse(key.Text, out numKey))
                        MessageBox.Show("key must be a number");
                    else
                    {
                        Railfence alg = new Railfence();
                        result = alg.Encrypt(plain ,numKey);
                        res.Text = result;
                    }
                    break;
                case "Columnar":           
                        Columnar col = new Columnar();
                        List<int> newKey = col.stringKeytoList(key.Text.ToString());
                        result = col.Encrypt(plain, newKey);
                        res.Text = result;
                        break;                       
            }
        }
        static bool uniqueCharacters(string str)
        {
            HashSet<char> set = new HashSet<char>();
            foreach(char c in str)
            {
                if (set.Contains(c))
                    return false;
                else
                    set.Add(c);
            }
            return true;
        }
        static bool containsNumbers(string str)
        {
            foreach(char c in str)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                    return true;
            }
            return false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string plain = String.Concat(phrase.Text.Where(c => !Char.IsWhiteSpace(c))); ;
            string algorithm = algo.Text;
            string result;
            int numKey;
            string myKey;
            switch (algorithm)
            {
                case "Ceasar":
                    if (!int.TryParse(key.Text, out numKey))
                        MessageBox.Show("key must be a number");
                    else
                    {
                        Ceasar alg = new Ceasar();
                        result = alg.Decrypt(plain, numKey);
                        res.Text = result;
                    }
                    break;
                case "Monoalphabetic":
                    if (key.Text.ToString().Length != 26 || !(uniqueCharacters(key.Text.ToString())))
                        MessageBox.Show("key must be represent the 26 alphabets");
                    else
                    {
                        Monoalphabetic alg = new Monoalphabetic();
                        result = alg.Decrypt(plain, key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "Playfair":
                    if (containsNumbers(key.Text.ToString()))
                        MessageBox.Show("Key must consist of alphabetical letters");
                    else if (containsNumbers(plain.ToString()))
                        MessageBox.Show("Text must consist of alphabetical letters");
                    else
                    {
                        PlayFair alg = new PlayFair();
                        result = alg.Decrypt(plain, key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "AutokeyVignere":
                    if (containsNumbers(key.Text.ToString()))
                        MessageBox.Show("Key must consist of alphabetical letters");
                    else if (containsNumbers(plain.ToString()))
                        MessageBox.Show("Text must consist of alphabetical letters");
                    else
                    {
                        AutokeyVigenere alg = new AutokeyVigenere();
                        result = alg.Decrypt(plain, key.Text.ToString());
                        res.Text = result;
                    }
                    break;
                case "Railfence":
                    if (!int.TryParse(key.Text, out numKey))
                        MessageBox.Show("key must be a number");
                    else
                    {
                        Railfence alg = new Railfence();
                        result = alg.Decrypt(plain, numKey);
                        res.Text = result;
                    }
                    break;
                case "Columnar":
                    Columnar col = new Columnar();
                    List<int> newKey = col.stringKeytoList(key.Text.ToString());
                    result = col.Decrypt(plain, newKey);
                    res.Text = result;
                    break;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
