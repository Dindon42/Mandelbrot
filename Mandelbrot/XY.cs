using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandelbrot
{
  public class XY
  {
    public decimal X { get; set; }
    public decimal Y { get; set; }

    public XY(decimal ix, decimal iy)
    {
      X = ix;
      Y = iy;
    }
  }
}
