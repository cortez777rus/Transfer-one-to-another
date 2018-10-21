using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.String;

namespace NumbersApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /*private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.SuspendLayout();
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }*/

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            if (IsNullOrWhiteSpace(textBox4.Text) || IsNullOrEmpty(comboBox1.Text) || IsNullOrEmpty(comboBox2.Text))
                textBox1.Text = "Ошибка";
            else
            {
                if (comboBox1.Text == comboBox2.Text)
                    textBox1.Text = textBox4.Text;
                /*else if (comboBox1.Text == "10" && Int32.Parse(comboBox2.Text) < 11) //10->2-9 system
                {
                    int number = Int32.Parse(textBox4.Text);
                    int i = Int32.Parse(comboBox2.Text);
                    int d = 1, result = 0;
                    while (number > 0)
                    {
                        result += (number % i) * d;
                        number = number / i;
                        d = d * 10;
                    }
                    textBox1.Text = result.ToString();
                }*/
                else if (comboBox1.Text == "10") //10->another
                {
                    int number = Int32.Parse(textBox4.Text);
                    int i = Int32.Parse(comboBox2.Text);
                    int k = 0;
                    while (number > 0)
                    {
                        number = number / i;
                        k++;
                    }
                    char[] ch = new char[k];
                    number = Int32.Parse(textBox4.Text);
                    int result = 0;
                    while (number > 0)
                    {
                        result = number % i;
                        number = number / i;
                        ch[k - 1] = IntToChar(result);
                        k--;
                    }
                    textBox1.Text = new string(ch);
                }
                /*else if (comboBox2.Text == "10" && Int32.Parse(comboBox1.Text) < 11)
                {
                    int number = Int32.Parse(textBox4.Text);
                    int i = Int32.Parse(comboBox1.Text);
                    int result = anotherToTen(number, i);
                    textBox1.Text = result.ToString();
                }*/
                else if (comboBox2.Text == "10")//another->10
                {
                    char[] ch = textBox4.Text.ToCharArray();
                    int i = Int32.Parse(comboBox1.Text);
                    int k = ch.Length, result = 0, d = 1;
                    while (k != 0)
                    {
                        result += CharToInt(ch[k - 1]) * d;
                        d = d * i;
                        k--;
                    }
                    textBox1.Text = result.ToString();
                }
                else
                {
                    char[] ch = textBox4.Text.ToCharArray();
                    int i = Int32.Parse(comboBox1.Text);
                    int k = ch.Length, number = 0, d = 1;
                    while (k != 0)
                    {
                        number += CharToInt(ch[k - 1]) * d;
                        d = d * i;
                        k--;
                    }
                    i = Int32.Parse(comboBox2.Text);
                    k = 0;
                    int number_ = number;
                    while (number > 0)
                    {
                        number = number / i;
                        k++;
                    }
                    char[] sh = new char[k];
                    number = number_;
                    int result = 0;
                    while (number > 0)
                    {
                        result = number % i;
                        number = number / i;
                        sh[k - 1] = IntToChar(result);
                        k--;
                    }
                    textBox1.Text = new string(sh);
                }
            }
        }

        private char IntToChar(int input)
        {
            switch(input)
            {
                case 1:
                    return '1';
                case 2:
                    return '2';
                case 3:
                    return '3';
                case 4:
                    return '4';
                case 5:
                    return '5';
                case 6:
                    return '6';
                case 7:
                    return '7';
                case 8:
                    return '8';
                case 9:
                    return '9';
                case 10:
                    return 'A';
                case 11:
                    return 'B';
                case 12:
                    return 'C';
                case 13:
                    return 'D';
                case 14:
                    return 'E';
                case 15:
                    return 'F';
                default:
                    return '0';
            }
        }

        private int CharToInt(char input)
        {
            switch (input)
            {
                case '1':
                    return 1;
                case '2':
                    return 2;
                case '3':
                    return 3;
                case '4':
                    return 4;
                case '5':
                    return 5;
                case '6':
                    return 6;
                case '7':
                    return 7;
                case '8':
                    return 8;
                case '9':
                    return 9;
                case 'A':
                    return 10;
                case 'B':
                    return 11;
                case 'C':
                    return 12;
                case 'D':
                    return 13;
                case 'E':
                    return 14;
                case 'F':
                    return 15;
                default:
                    return 0;
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }
    }
}
