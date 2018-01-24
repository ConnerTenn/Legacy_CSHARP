namespace BasicGraphics3
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
            this.canvas = new System.Windows.Forms.Panel();
            this.CoordsDisp = new System.Windows.Forms.TextBox();
            this.MCoordsDisp = new System.Windows.Forms.TextBox();
            this.canvas.SuspendLayout();
            this.SuspendLayout();
            // 
            // canvas
            // 
            this.canvas.Controls.Add(this.MCoordsDisp);
            this.canvas.Controls.Add(this.CoordsDisp);
            this.canvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canvas.Location = new System.Drawing.Point(0, 0);
            this.canvas.Name = "canvas";
            this.canvas.Size = new System.Drawing.Size(502, 364);
            this.canvas.TabIndex = 0;
            this.canvas.Paint += new System.Windows.Forms.PaintEventHandler(this.canvas_Paint);
            this.canvas.MouseClick += new System.Windows.Forms.MouseEventHandler(this.canvas_MouseClick);
            // 
            // CoordsDisp
            // 
            this.CoordsDisp.Enabled = false;
            this.CoordsDisp.Location = new System.Drawing.Point(192, 319);
            this.CoordsDisp.Name = "CoordsDisp";
            this.CoordsDisp.ReadOnly = true;
            this.CoordsDisp.Size = new System.Drawing.Size(100, 20);
            this.CoordsDisp.TabIndex = 0;
            // 
            // MCoordsDisp
            // 
            this.MCoordsDisp.Enabled = false;
            this.MCoordsDisp.Location = new System.Drawing.Point(192, 341);
            this.MCoordsDisp.Name = "MCoordsDisp";
            this.MCoordsDisp.ReadOnly = true;
            this.MCoordsDisp.Size = new System.Drawing.Size(100, 20);
            this.MCoordsDisp.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 364);
            this.Controls.Add(this.canvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.canvas.ResumeLayout(false);
            this.canvas.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel canvas;
        private System.Windows.Forms.TextBox CoordsDisp;
        private System.Windows.Forms.TextBox MCoordsDisp;
    }
}

