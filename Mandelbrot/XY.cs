using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
  public class XY
  {
    public double X { get; set; }
    public double Y { get; set; }

    public XY(double ix, double iy)
    {
      X = ix;
      Y = iy;
    }
  }
}
