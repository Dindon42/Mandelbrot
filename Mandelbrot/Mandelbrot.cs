using System;
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
    int StartColSegments = 2;
    decimal ZoomFactor = (decimal) 0.1;
    bool Grayscale = false;

    
    Bitmap MyMandelbrot;
    ushort ImgWidth;
    ushort ImgHeight;
    int ColSegments;
    //Starting values;
    decimal MinX = (decimal) -2.5;
    decimal MaxX = (decimal) 1;
    decimal MinY = (decimal)-1;
    decimal MaxY = (decimal) 1;

    XY[,] Coord;

    int MaxIter;

    List<int[]> Colors = null;

    const double ImageAspectRatioWtoH=1.75;

    public Mandelbrot()
    {
      ColSegments = StartColSegments;
      BuildColorList();
      Load += new EventHandler(Mandelbrot_Load);
      ResizeEnd += new EventHandler(Mandelbrot_Resize);
      
      InitializeComponent();
      PB.MouseClick += new MouseEventHandler(PB_MouseClick);
    }

    void Mandelbrot_Load(object sender, EventArgs e)
    {
      UpdateImage();
    }
    void Mandelbrot_Resize(object sender, EventArgs e)
    {
      UpdateImage();
    }

    void PB_MouseClick(object sender, MouseEventArgs e)
    {
      XY XY = Coord[e.X, e.Y];
      bool ZoomIn = false;
      switch (e.Button)
      {
        case MouseButtons.Right:
        {
          if (ColSegments == StartColSegments) return;
          //Zoom Out
          ColSegments--;
          ZoomIn = false;
          break;
        }
        case MouseButtons.Left:
        {
          //Zoom In.
          ColSegments++;
          ZoomIn = true;
          break;
        }
        default:
        {
          return;
        }
      }
      if (ColSegments == 0) ColSegments = 1;
      BuildColorList();
      UpdateCanvas(XY, ZoomIn);
    }
    void UpdateCanvas(XY NewCenter,bool ZoomIn)
    {
      decimal ZF=ZoomIn?ZoomFactor:1/ZoomFactor;

      decimal NewHalfWidth = (MaxX - MinX) * ZF / 2;
      decimal NewHalfHeight =(MaxY - MinY) * ZF / 2;

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
      ImgWidth = (ushort) PB.Width;
      ImgHeight = (ushort) PB.Height;
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

      decimal x0=Coord.X;
      decimal y0=Coord.Y;

      decimal x = 0;
      decimal y = 0;

      while (x * x + y * y <= 2 * 2 && NumIters < MaxIters)
      {
        decimal xtemp = x * x - y * y + x0;
        y = 2 * x * y + y0;
        x = xtemp;
        NumIters++;
      }


      return NumIters;
    }

    XY[,] UpdateCoord()
    {
      XY[,] NewCoord = new XY[ImgWidth, ImgHeight];

      for (int i = 0; i < ImgWidth; i++)
      {
        for (int j = 0; j < ImgHeight; j++)
        {
          decimal x = MinX + (decimal) i * (MaxX - MinX) / ImgWidth;
          decimal y = MaxY - (decimal) j * (MaxY - MinY) / ImgHeight;
          NewCoord[i, j] = new XY(x,y);
        }
      }

      return NewCoord;
    }

    void BuildColorList()
    {
      Colors = new List<int[]>();
      int Max=255;
      

      for (int i = 0; i < ColSegments; i++)
      {
        for (int j = 0; j < ColSegments; j++)
        {
          for (int k = 0; k < ColSegments; k++)
          {
            int r = i * Convert.ToInt16((double)Max / (double)ColSegments);
            int g;
            int b;
            if (Grayscale)
            {
              g = r;
              b = r;
            }
            else
            {
              g = j * Convert.ToInt16((double)Max / (double)ColSegments);
              b = k * Convert.ToInt16((double)Max / (double)ColSegments);
            }
            

            Colors.Add(new int[3] { r, g, b });
          }
        }
      }
      MaxIter = Colors.Count();
    }
  }
}
