namespace Enigma
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            textBox1 = new TextBox();
            şifreoluştur = new Button();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            richTextBox1 = new RichTextBox();
            şifrele = new Button();
            richTextBox2 = new RichTextBox();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.BackColor = SystemColors.ScrollBar;
            textBox1.Location = new Point(102, 417);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(69, 23);
            textBox1.TabIndex = 0;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // şifreoluştur
            // 
            şifreoluştur.Location = new Point(177, 416);
            şifreoluştur.Name = "şifreoluştur";
            şifreoluştur.Size = new Size(75, 81);
            şifreoluştur.TabIndex = 1;
            şifreoluştur.Text = "Şifre oluştur";
            şifreoluştur.UseVisualStyleBackColor = true;
            şifreoluştur.Click += button1_Click;
            // 
            // textBox2
            // 
            textBox2.BackColor = SystemColors.ScrollBar;
            textBox2.Location = new Point(102, 446);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(69, 23);
            textBox2.TabIndex = 2;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // textBox3
            // 
            textBox3.BackColor = SystemColors.ScrollBar;
            textBox3.Location = new Point(102, 475);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(69, 23);
            textBox3.TabIndex = 3;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = SystemColors.ScrollBar;
            richTextBox1.Location = new Point(22, 25);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(305, 165);
            richTextBox1.TabIndex = 4;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // şifrele
            // 
            şifrele.Location = new Point(22, 196);
            şifrele.Name = "şifrele";
            şifrele.Size = new Size(305, 32);
            şifrele.TabIndex = 5;
            şifrele.Text = "Şifrele";
            şifrele.UseVisualStyleBackColor = true;
            şifrele.Click += button2_Click;
            // 
            // richTextBox2
            // 
            richTextBox2.BackColor = SystemColors.ScrollBar;
            richTextBox2.Location = new Point(22, 246);
            richTextBox2.Name = "richTextBox2";
            richTextBox2.Size = new Size(305, 165);
            richTextBox2.TabIndex = 6;
            richTextBox2.Text = "";
            richTextBox2.TextChanged += richTextBox2_TextChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.WindowFrame;
            ClientSize = new Size(341, 511);
            Controls.Add(richTextBox2);
            Controls.Add(şifrele);
            Controls.Add(richTextBox1);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(şifreoluştur);
            Controls.Add(textBox1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button şifreoluştur;
        private TextBox textBox2;
        private TextBox textBox3;
        private RichTextBox richTextBox1;
        private Button şifrele;
        private RichTextBox richTextBox2;
    }
}
