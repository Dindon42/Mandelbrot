﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Mandelbrot
{
  public partial class Mandelbrot : Form
  {
    //Tunables
    bool Grayscale = false;
    bool RandColors = false;
    int ColSegments = 0;
    double ZoomFactor = 0;

    int PrevW;
    int PrevH;
    
    Bitmap MyMandelbrot;
    //Starting values;
    double MinX;
    double MaxX;
    double MinY;
    double MaxY;

    XY[,] Coord;

    int MaxIter;

    List<int[]> Colors = null;

    const double ImageAspectRatioWtoH=1.75;

    public Mandelbrot()
    {
      Load += new EventHandler(Mandelbrot_Load);

      InitializeComponent();
      ResizeEnd += new EventHandler(Mandelbrot_Resize);
      PB.MouseClick += new MouseEventHandler(PB_MouseClick);
      PB.MouseMove += new MouseEventHandler(PB_MouseMove);
    }

    void ReInitializeParams()
    {
      MinX = -2.5;
      MaxX = 1;
      MinY = -1;
      MaxY = 1;
      iColSeg.Value = 3;
      iZF.Value = 2;
      iGrayScale.Checked = false;
      iSmartZoom.Checked = true;
      iRandCol.Checked = false;

      UpdateParameters();
      UpdateImage();
    }

    void UpdateParameters()
    {
      ColSegments = iColSeg.Value;
      ZoomFactor = 0.05* iZF.Value;
      Grayscale = iGrayScale.Checked;
      ColSegLabel.Text = iColSeg.Value.ToString();
      RandColors = iRandCol.Checked;
      iZFLabel.Text = ZoomFactor.ToString();


      BuildColorList();
    }

    void Mandelbrot_Load(object sender, EventArgs e)
    {
      ReInitializeParams();
    }
    void Mandelbrot_Resize(object sender, EventArgs e)
    {
      if (PrevH == Height && PrevW == Width) return;
      UpdateImage();
      PrevH = Height;
      PrevW = Width;
    }

    void PB_MouseClick(object sender, MouseEventArgs e)
    {
      XY XY = Coord[e.X, e.Y];
      bool ZoomIn = false;
      bool ZoomOut = false;

      switch (e.Button)
      {
        case MouseButtons.Right:
        {
          //Zoom Out
          if (iSmartZoom.Checked) UpdateColSegScrollBar(false);
          ZoomOut = true;
          break;
        }
        case MouseButtons.Left:
        {
          //Zoom In.
          if (iSmartZoom.Checked) UpdateColSegScrollBar(true);
          ZoomIn = true;
          break;
        }
        case MouseButtons.Middle:
        {
          break;
        }
        default:
        {
          return;
        }
      }
      UpdateCanvas(XY, ZoomIn, ZoomOut);
    }

    void UpdateCanvas(XY NewCenter,bool ZoomIn, bool ZoomOut)
    {
      double ZF = ZoomIn ? ZoomFactor : ZoomOut? 1 / ZoomFactor: 1;

      double NewHalfWidth = (MaxX - MinX) * ZF / 2;
      double NewHalfHeight = (MaxY - MinY) * ZF / 2;

      MinX = NewCenter.X - NewHalfWidth;
      MaxX = NewCenter.X + NewHalfWidth;
      MinY = NewCenter.Y - NewHalfHeight;
      MaxY = NewCenter.Y + NewHalfHeight;
      UpdateImage();
    }

    void UpdateImage()
    {
      MyMandelbrot = UpdatePixels();
      PB.Image = MyMandelbrot;
    }

    Bitmap UpdatePixels()
    {
      int ImgWidth = PB.Width;
      int ImgHeight = PB.Height;

      Bitmap Pix = new Bitmap(ImgWidth, ImgHeight);

      int[,] Iterations = new int[ImgWidth, ImgHeight];


      Coord = UpdateCoord();

      for (int i = 0; i < ImgWidth; i++)
      {
        for (int j = 0; j < ImgHeight; j++)
        {
          Iterations[i,j]=CalculateMandelBrotIterations(Coord[i, j]);
        }
      }

      for (int i = 0; i < ImgWidth; i++)
      {
        for (int j = 0; j < ImgHeight; j++)
        {
          int c=Iterations[i, j]%Colors.Count();
          var Col=Colors[c];
          Pix.SetPixel(i, j, Color.FromArgb(255, Col[0], Col[1], Col[2]));
        }
      }

      return Pix;
    }

    int CalculateMandelBrotIterations(XY Coord)
    {
      int NumIters = 0;
      int MaxIters = MaxIter;

      double x0=Coord.X;
      double y0=Coord.Y;

      double x = 0;
      double y = 0;

      while (x * x + y * y <= 2 * 2 && NumIters < MaxIters)
      {
        double xtemp = x * x - y * y + x0;
        y = 2 * x * y + y0;
        x = xtemp;
        NumIters++;
      }


      return NumIters;
    }

    XY[,] UpdateCoord()
    {
      int ImgWidth = PB.Width;
      int ImgHeight = PB.Height;

      XY[,] NewCoord = new XY[ImgWidth, ImgHeight];

      for (int i = 0; i < ImgWidth; i++)
      {
        for (int j = 0; j < ImgHeight; j++)
        {
          double x = MinX + (double) i * (MaxX - MinX) / ImgWidth;
          double y = MaxY - (double) j * (MaxY - MinY) / ImgHeight;
          NewCoord[i, j] = new XY(x,y);
        }
      }

      return NewCoord;
    }

    void BuildColorList()
    {
      Colors = new List<int[]>();
      int Max=255;

      for (int i = 0; i <= ColSegments; i++)
      {
        for (int j = 0; j <= ColSegments; j++)
        {
          for (int k = 0; k <= ColSegments; k++)
          {
            int r = i * Convert.ToInt16((double)Max / (double)ColSegments);
            int g = j * Convert.ToInt16((double)Max / (double)ColSegments);
            int b = k * Convert.ToInt16((double)Max / (double)ColSegments);

            if (Grayscale)
            {
              r = Convert.ToInt16((double)(r + g + b)/(double)3);
              g = r;
              b = r;
            }
            else
            {
              g = j * Convert.ToInt16((double)Max / (double)ColSegments);
              b = k * Convert.ToInt16((double)Max / (double)ColSegments);
            }
            if (r > 255) r = 255;
            if (g > 255) g = 255;
            if (b > 255) b = 255;


            Colors.Add(new int[3] { r, g, b});
          }
        }
      }
      Colors = Colors.Select(x => x).Distinct().ToList();

      if (RandColors) Colors.Shuffle();

      MaxIter = Colors.Count();
    }

    private void iColSeg_Scroll(object sender, EventArgs e)
    {
      UpdateParameters();
    }

    private void iZF_Scroll(object sender, EventArgs e)
    {
      UpdateParameters();
    }

    private void UpdImg_Click(object sender, EventArgs e)
    {
      UpdateParameters();
      UpdateImage();
    }

    private void iGrayScale_CheckedChanged(object sender, EventArgs e)
    {
      UpdateParameters();
    }

    private void Reset_Click(object sender, EventArgs e)
    {
      ReInitializeParams();
    }

    private void RandCol_CheckedChanged(object sender, EventArgs e)
    {
      UpdateParameters();
    }

    void PB_MouseMove(object sender, MouseEventArgs e)
    {
      if (e.X >= Coord.GetLength(0) || e.Y >= Coord.GetLength(1)) return;

      XY CursorXYPos = Coord[e.X, e.Y];

      xpos.Text = "x: " + CursorXYPos.X;
      ypos.Text = "y: " + CursorXYPos.Y;
    }

    private void ColM_Click(object sender, EventArgs e)
    {
      UpdateColSegScrollBar(false);
    }

    private void ColP_Click(object sender, EventArgs e)
    {
      UpdateColSegScrollBar(true);
    }

    void UpdateColSegScrollBar(bool Plus)
    {
      if(Plus)
      {
        if(iColSeg.Value < iColSeg.Maximum)  iColSeg.Value++;
      }
      else
      {
        if(iColSeg.Value > iColSeg.Minimum)  iColSeg.Value--;
      }
      UpdateParameters();
    }
  }
}
