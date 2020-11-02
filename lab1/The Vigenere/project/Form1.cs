using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace protect_inf_LR1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            N = characters.Length;
        }

        char[] characters = new char[] { 'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё', 'Ж', 'З', 'И',
                                                        'Й', 'К', 'Л', 'М', 'Н', 'О', 'П', 'Р', 'С',
                                                        'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ь', 'Ы', 'Ъ',
                                                        'Э', 'Ю', 'Я', ' '};

        private int N; //длина алфавита

        //зашифровать
        private void buttonEncrypt_Click(object sender, EventArgs e)
        {
            if (textBoxKeyWord.Text.Length > 0 || textBox1.Text.Length > 0)
            {

                string s;
                s = textBox1.Text;
                textBox2.Text = Encode(s, textBoxKeyWord.Text);


            }
            else
                MessageBox.Show("Введите ключевое слово и текст ввода!");
        }

        //расшифровать
        private void buttonDecipher_Click(object sender, EventArgs e)
        {
            if (textBoxKeyWord.Text.Length > 0 || textBox1.Text.Length > 0)
            {

                string s;
                s = textBox1.Text;
                textBox2.Text = Decode(s, textBoxKeyWord.Text);


            }
            else
                MessageBox.Show("Введите ключевое слово и текст ввода!");
        }

        //зашифровать
        private string Encode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int c = (Array.IndexOf(characters, symbol) +
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[c];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        //расшифровать
        private string Decode(string input, string keyword)
        {
            input = input.ToUpper();
            keyword = keyword.ToUpper();

            string result = "";

            int keyword_index = 0;

            foreach (char symbol in input)
            {
                int p = (Array.IndexOf(characters, symbol) + N -
                    Array.IndexOf(characters, keyword[keyword_index])) % N;

                result += characters[p];

                keyword_index++;

                if ((keyword_index + 1) == keyword.Length)
                    keyword_index = 0;
            }

            return result;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}