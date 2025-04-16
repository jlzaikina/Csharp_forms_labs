using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {
        IVectorable[] vectors;
        int n;
        private Form form1;
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(Form form)
        {
            InitializeComponent();
            form1 = form;
        }
        private void Form2_Load(object sender, EventArgs e)
        {

        }
        private void OpenForm(Form form)
        {
            form.Show();
            Hide();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                n = int.Parse(textBox1.Text);
                if (n <= 0)
                {
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }
        }
        public void Write()
        {
            textBox3.AppendText("Массив векторов:\r\n");
            for (int i = 0; i < n; i++)
            {
                textBox3.AppendText($"{i + 1}) {vectors[i]}\r\n");
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string[] str = textBox3.Text.Split('\n');
                if (str.Length != n)
                {
                    throw new ApplicationException($"Введите число векторов, равное {n}!");
                }
                vectors = new IVectorable[str.Length];
                for (int i = 0; i < str.Length; i++)
                {
                    string[] str1 = str[i].Split(new char[] { ' ' });
                    int k;
                    k = str1.Length;
                    if (i % 2 == 0)
                    {
                        vectors[i] = new ArrayVector(k);
                    }
                    else
                    {
                        vectors[i] = new LinkListVector(k);
                    }
                    for (int j = 0; j < vectors[i].Length; j++)
                    {
                        vectors[i][j] = Convert.ToDouble(str1[j].ToString());
                    }
                }
                textBox3.Clear();
                textBox3.AppendText("Массив векторов:\r\n");
                for (int i = 0; i < vectors.Length; i++)
                {
                    textBox3.AppendText($"{i + 1}) {vectors[i]}\r\n");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        IVectorable vec;
        int n1;
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                textBox4.Clear();
                n1 = int.Parse(textBox2.Text);
                if (n1 <= 0 || n1 > n)
                    throw new Exception("Неверный формат");
                vec = (IVectorable)vectors[n1 - 1].Clone();
                textBox4.AppendText("Клонированный вектор\r\n");
                textBox4.AppendText($"{vec}\r\n");
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
        int n2;
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                n2 = int.Parse(textBox5.Text);
                if (n2 <= 0 || n2 > vectors[n1 - 1].Length)
                {
                    throw new Exception("Неверный формат");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверные данные");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int t = int.Parse(textBox6.Text);
            vec[n2 - 1] = t;
            textBox4.AppendText("Клонированный вектор\r\n");
            textBox4.AppendText($"{vec}\r\n");
            textBox4.AppendText("Исходный вектор\r\n");
            textBox4.AppendText($"{vectors[n1 - 1]}\r\n");
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            Array.Sort(vectors, new Comparer());
            textBox4.Clear();
            textBox4.AppendText("Отсортированный массив векторов:\r\n");
            for (int i = 0; i < vectors.Length; i++)
            {
                textBox4.AppendText($"{i + 1}) {vectors[i]}\r\n");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
                IVectorable max = vectors[0];
                IVectorable min = vectors[0];
                int res1;
                for (int i = 0; i < n; i++)
                {
                    res1 = min.CompareTo(vectors[i]);
                    if (res1 < 0)
                    {
                        min = vectors[i];
                    }
                }
                for (int i = 0; i < n; i++)
                {
                    res1 = max.CompareTo(vectors[i]);
                    if (res1 > 0)
                    {
                        max = vectors[i];
                    }
                }
                textBox4.Clear();
                textBox4.AppendText("Вектор с минимальным количеством координат:\r\n");
                for (int i = 0; i < n; i++)
                {
                    if (vectors[i].Length == min.Length)
                    {
                        textBox4.AppendText($"{vectors[i]}\r\n");
                    }
                }
                textBox4.AppendText("Вектор с максимальным количеством координат:\r\n");
                for (int i = 0; i < n; i++)
                {
                    if (vectors[i].Length == max.Length)
                    {
                        textBox4.AppendText($"{vectors[i]}\r\n");
                    }
                }
            }
        private void button8_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (vectors[0].Equals(vectors[1]))
                textBox4.AppendText("Вектора равны\n");
            else
                textBox4.AppendText("Вектора не равны\n");
            int res;
            res = vectors[0].CompareTo(vectors[1]);
            if (res < 0)
                textBox4.AppendText("У второго координат меньше\n");
            else if (res == 0)
                textBox4.AppendText("Равное кол-во координат\n");
            else
                textBox4.AppendText("У первого координат меньше\n");
            Comparer c = new Comparer();
            if (c.Compare(vectors[0], vectors[1]) < 0)
                textBox4.AppendText("У первого модуль меньше\n");
            else if (res == 0)
                textBox4.AppendText("Модули равны\n");
            else
                textBox4.AppendText("У первого модуль больше\n");
        }
    }
}
