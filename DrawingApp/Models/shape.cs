using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Models
{
    public abstract class Shape
    {


        public Shape() { }

        public Color StrokeColor { get; set; } = Color.Black;
        public float StrokeWidth { get; set; } = 2f;

        public virtual void draw(Graphics g) { }
    }
}
