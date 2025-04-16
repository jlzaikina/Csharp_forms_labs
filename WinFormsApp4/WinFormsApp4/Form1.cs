using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == String.Empty)
            {
                label1.Text = "Строка пустая";
            }
            else
            {
                listBox3.Items.Clear();
                listBox4.Items.Clear();
                Class1 cl = new Class1(textBox2.Text);
                if (cl.ErrorPos == -1)
                {
                    label1.ForeColor = Color.Green;
                    label1.Text = "Нет ошибок";
                }
                else
                {
                    label1.ForeColor = Color.Red;
                    label1.Text = cl.ErrorMes + $" (позиция {cl.ErrorPos + 1})";
                    textBox2.Select(cl.ErrorPos, 0);
                    textBox2.Focus();
                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            listBox4.Items.Clear();
            Class1 cl = new Class1(textBox2.Text);
            if (cl.ErrorPos == -1)
            { 
                foreach (string i in cl.Id)
                {
                    listBox3.Items.Add(i);
                }
                foreach (string c in cl.Consts)
                {
                    listBox4.Items.Add(c);
                }
            }
        }
    }
}