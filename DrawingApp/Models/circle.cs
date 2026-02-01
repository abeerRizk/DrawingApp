using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Models
{
    public class circle : Shape
    {
        public circle() { }

        public PointF Center { get; set; }
        public float Radius { get; set; }

        public override void draw(Graphics g)
        {
            using (var pen = new Pen(StrokeColor, StrokeWidth))
            {
                g.DrawEllipse(pen,
                    Center.X - Radius,
                    Center.Y - Radius,
                    Radius * 2,
                    Radius * 2);
            }
        }
    }
}
