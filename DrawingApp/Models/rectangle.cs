using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DrawingApp.Models
{
    public  class rectangle : Shape
    {
        public PointF StartPoint { get; set; }
        public PointF EndPoint { get; set; }

        public rectangle() { 
        }

        public override void draw(Graphics g)
        {
            using (var pen = new Pen(StrokeColor, StrokeWidth))
            {
                float x = Math.Min(StartPoint.X, EndPoint.X);
                float y = Math.Min(StartPoint.Y, EndPoint.Y);
                float w = Math.Abs(EndPoint.X - StartPoint.X);
                float h = Math.Abs(EndPoint.Y - StartPoint.Y);

                g.DrawRectangle(pen, x, y, w, h);
            }
        }

        public PointF[] GetCorners()
        {
            float x1 = Math.Min(StartPoint.X, EndPoint.X);
            float y1 = Math.Min(StartPoint.Y, EndPoint.Y);
            float x2 = Math.Max(StartPoint.X, EndPoint.X);
            float y2 = Math.Max(StartPoint.Y, EndPoint.Y);

            return new PointF[]
            {
                new PointF(x1, y1), 
                new PointF(x2, y1),  
                new PointF(x2, y2),  
                new PointF(x1, y2)  
            };
        }
    }
}
