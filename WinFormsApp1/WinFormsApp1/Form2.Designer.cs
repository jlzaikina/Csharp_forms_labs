namespace WinFormsApp1
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.button9 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(150, 39);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(74, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "Ввести";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(170, 6);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(41, 27);
            this.textBox1.TabIndex = 1;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(265, 263);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(41, 27);
            this.textBox2.TabIndex = 2;
            this.textBox2.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(185, 211);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(74, 31);
            this.button2.TabIndex = 3;
            this.button2.Text = "Ввести";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(80, 78);
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(286, 127);
            this.textBox3.TabIndex = 4;
            this.textBox3.TextChanged += new System.EventHandler(this.textBox3_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(161, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Количество векторов:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 129);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 20);
            this.label2.TabIndex = 6;
            this.label2.Text = "Вектора:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 266);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(253, 20);
            this.label3.TabIndex = 7;
            this.label3.Text = "Номер вектора для клонирования:";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(254, 296);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(65, 26);
            this.button3.TabIndex = 8;
            this.button3.Text = "Ввести";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(489, 12);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(410, 223);
            this.textBox4.TabIndex = 9;
            this.textBox4.TextChanged += new System.EventHandler(this.textBox4_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(229, 364);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(42, 27);
            this.textBox5.TabIndex = 10;
            this.textBox5.TextChanged += new System.EventHandler(this.textBox5_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 367);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 20);
            this.label4.TabIndex = 11;
            this.label4.Text = "Индекс элемента для замены:";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(215, 397);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(71, 27);
            this.button4.TabIndex = 12;
            this.button4.Text = "Ввести";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 457);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(161, 20);
            this.label5.TabIndex = 13;
            this.label5.Text = "Заменить на элемент:";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(173, 454);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(41, 27);
            this.textBox6.TabIndex = 14;
            this.textBox6.TextChanged += new System.EventHandler(this.textBox6_TextChanged);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(155, 487);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(69, 29);
            this.button5.TabIndex = 15;
            this.button5.Text = "Ввести";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(461, 350);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 20);
            this.label6.TabIndex = 16;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(529, 347);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(290, 40);
            this.button6.TabIndex = 17;
            this.button6.Text = "Сортировка массива по модулю";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(529, 421);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(289, 73);
            this.button7.TabIndex = 18;
            this.button7.Text = "Поиск векторов с минимальным и максимальным значением координат";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(399, 547);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(104, 29);
            this.button8.TabIndex = 19;
            this.button8.Text = "Выход";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // button9
            // 
            this.button9.Location = new System.Drawing.Point(529, 284);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(290, 38);
            this.button9.TabIndex = 20;
            this.button9.Text = "Проверить на равенство";
            this.button9.UseVisualStyleBackColor = true;
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(946, 588);
            this.Controls.Add(this.button9);
            this.Controls.Add(this.button8);
            this.Controls.Add(this.button7);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button button1;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button2;
        private TextBox textBox3;
        private Label label1;
        private Label label2;
        private Label label3;
        private Button button3;
        private TextBox textBox4;
        private TextBox textBox5;
        private Label label4;
        private Button button4;
        private Label label5;
        private TextBox textBox6;
        private Button button5;
        private Label label6;
        private Button button6;
        private Button button7;
        private Button button8;
        private Button button9;
    }
}