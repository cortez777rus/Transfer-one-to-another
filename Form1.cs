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

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }*/

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private char IntToChar(int input)
        {
            switch (input)
            {
                case 0:
                    return '0';
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
                case '0':
                    return 0;
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

        private String tenToAnotherInt(int number, int s)
        {
            int number_ = number;
            int k = 0;
            while (number > 0)
            {
                number = number / s;
                k++;
            }
            char[] ch = new char[k];
            number = number_;
            int result = 0;
            while (number > 0)
            {
                result = number % s;
                number = number / s;
                ch[k - 1] = IntToChar(result);
                k--;
            }
            String result_ = new string(ch);
            return result_;
        }

        private String anotherToTenInt(char[] number, int s)
        {
            int k = number.Length, result = 0, d = 1;
            while (k != 0)
            {
                result += CharToInt(number[k - 1]) * d;
                d = d * s;
                k--;
            }
            return result.ToString();
        }

        private String tenToAnotherDivisional(double number, int s)
        {
            double number_ = number;
            int k = 0;
            while ((number * s) % 1 != 0)
            {
                number = number * s - (number * s) / 1;
                k++;
            }
            k++;
            char[] ch = new char[k];
            number = number_;
            int result = 0;
            int z = 0;
            while ((number * s) % 1 != 0 && z < k)
            {
                result = (int)(number * s);
                number = number * s - result;
                ch[z] = IntToChar(result);
                z++;
            }
            String result_ = new string(ch);
            return result_;
        }

        private String anotherToTenDivisional(char[] number, int s)
        {
            int k = 0;
            double result = 0, d = 1 % s;
            while (k != number.Length)
            {
                result += CharToInt(number[k]) * d;
                d = d / s;
                k++;
            }
            return result.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = " ";
            if (IsNullOrWhiteSpace(textBox1.Text) || IsNullOrEmpty(comboBox1.Text) || IsNullOrEmpty(comboBox2.Text))
                textBox2.Text = "Ошибка";
            else
            {
                if (comboBox1.Text == comboBox2.Text)
                    textBox2.Text = textBox1.Text;
                else if (comboBox1.Text == "10") //10->another
                {
                    int i = Int32.Parse(comboBox2.Text);
                    int data_int = (int)Convert.ToDouble(textBox1.Text) / 1;
                    if (Convert.ToDouble(textBox1.Text) - data_int > 0)
                    {
                        double data_divisional = Convert.ToDouble(textBox1.Text) - data_int;
                        textBox2.Text = tenToAnotherInt(data_int, i) + ',' + tenToAnotherDivisional(data_divisional, i);//The result is an amount of integer part and divisional one
                    }
                    else if (Convert.ToDouble(textBox1.Text) - data_int == 0)
                    {
                        textBox2.Text = tenToAnotherInt(data_int, i);
                    }
                    else
                        textBox2.Text = "Ошибка";
                }
                else if (comboBox2.Text == "10")//another->10
                {
                    char[] ch = textBox1.Text.ToCharArray();
                    bool z = false;
                    for (int m = 0; m <= ch.Length - 1; m++)
                        if (ch[m] == ',')
                            z = true;
                    if (z == false)
                    {
                        char[] data_int = new char[ch.Length];
                        data_int = ch;
                        int i = Int32.Parse(comboBox1.Text);
                        textBox2.Text = anotherToTenInt(data_int, i);
                    }
                    else if (z == true)
                    {
                        int n = 0;
                        while (ch[n] != ',')
                            n++;
                        char[] data_int = new char[n];
                        n = 0;
                        while (ch[n] != ',')
                        {
                            data_int[n] = ch[n];
                            n++;
                        }
                        n++;
                        char[] data_divisional = new char[ch.Length - n];
                        int k = 0;
                        while (n != ch.Length)
                        {
                            data_divisional[k] = ch[n];
                            n++;
                            k++;
                        }
                        int i = Int32.Parse(comboBox1.Text);
                        textBox2.Text = anotherToTenInt(data_int, i) + ',' + anotherToTenDivisional(data_divisional, i);
                    }
                }
                else
                {
                    int i = Int32.Parse(comboBox1.Text);
                    char[] ch = textBox1.Text.ToCharArray();
                    bool z = false;
                    for (int m = 0; m <= ch.Length - 1; m++)
                        if (ch[m] == ',')
                            z = true;
                    if (z == false)
                    {
                        char[] data_int = new char[ch.Length];
                        data_int = ch;
                        int dat_int = Int32.Parse(anotherToTenInt(data_int, i));
                        i = Int32.Parse(comboBox2.Text);
                        textBox2.Text = tenToAnotherInt(dat_int, i);
                    }
                    else if (z == true)
                    {
                        int n = 0;
                        while (ch[n] != ',')
                            n++;
                        char[] data_int = new char[n];
                        n = 0;
                        while (ch[n] != ',')
                        {
                            data_int[n] = ch[n];
                            n++;
                        }
                        n++;
                        char[] data_divisional = new char[ch.Length - n];
                        int k = 0;
                        while (n != ch.Length)
                        {
                            data_divisional[k] = ch[n];
                            n++;
                            k++;
                        }
                        String s = anotherToTenInt(data_int, i) + ',' + anotherToTenDivisional(data_divisional, i);
                        int dat_int = (int)Convert.ToDouble(s) / 1;
                        double dat_divisional = Convert.ToDouble(s) - dat_int;
                        i = Int32.Parse(comboBox2.Text);
                        textBox2.Text = tenToAnotherInt(dat_int, i) + ',' + tenToAnotherDivisional(dat_divisional, i);
                    }
                }
            }
        }
    }
}
