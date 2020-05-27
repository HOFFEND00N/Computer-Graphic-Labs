namespace _3_Laba_Computer_Graphic_Petrov
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BuildSegmentButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.x1TextBox = new System.Windows.Forms.TextBox();
            this.y1TextBox = new System.Windows.Forms.TextBox();
            this.x2TextBox = new System.Windows.Forms.TextBox();
            this.y2TextBox = new System.Windows.Forms.TextBox();
            this.AlgorithmButton = new System.Windows.Forms.Button();
            this.BuildCircleButton = new System.Windows.Forms.Button();
            this.CircleAlgoButton = new System.Windows.Forms.Button();
            this.RTextBox = new System.Windows.Forms.TextBox();
            this.OyTextBox = new System.Windows.Forms.TextBox();
            this.OxTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1070, 740);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // BuildSegmentButton
            // 
            this.BuildSegmentButton.Location = new System.Drawing.Point(1093, 122);
            this.BuildSegmentButton.Name = "BuildSegmentButton";
            this.BuildSegmentButton.Size = new System.Drawing.Size(125, 43);
            this.BuildSegmentButton.TabIndex = 1;
            this.BuildSegmentButton.Text = "Build segment";
            this.BuildSegmentButton.UseVisualStyleBackColor = true;
            this.BuildSegmentButton.Click += new System.EventHandler(this.BuildSegmentButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1090, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "x1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1089, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "y1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1089, 69);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "x2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(1088, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(23, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "y2";
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(1118, 9);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(100, 22);
            this.x1TextBox.TabIndex = 6;
            this.x1TextBox.Text = "0";
            // 
            // y1TextBox
            // 
            this.y1TextBox.Location = new System.Drawing.Point(1118, 38);
            this.y1TextBox.Name = "y1TextBox";
            this.y1TextBox.Size = new System.Drawing.Size(100, 22);
            this.y1TextBox.TabIndex = 7;
            this.y1TextBox.Text = "0";
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(1118, 66);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(100, 22);
            this.x2TextBox.TabIndex = 8;
            this.x2TextBox.Text = "10";
            // 
            // y2TextBox
            // 
            this.y2TextBox.Location = new System.Drawing.Point(1118, 94);
            this.y2TextBox.Name = "y2TextBox";
            this.y2TextBox.Size = new System.Drawing.Size(100, 22);
            this.y2TextBox.TabIndex = 9;
            this.y2TextBox.Text = "5";
            // 
            // AlgorithmButton
            // 
            this.AlgorithmButton.Location = new System.Drawing.Point(1093, 171);
            this.AlgorithmButton.Name = "AlgorithmButton";
            this.AlgorithmButton.Size = new System.Drawing.Size(125, 40);
            this.AlgorithmButton.TabIndex = 10;
            this.AlgorithmButton.Text = "Segment Algo";
            this.AlgorithmButton.UseVisualStyleBackColor = true;
            this.AlgorithmButton.Click += new System.EventHandler(this.AlgorithmButton_Click);
            // 
            // BuildCircleButton
            // 
            this.BuildCircleButton.Location = new System.Drawing.Point(1093, 351);
            this.BuildCircleButton.Name = "BuildCircleButton";
            this.BuildCircleButton.Size = new System.Drawing.Size(126, 40);
            this.BuildCircleButton.TabIndex = 11;
            this.BuildCircleButton.Text = "Build Circle";
            this.BuildCircleButton.UseVisualStyleBackColor = true;
            this.BuildCircleButton.Click += new System.EventHandler(this.BuildCircleButton_Click);
            // 
            // CircleAlgoButton
            // 
            this.CircleAlgoButton.Location = new System.Drawing.Point(1093, 305);
            this.CircleAlgoButton.Name = "CircleAlgoButton";
            this.CircleAlgoButton.Size = new System.Drawing.Size(126, 40);
            this.CircleAlgoButton.TabIndex = 12;
            this.CircleAlgoButton.Text = "Circle Algo";
            this.CircleAlgoButton.UseVisualStyleBackColor = true;
            this.CircleAlgoButton.Click += new System.EventHandler(this.CircleAlgoButton_Click);
            // 
            // RTextBox
            // 
            this.RTextBox.Location = new System.Drawing.Point(1118, 274);
            this.RTextBox.Name = "RTextBox";
            this.RTextBox.Size = new System.Drawing.Size(100, 22);
            this.RTextBox.TabIndex = 18;
            this.RTextBox.Text = "10";
            // 
            // OyTextBox
            // 
            this.OyTextBox.Location = new System.Drawing.Point(1118, 246);
            this.OyTextBox.Name = "OyTextBox";
            this.OyTextBox.Size = new System.Drawing.Size(100, 22);
            this.OyTextBox.TabIndex = 17;
            this.OyTextBox.Text = "0";
            // 
            // OxTextBox
            // 
            this.OxTextBox.Location = new System.Drawing.Point(1118, 217);
            this.OxTextBox.Name = "OxTextBox";
            this.OxTextBox.Size = new System.Drawing.Size(100, 22);
            this.OxTextBox.TabIndex = 16;
            this.OxTextBox.Text = "0";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(1089, 277);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "R";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(1090, 222);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 17);
            this.label7.TabIndex = 13;
            this.label7.Text = "Ox";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(1089, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(26, 17);
            this.label6.TabIndex = 14;
            this.label6.Text = "Oy";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1230, 845);
            this.Controls.Add(this.RTextBox);
            this.Controls.Add(this.OyTextBox);
            this.Controls.Add(this.OxTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.CircleAlgoButton);
            this.Controls.Add(this.BuildCircleButton);
            this.Controls.Add(this.AlgorithmButton);
            this.Controls.Add(this.y2TextBox);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.y1TextBox);
            this.Controls.Add(this.x1TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.BuildSegmentButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BuildSegmentButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x1TextBox;
        private System.Windows.Forms.TextBox y1TextBox;
        private System.Windows.Forms.TextBox x2TextBox;
        private System.Windows.Forms.TextBox y2TextBox;
        private System.Windows.Forms.Button AlgorithmButton;
        private System.Windows.Forms.Button BuildCircleButton;
        private System.Windows.Forms.Button CircleAlgoButton;
        private System.Windows.Forms.TextBox RTextBox;
        private System.Windows.Forms.TextBox OyTextBox;
        private System.Windows.Forms.TextBox OxTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
    }
}

