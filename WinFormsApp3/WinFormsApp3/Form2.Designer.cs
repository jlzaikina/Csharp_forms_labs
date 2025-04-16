namespace WinFormsApp3
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
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.ball = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.player2 = new System.Windows.Forms.PictureBox();
            this.player1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.ball)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ForeColor = System.Drawing.Color.Lime;
            this.label1.Location = new System.Drawing.Point(436, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 45);
            this.label1.TabIndex = 4;
            this.label1.Text = "00";
            // 
            // ball
            // 
            this.ball.BackColor = System.Drawing.Color.FloralWhite;
            this.ball.Location = new System.Drawing.Point(449, 259);
            this.ball.Name = "ball";
            this.ball.Size = new System.Drawing.Size(25, 24);
            this.ball.TabIndex = 5;
            this.ball.TabStop = false;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 20;
            this.timer1.Tick += new System.EventHandler(this.TimerTick);
            // 
            // player2
            // 
            this.player2.BackColor = System.Drawing.Color.Red;
            this.player2.Location = new System.Drawing.Point(878, 226);
            this.player2.Name = "player2";
            this.player2.Size = new System.Drawing.Size(26, 109);
            this.player2.TabIndex = 6;
            this.player2.TabStop = false;
            // 
            // player1
            // 
            this.player1.BackColor = System.Drawing.Color.Lime;
            this.player1.Location = new System.Drawing.Point(12, 226);
            this.player1.Name = "player1";
            this.player1.Size = new System.Drawing.Size(26, 109);
            this.player1.TabIndex = 7;
            this.player1.TabStop = false;
            this.player1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(436, 512);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 45);
            this.label2.TabIndex = 8;
            this.label2.Text = "00";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(283, 239);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(367, 81);
            this.label3.TabIndex = 9;
            this.label3.Text = "Game Over!";
            this.label3.Visible = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SteelBlue;
            this.ClientSize = new System.Drawing.Size(926, 566);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.player1);
            this.Controls.Add(this.player2);
            this.Controls.Add(this.ball);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Ping-pong";
            this.Load += new System.EventHandler(this.Form2_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyisdown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyisup);
            ((System.ComponentModel.ISupportInitialize)(this.ball)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private PictureBox ball;
        private System.Windows.Forms.Timer timer1;
        private PictureBox player2;
        private PictureBox player1;
        private Label label2;
        private Label label3;
    }
}