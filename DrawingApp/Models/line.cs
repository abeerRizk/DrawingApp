using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Models
{
    public class line : Shape
    {
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }

        public line() { }

        public override void draw(Graphics g)
        {
            using (var pen = new Pen(StrokeColor, StrokeWidth))
            {
                g.DrawLine(pen, StartPoint, EndPoint);
            }
        }
    }
}
