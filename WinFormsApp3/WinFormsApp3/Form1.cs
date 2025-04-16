namespace WinFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        static public int choice;
        private void OpenForm(Form form)
        {
            form.Show();
            Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form = new Form2();
            if (radioButton1.Checked) choice = 1;
            else if (radioButton2.Checked) choice = 2;
            else if (radioButton3.Checked) choice = 3;
            form.Choice = choice;
            OpenForm(form);
        }
    }
}