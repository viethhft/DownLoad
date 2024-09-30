namespace DownLoad
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
            button1 = new Button();
            label1 = new Label();
            link = new TextBox();
            from = new NumericUpDown();
            label2 = new Label();
            label3 = new Label();
            to = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)from).BeginInit();
            ((System.ComponentModel.ISupportInitialize)to).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.Location = new Point(639, 108);
            button1.Name = "button1";
            button1.Size = new Size(149, 161);
            button1.TabIndex = 0;
            button1.Text = "Bắt đầu tải";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 47);
            label1.Name = "label1";
            label1.Size = new Size(215, 32);
            label1.TabIndex = 1;
            label1.Text = "Đường dẫn truyện:";
            // 
            // link
            // 
            link.Location = new Point(243, 44);
            link.Name = "link";
            link.Size = new Size(545, 39);
            link.TabIndex = 2;
            // 
            // from
            // 
            from.Location = new Point(81, 170);
            from.Maximum = new decimal(new int[] { -1981284353, -1966660860, 0, 0 });
            from.Name = "from";
            from.Size = new Size(137, 39);
            from.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 172);
            label2.Name = "label2";
            label2.Size = new Size(46, 32);
            label2.TabIndex = 4;
            label2.Text = "Từ:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(297, 174);
            label3.Name = "label3";
            label3.Size = new Size(63, 32);
            label3.TabIndex = 6;
            label3.Text = "Đến:";
            // 
            // to
            // 
            to.Location = new Point(366, 172);
            to.Maximum = new decimal(new int[] { -1981284353, -1966660860, 0, 0 });
            to.Name = "to";
            to.Size = new Size(162, 39);
            to.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(13F, 32F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 293);
            Controls.Add(label3);
            Controls.Add(to);
            Controls.Add(label2);
            Controls.Add(from);
            Controls.Add(link);
            Controls.Add(label1);
            Controls.Add(button1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)from).EndInit();
            ((System.ComponentModel.ISupportInitialize)to).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label label1;
        private TextBox link;
        private NumericUpDown from;
        private Label label2;
        private Label label3;
        private NumericUpDown to;
    }
}
