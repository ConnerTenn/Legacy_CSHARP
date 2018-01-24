namespace BasicGraphics1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Increment_In = new System.Windows.Forms.TextBox();
            this.Length_In = new System.Windows.Forms.TextBox();
            this.Angle_In = new System.Windows.Forms.TextBox();
            this.Number_Line_In = new System.Windows.Forms.TextBox();
            this.Go_Button = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.canvas = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Control;
            this.panel1.Controls.Add(this.Increment_In);
            this.panel1.Controls.Add(this.Length_In);
            this.panel1.Controls.Add(this.Angle_In);
            this.panel1.Controls.Add(this.Number_Line_In);
            this.panel1.Controls.Add(this.Go_Button);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(584, 60);
            this.panel1.TabIndex = 0;
            // 
            // Increment_In
            // 
            this.Increment_In.Location = new System.Drawing.Point(315, 28);
            this.Increment_In.Name = "Increment_In";
            this.Increment_In.Size = new System.Drawing.Size(72, 22);
            this.Increment_In.TabIndex = 8;
            this.Increment_In.Text = "5";
            this.Increment_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Length_In
            // 
            this.Length_In.Location = new System.Drawing.Point(235, 28);
            this.Length_In.Name = "Length_In";
            this.Length_In.Size = new System.Drawing.Size(51, 22);
            this.Length_In.TabIndex = 7;
            this.Length_In.Text = "50";
            this.Length_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Angle_In
            // 
            this.Angle_In.Location = new System.Drawing.Point(158, 28);
            this.Angle_In.Name = "Angle_In";
            this.Angle_In.Size = new System.Drawing.Size(45, 22);
            this.Angle_In.TabIndex = 6;
            this.Angle_In.Text = "90";
            this.Angle_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Number_Line_In
            // 
            this.Number_Line_In.Location = new System.Drawing.Point(15, 28);
            this.Number_Line_In.Name = "Number_Line_In";
            this.Number_Line_In.Size = new System.Drawing.Size(117, 22);
            this.Number_Line_In.TabIndex = 5;
            this.Number_Line_In.Text = "10";
            this.Number_Line_In.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Go_Button
            // 
            this.Go_Button.Location = new System.Drawing.Point(467, 12);
            this.Go_Button.Name = "Go_Button";
            this.Go_Button.Size = new System.Drawing.Size(75, 38);
            this.Go_Button.TabIndex = 4;
            this.Go_Button.Text = "Go";
            this.Go_Button.UseVisualStyleBackColor = true;
            this.Go_Button.Click += new System.EventHandler(this.Go_Button_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(312, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(75, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Increment";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(232, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Length";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(155, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Angle";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of Lines";
            // 
            // canvas
            // 
            this.canvas.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 60);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(584, 301);
            this.canvas.TabIndex = 1;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 361);
            this.Controls.Add(this.canvas);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BasicGraphics1";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox Increment_In;
        private System.Windows.Forms.TextBox Length_In;
        private System.Windows.Forms.TextBox Angle_In;
        private System.Windows.Forms.TextBox Number_Line_In;
        private System.Windows.Forms.Button Go_Button;
    }
}

