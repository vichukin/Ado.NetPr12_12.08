namespace Ado.NetPr12_12._08
{
    partial class SalesForm
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
            panel6 = new Panel();
            comboBox2 = new ComboBox();
            label6 = new Label();
            panel5 = new Panel();
            comboBox1 = new ComboBox();
            label5 = new Label();
            panel4 = new Panel();
            dateTimePicker1 = new DateTimePicker();
            label4 = new Label();
            panel1 = new Panel();
            dateTimePicker2 = new DateTimePicker();
            label1 = new Label();
            button2 = new Button();
            button1 = new Button();
            panel6.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel6
            // 
            panel6.Controls.Add(comboBox2);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(12, 183);
            panel6.Name = "panel6";
            panel6.Size = new Size(301, 58);
            panel6.TabIndex = 5;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(3, 27);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(295, 28);
            comboBox2.TabIndex = 3;
            // 
            // label6
            // 
            label6.Location = new Point(3, 0);
            label6.Name = "label6";
            label6.Size = new Size(295, 21);
            label6.TabIndex = 1;
            label6.Text = "Country";
            // 
            // panel5
            // 
            panel5.Controls.Add(comboBox1);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(12, 126);
            panel5.Name = "panel5";
            panel5.Size = new Size(301, 58);
            panel5.TabIndex = 7;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(3, 23);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(295, 28);
            comboBox1.TabIndex = 2;
            // 
            // label5
            // 
            label5.Location = new Point(3, 0);
            label5.Name = "label5";
            label5.Size = new Size(295, 21);
            label5.TabIndex = 1;
            label5.Text = "Product";
            // 
            // panel4
            // 
            panel4.Controls.Add(dateTimePicker1);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(12, 12);
            panel4.Name = "panel4";
            panel4.Size = new Size(301, 58);
            panel4.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.Location = new Point(3, 24);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.Size = new Size(295, 27);
            dateTimePicker1.TabIndex = 2;
            dateTimePicker1.Value = new DateTime(2024, 1, 3, 0, 0, 0, 0);
            // 
            // label4
            // 
            label4.Location = new Point(3, 0);
            label4.Name = "label4";
            label4.Size = new Size(295, 21);
            label4.TabIndex = 1;
            label4.Text = "Start";
            // 
            // panel1
            // 
            panel1.Controls.Add(dateTimePicker2);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 69);
            panel1.Name = "panel1";
            panel1.Size = new Size(301, 58);
            panel1.TabIndex = 7;
            // 
            // dateTimePicker2
            // 
            dateTimePicker2.Location = new Point(3, 24);
            dateTimePicker2.Name = "dateTimePicker2";
            dateTimePicker2.Size = new Size(295, 27);
            dateTimePicker2.TabIndex = 2;
            dateTimePicker2.Value = new DateTime(2024, 1, 3, 0, 0, 0, 0);
            // 
            // label1
            // 
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(295, 21);
            label1.TabIndex = 1;
            label1.Text = "End";
            // 
            // button2
            // 
            button2.Location = new Point(170, 247);
            button2.Name = "button2";
            button2.Size = new Size(143, 29);
            button2.TabIndex = 9;
            button2.Text = "Close";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(12, 247);
            button1.Name = "button1";
            button1.Size = new Size(143, 29);
            button1.TabIndex = 8;
            button1.Text = "Save";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SalesForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(330, 286);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(panel1);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Name = "SalesForm";
            Text = "SalesForm";
            Load += SalesForm_Load;
            panel6.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel4.ResumeLayout(false);
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel6;
        private ComboBox comboBox2;
        private Label label6;
        private Panel panel5;
        private ComboBox comboBox1;
        private Label label5;
        private Panel panel4;
        private DateTimePicker dateTimePicker1;
        private Label label4;
        private Panel panel1;
        private DateTimePicker dateTimePicker2;
        private Label label1;
        private Button button2;
        private Button button1;
    }
}