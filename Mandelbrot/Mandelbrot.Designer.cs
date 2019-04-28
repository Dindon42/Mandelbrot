namespace Mandelbrot
{
  partial class Mandelbrot
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
      this.PB = new System.Windows.Forms.PictureBox();
      ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
      this.SuspendLayout();
      // 
      // PB
      // 
      this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PB.Location = new System.Drawing.Point(13, 13);
      this.PB.Name = "PB";
      this.PB.Size = new System.Drawing.Size(1050, 600);
      this.PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PB.TabIndex = 0;
      this.PB.TabStop = false;
      // 
      // Mandelbrot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1080, 630);
      this.Controls.Add(this.PB);
      this.Name = "Mandelbrot";
      this.Text = "Mandelbrot";
      ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.PictureBox PB;
  }
}

