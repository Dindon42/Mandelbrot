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
      this.iGrayScale = new System.Windows.Forms.CheckBox();
      this.iZF = new System.Windows.Forms.TrackBar();
      this.iColSeg = new System.Windows.Forms.TrackBar();
      this.label1 = new System.Windows.Forms.Label();
      this.label2 = new System.Windows.Forms.Label();
      this.RandColors = new System.Windows.Forms.Button();
      this.ColSegLabel = new System.Windows.Forms.Label();
      this.iZFLabel = new System.Windows.Forms.Label();
      this.UpdImg = new System.Windows.Forms.Button();
      this.button1 = new System.Windows.Forms.Button();
      this.SmartZoom = new System.Windows.Forms.CheckBox();
      this.Reset = new System.Windows.Forms.Button();
      ((System.ComponentModel.ISupportInitialize)(this.PB)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.iZF)).BeginInit();
      ((System.ComponentModel.ISupportInitialize)(this.iColSeg)).BeginInit();
      this.SuspendLayout();
      // 
      // PB
      // 
      this.PB.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
      this.PB.Location = new System.Drawing.Point(13, 84);
      this.PB.Name = "PB";
      this.PB.Size = new System.Drawing.Size(1050, 600);
      this.PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
      this.PB.TabIndex = 0;
      this.PB.TabStop = false;
      // 
      // iGrayScale
      // 
      this.iGrayScale.AutoSize = true;
      this.iGrayScale.Location = new System.Drawing.Point(13, 5);
      this.iGrayScale.Name = "iGrayScale";
      this.iGrayScale.Size = new System.Drawing.Size(73, 17);
      this.iGrayScale.TabIndex = 1;
      this.iGrayScale.Text = "Grayscale";
      this.iGrayScale.UseVisualStyleBackColor = true;
      this.iGrayScale.CheckedChanged += new System.EventHandler(this.iGrayScale_CheckedChanged);
      // 
      // iZF
      // 
      this.iZF.Location = new System.Drawing.Point(181, 21);
      this.iZF.Maximum = 19;
      this.iZF.Minimum = 1;
      this.iZF.Name = "iZF";
      this.iZF.Size = new System.Drawing.Size(67, 42);
      this.iZF.TabIndex = 2;
      this.iZF.Value = 2;
      this.iZF.Scroll += new System.EventHandler(this.iZF_Scroll);
      // 
      // iColSeg
      // 
      this.iColSeg.Location = new System.Drawing.Point(95, 20);
      this.iColSeg.Maximum = 25;
      this.iColSeg.Minimum = 1;
      this.iColSeg.Name = "iColSeg";
      this.iColSeg.Size = new System.Drawing.Size(66, 42);
      this.iColSeg.TabIndex = 3;
      this.iColSeg.Value = 3;
      this.iColSeg.Scroll += new System.EventHandler(this.iColSeg_Scroll);
      // 
      // label1
      // 
      this.label1.AutoSize = true;
      this.label1.Location = new System.Drawing.Point(178, 5);
      this.label1.Name = "label1";
      this.label1.Size = new System.Drawing.Size(37, 13);
      this.label1.TabIndex = 4;
      this.label1.Text = "Zoom:";
      // 
      // label2
      // 
      this.label2.AutoSize = true;
      this.label2.Location = new System.Drawing.Point(92, 5);
      this.label2.Name = "label2";
      this.label2.Size = new System.Drawing.Size(39, 13);
      this.label2.TabIndex = 5;
      this.label2.Text = "Colors:";
      // 
      // RandColors
      // 
      this.RandColors.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.RandColors.Location = new System.Drawing.Point(990, 5);
      this.RandColors.Name = "RandColors";
      this.RandColors.Size = new System.Drawing.Size(73, 32);
      this.RandColors.TabIndex = 6;
      this.RandColors.Text = "RandCol";
      this.RandColors.UseVisualStyleBackColor = true;
      this.RandColors.Click += new System.EventHandler(this.RandClick);
      // 
      // ColSegLabel
      // 
      this.ColSegLabel.AutoSize = true;
      this.ColSegLabel.Location = new System.Drawing.Point(137, 5);
      this.ColSegLabel.Name = "ColSegLabel";
      this.ColSegLabel.Size = new System.Drawing.Size(35, 13);
      this.ColSegLabel.TabIndex = 7;
      this.ColSegLabel.Text = "label3";
      // 
      // iZFLabel
      // 
      this.iZFLabel.AutoSize = true;
      this.iZFLabel.Location = new System.Drawing.Point(218, 5);
      this.iZFLabel.Name = "iZFLabel";
      this.iZFLabel.Size = new System.Drawing.Size(35, 13);
      this.iZFLabel.TabIndex = 8;
      this.iZFLabel.Text = "label3";
      // 
      // UpdImg
      // 
      this.UpdImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.UpdImg.Location = new System.Drawing.Point(898, 43);
      this.UpdImg.Name = "UpdImg";
      this.UpdImg.Size = new System.Drawing.Size(86, 32);
      this.UpdImg.TabIndex = 9;
      this.UpdImg.Text = "UpdImg";
      this.UpdImg.UseVisualStyleBackColor = true;
      this.UpdImg.Click += new System.EventHandler(this.UpdImg_Click);
      // 
      // button1
      // 
      this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.button1.Location = new System.Drawing.Point(898, 5);
      this.button1.Name = "button1";
      this.button1.Size = new System.Drawing.Size(86, 32);
      this.button1.TabIndex = 10;
      this.button1.Text = "NormalColors";
      this.button1.UseVisualStyleBackColor = true;
      this.button1.Click += new System.EventHandler(this.NormColors);
      // 
      // SmartZoom
      // 
      this.SmartZoom.AutoSize = true;
      this.SmartZoom.Checked = true;
      this.SmartZoom.CheckState = System.Windows.Forms.CheckState.Checked;
      this.SmartZoom.Location = new System.Drawing.Point(13, 28);
      this.SmartZoom.Name = "SmartZoom";
      this.SmartZoom.Size = new System.Drawing.Size(80, 17);
      this.SmartZoom.TabIndex = 11;
      this.SmartZoom.Text = "SmartZoom";
      this.SmartZoom.UseVisualStyleBackColor = true;
      // 
      // Reset
      // 
      this.Reset.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
      this.Reset.Location = new System.Drawing.Point(990, 43);
      this.Reset.Name = "Reset";
      this.Reset.Size = new System.Drawing.Size(73, 32);
      this.Reset.TabIndex = 12;
      this.Reset.Text = "Reset";
      this.Reset.UseVisualStyleBackColor = true;
      this.Reset.Click += new System.EventHandler(this.Reset_Click);
      // 
      // Mandelbrot
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(1080, 701);
      this.Controls.Add(this.Reset);
      this.Controls.Add(this.SmartZoom);
      this.Controls.Add(this.button1);
      this.Controls.Add(this.UpdImg);
      this.Controls.Add(this.iZFLabel);
      this.Controls.Add(this.ColSegLabel);
      this.Controls.Add(this.RandColors);
      this.Controls.Add(this.label2);
      this.Controls.Add(this.label1);
      this.Controls.Add(this.iColSeg);
      this.Controls.Add(this.iZF);
      this.Controls.Add(this.iGrayScale);
      this.Controls.Add(this.PB);
      this.Name = "Mandelbrot";
      this.Text = "Mandelbrot";
      ((System.ComponentModel.ISupportInitialize)(this.PB)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.iZF)).EndInit();
      ((System.ComponentModel.ISupportInitialize)(this.iColSeg)).EndInit();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.PictureBox PB;
    private System.Windows.Forms.CheckBox iGrayScale;
    private System.Windows.Forms.TrackBar iZF;
    private System.Windows.Forms.TrackBar iColSeg;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Button RandColors;
    private System.Windows.Forms.Label ColSegLabel;
    private System.Windows.Forms.Label iZFLabel;
    private System.Windows.Forms.Button UpdImg;
    private System.Windows.Forms.Button button1;
    private System.Windows.Forms.CheckBox SmartZoom;
    private System.Windows.Forms.Button Reset;
  }
}

