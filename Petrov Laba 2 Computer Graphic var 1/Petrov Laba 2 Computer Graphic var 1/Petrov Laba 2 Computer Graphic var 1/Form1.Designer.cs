namespace Petrov_Laba_2_Computer_Graphic_var_1
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
            this.OxMoveButton = new System.Windows.Forms.Button();
            this.OxMoveTextBox = new System.Windows.Forms.TextBox();
            this.OyMoveButton = new System.Windows.Forms.Button();
            this.OyMoveTextBox = new System.Windows.Forms.TextBox();
            this.OxReflectionButton = new System.Windows.Forms.Button();
            this.OyReflectionButton = new System.Windows.Forms.Button();
            this.startingPositionButton = new System.Windows.Forms.Button();
            this.YeqXReflectionButton = new System.Windows.Forms.Button();
            this.ZoomOxButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rotateFigureAboutCenterButton = new System.Windows.Forms.Button();
            this.rotateFigureAboutCenterTextBox = new System.Windows.Forms.TextBox();
            this.rotateFigureAboutPointButton = new System.Windows.Forms.Button();
            this.rotatePointXTextBox = new System.Windows.Forms.TextBox();
            this.rotatePointYTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ShowNewFormButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.White;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(800, 600);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // OxMoveButton
            // 
            this.OxMoveButton.Location = new System.Drawing.Point(819, 12);
            this.OxMoveButton.Name = "OxMoveButton";
            this.OxMoveButton.Size = new System.Drawing.Size(113, 39);
            this.OxMoveButton.TabIndex = 1;
            this.OxMoveButton.Text = "Сдвиг по оси Х";
            this.OxMoveButton.UseVisualStyleBackColor = true;
            this.OxMoveButton.Click += new System.EventHandler(this.OxMoveButton_Click);
            // 
            // OxMoveTextBox
            // 
            this.OxMoveTextBox.Location = new System.Drawing.Point(938, 22);
            this.OxMoveTextBox.Name = "OxMoveTextBox";
            this.OxMoveTextBox.Size = new System.Drawing.Size(89, 20);
            this.OxMoveTextBox.TabIndex = 2;
            this.OxMoveTextBox.Text = "0";
            // 
            // OyMoveButton
            // 
            this.OyMoveButton.Location = new System.Drawing.Point(819, 58);
            this.OyMoveButton.Name = "OyMoveButton";
            this.OyMoveButton.Size = new System.Drawing.Size(113, 39);
            this.OyMoveButton.TabIndex = 3;
            this.OyMoveButton.Text = "Сдвиг по оси Y";
            this.OyMoveButton.UseVisualStyleBackColor = true;
            this.OyMoveButton.Click += new System.EventHandler(this.OyMoveButton_Click);
            // 
            // OyMoveTextBox
            // 
            this.OyMoveTextBox.Location = new System.Drawing.Point(938, 68);
            this.OyMoveTextBox.Name = "OyMoveTextBox";
            this.OyMoveTextBox.Size = new System.Drawing.Size(89, 20);
            this.OyMoveTextBox.TabIndex = 4;
            this.OyMoveTextBox.Text = "0";
            // 
            // OxReflectionButton
            // 
            this.OxReflectionButton.Location = new System.Drawing.Point(819, 103);
            this.OxReflectionButton.Name = "OxReflectionButton";
            this.OxReflectionButton.Size = new System.Drawing.Size(113, 53);
            this.OxReflectionButton.TabIndex = 5;
            this.OxReflectionButton.Text = "Отражение относительно оси X";
            this.OxReflectionButton.UseVisualStyleBackColor = true;
            this.OxReflectionButton.Click += new System.EventHandler(this.OxReflectionButton_Click);
            // 
            // OyReflectionButton
            // 
            this.OyReflectionButton.Location = new System.Drawing.Point(938, 103);
            this.OyReflectionButton.Name = "OyReflectionButton";
            this.OyReflectionButton.Size = new System.Drawing.Size(113, 53);
            this.OyReflectionButton.TabIndex = 6;
            this.OyReflectionButton.Text = "Отражение относительно оси Y";
            this.OyReflectionButton.UseVisualStyleBackColor = true;
            this.OyReflectionButton.Click += new System.EventHandler(this.OyReflectionButton_Click);
            // 
            // startingPositionButton
            // 
            this.startingPositionButton.Location = new System.Drawing.Point(819, 560);
            this.startingPositionButton.Name = "startingPositionButton";
            this.startingPositionButton.Size = new System.Drawing.Size(113, 53);
            this.startingPositionButton.TabIndex = 7;
            this.startingPositionButton.Text = "Исходное положение";
            this.startingPositionButton.UseVisualStyleBackColor = true;
            this.startingPositionButton.Click += new System.EventHandler(this.startingPositionButton_Click);
            // 
            // YeqXReflectionButton
            // 
            this.YeqXReflectionButton.Location = new System.Drawing.Point(819, 162);
            this.YeqXReflectionButton.Name = "YeqXReflectionButton";
            this.YeqXReflectionButton.Size = new System.Drawing.Size(113, 53);
            this.YeqXReflectionButton.TabIndex = 8;
            this.YeqXReflectionButton.Text = "Отражение относительно Y=X";
            this.YeqXReflectionButton.UseVisualStyleBackColor = true;
            this.YeqXReflectionButton.Click += new System.EventHandler(this.YeqXReflectionButton_Click);
            // 
            // ZoomOxButton
            // 
            this.ZoomOxButton.Location = new System.Drawing.Point(938, 162);
            this.ZoomOxButton.Name = "ZoomOxButton";
            this.ZoomOxButton.Size = new System.Drawing.Size(113, 53);
            this.ZoomOxButton.TabIndex = 9;
            this.ZoomOxButton.Text = "Масштабирование по X+";
            this.ZoomOxButton.UseVisualStyleBackColor = true;
            this.ZoomOxButton.Click += new System.EventHandler(this.ZoomOxPlusButton_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(819, 221);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(113, 53);
            this.button1.TabIndex = 10;
            this.button1.Text = "Масштабирование по X-";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ZoomOxMinusButton_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(938, 221);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(113, 53);
            this.button2.TabIndex = 11;
            this.button2.Text = "Масштабирование по Y+";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ZoomOyPlusButton_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(819, 280);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(113, 53);
            this.button3.TabIndex = 12;
            this.button3.Text = "Масштабирование по Y-";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.ZoomOyMinusButton_Click);
            // 
            // rotateFigureAboutCenterButton
            // 
            this.rotateFigureAboutCenterButton.Location = new System.Drawing.Point(819, 339);
            this.rotateFigureAboutCenterButton.Name = "rotateFigureAboutCenterButton";
            this.rotateFigureAboutCenterButton.Size = new System.Drawing.Size(113, 53);
            this.rotateFigureAboutCenterButton.TabIndex = 13;
            this.rotateFigureAboutCenterButton.Text = "Поворот на заданый угол относительно (0,0)";
            this.rotateFigureAboutCenterButton.UseVisualStyleBackColor = true;
            this.rotateFigureAboutCenterButton.Click += new System.EventHandler(this.rotateFigureAboutCenterButton_Click);
            // 
            // rotateFigureAboutCenterTextBox
            // 
            this.rotateFigureAboutCenterTextBox.Location = new System.Drawing.Point(938, 356);
            this.rotateFigureAboutCenterTextBox.Name = "rotateFigureAboutCenterTextBox";
            this.rotateFigureAboutCenterTextBox.Size = new System.Drawing.Size(89, 20);
            this.rotateFigureAboutCenterTextBox.TabIndex = 14;
            this.rotateFigureAboutCenterTextBox.Text = "0";
            // 
            // rotateFigureAboutPointButton
            // 
            this.rotateFigureAboutPointButton.Location = new System.Drawing.Point(819, 398);
            this.rotateFigureAboutPointButton.Name = "rotateFigureAboutPointButton";
            this.rotateFigureAboutPointButton.Size = new System.Drawing.Size(113, 53);
            this.rotateFigureAboutPointButton.TabIndex = 15;
            this.rotateFigureAboutPointButton.Text = "Поворот на заданый угол относительно (x,y)";
            this.rotateFigureAboutPointButton.UseVisualStyleBackColor = true;
            this.rotateFigureAboutPointButton.Click += new System.EventHandler(this.rotateFigureAboutPointButton_Click);
            // 
            // rotatePointXTextBox
            // 
            this.rotatePointXTextBox.Location = new System.Drawing.Point(938, 398);
            this.rotatePointXTextBox.Name = "rotatePointXTextBox";
            this.rotatePointXTextBox.Size = new System.Drawing.Size(89, 20);
            this.rotatePointXTextBox.TabIndex = 16;
            this.rotatePointXTextBox.Text = "0";
            // 
            // rotatePointYTextBox
            // 
            this.rotatePointYTextBox.Location = new System.Drawing.Point(938, 431);
            this.rotatePointYTextBox.Name = "rotatePointYTextBox";
            this.rotatePointYTextBox.Size = new System.Drawing.Size(89, 20);
            this.rotatePointYTextBox.TabIndex = 17;
            this.rotatePointYTextBox.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(1033, 401);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "X";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(1033, 434);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(14, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Y";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(1033, 359);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 20;
            this.label3.Text = "Угол";
            // 
            // ShowNewFormButton
            // 
            this.ShowNewFormButton.Location = new System.Drawing.Point(934, 280);
            this.ShowNewFormButton.Name = "ShowNewFormButton";
            this.ShowNewFormButton.Size = new System.Drawing.Size(113, 53);
            this.ShowNewFormButton.TabIndex = 21;
            this.ShowNewFormButton.Text = "Показать колесо";
            this.ShowNewFormButton.UseVisualStyleBackColor = true;
            this.ShowNewFormButton.Click += new System.EventHandler(this.ShowNewFormButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Info;
            this.ClientSize = new System.Drawing.Size(1066, 627);
            this.Controls.Add(this.ShowNewFormButton);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rotatePointYTextBox);
            this.Controls.Add(this.rotatePointXTextBox);
            this.Controls.Add(this.rotateFigureAboutPointButton);
            this.Controls.Add(this.rotateFigureAboutCenterTextBox);
            this.Controls.Add(this.rotateFigureAboutCenterButton);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.ZoomOxButton);
            this.Controls.Add(this.YeqXReflectionButton);
            this.Controls.Add(this.startingPositionButton);
            this.Controls.Add(this.OyReflectionButton);
            this.Controls.Add(this.OxReflectionButton);
            this.Controls.Add(this.OyMoveTextBox);
            this.Controls.Add(this.OyMoveButton);
            this.Controls.Add(this.OxMoveTextBox);
            this.Controls.Add(this.OxMoveButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button OxMoveButton;
        private System.Windows.Forms.TextBox OxMoveTextBox;
        private System.Windows.Forms.Button OyMoveButton;
        private System.Windows.Forms.TextBox OyMoveTextBox;
        private System.Windows.Forms.Button OxReflectionButton;
        private System.Windows.Forms.Button OyReflectionButton;
        private System.Windows.Forms.Button startingPositionButton;
        private System.Windows.Forms.Button YeqXReflectionButton;
        private System.Windows.Forms.Button ZoomOxButton;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button rotateFigureAboutCenterButton;
        private System.Windows.Forms.TextBox rotateFigureAboutCenterTextBox;
        private System.Windows.Forms.Button rotateFigureAboutPointButton;
        private System.Windows.Forms.TextBox rotatePointXTextBox;
        private System.Windows.Forms.TextBox rotatePointYTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ShowNewFormButton;
    }
}

