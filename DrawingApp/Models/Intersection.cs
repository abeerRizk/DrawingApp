using DrawingApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;

public static class Intersection
{
    public static List<PointF> FindIntersections(Shape a, Shape b)
    {
        if (a is line lineA && b is line lineB)
            return LineLineIntersection(lineA, lineB);

        if (a is line line1 && b is rectangle rect1)
            return LineRectIntersection(line1, rect1);

        if (a is rectangle rect2 && b is line line2)
            return LineRectIntersection(line2, rect2);

        if (a is line line3 && b is circle circle1)
            return LineCircleIntersection(line3, circle1);

        if (a is circle circle2 && b is line line4)
            return LineCircleIntersection(line4, circle2);

        if (a is rectangle rectA && b is rectangle rectB)
            return RectRectIntersection(rectA, rectB);

        if (a is rectangle rect3 && b is circle circle3)
            return RectCircleIntersection(rect3, circle3);
        if (a is circle circle4 && b is rectangle rect4)
            return RectCircleIntersection(rect4, circle4);

        if (a is circle circleA && b is circle circleB)
            return CircleCircleIntersection(circleA, circleB);

        return new List<PointF>();
    }

    private static List<PointF> LineLineIntersection(line a, line b)
    {
        var result = new List<PointF>();
        var point = SegmentIntersection(
            a.StartPoint, a.EndPoint,
            b.StartPoint, b.EndPoint);

        if (point.HasValue)
            result.Add(point.Value);

        return result;
    }

    private static List<PointF> LineRectIntersection(line line, rectangle rect)
    {
        var result = new List<PointF>();
        var corners = rect.GetCorners();

        for (int i = 0; i < 4; i++)
        {
            var edgeStart = corners[i];
            var edgeEnd = corners[(i + 1) % 4];

            var point = SegmentIntersection(
                line.StartPoint, line.EndPoint,
                edgeStart, edgeEnd);

            if (point.HasValue)
                result.Add(point.Value);
        }

        return result;
    }

    private static List<PointF> LineCircleIntersection(line line, circle circle)
    {
        return SegmentCircleIntersection(
            line.StartPoint, line.EndPoint,
            circle.Center, circle.Radius);
    }

    private static List<PointF> RectRectIntersection(rectangle a, rectangle b)
    {
        var result = new List<PointF>();
        var cornersA = a.GetCorners();
        var cornersB = b.GetCorners();

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                var point = SegmentIntersection(
                    cornersA[i], cornersA[(i + 1) % 4],
                    cornersB[j], cornersB[(j + 1) % 4]);

                if (point.HasValue)
                    result.Add(point.Value);
            }
        }

        return result;
    }

    private static List<PointF> RectCircleIntersection(rectangle rect, circle circle)
    {
        var result = new List<PointF>();
        var corners = rect.GetCorners();

        for (int i = 0; i < 4; i++)
        {
            var points = SegmentCircleIntersection(
                corners[i], corners[(i + 1) % 4],
                circle.Center, circle.Radius);

            result.AddRange(points);
        }

        return result;
    }

    private static List<PointF> CircleCircleIntersection(circle a, circle b)
    {
        var result = new List<PointF>();

        float dx = b.Center.X - a.Center.X;
        float dy = b.Center.Y - a.Center.Y;
        float dist = (float)Math.Sqrt(dx * dx + dy * dy);

        if (dist > a.Radius + b.Radius) return result;      
        if (dist < Math.Abs(a.Radius - b.Radius)) return result; 
        if (dist < 0.001f) return result;                  

        float aa = (a.Radius * a.Radius - b.Radius * b.Radius + dist * dist) / (2 * dist);
        float h = (float)Math.Sqrt(a.Radius * a.Radius - aa * aa);

        float mx = a.Center.X + aa * dx / dist;
        float my = a.Center.Y + aa * dy / dist;

        result.Add(new PointF(mx + h * dy / dist, my - h * dx / dist));
        result.Add(new PointF(mx - h * dy / dist, my + h * dx / dist));

        return result;
    }

    private static PointF? SegmentIntersection(PointF p1, PointF p2, PointF p3, PointF p4)
    {
        float d1x = p2.X - p1.X;
        float d1y = p2.Y - p1.Y;
        float d2x = p4.X - p3.X;
        float d2y = p4.Y - p3.Y;

        float cross = d1x * d2y - d1y * d2x;
        if (Math.Abs(cross) < 0.0001f) return null; 

        float t = ((p3.X - p1.X) * d2y - (p3.Y - p1.Y) * d2x) / cross;
        float u = ((p3.X - p1.X) * d1y - (p3.Y - p1.Y) * d1x) / cross;

        if (t >= 0 && t <= 1 && u >= 0 && u <= 1)
        {
            return new PointF(
                p1.X + t * d1x,
                p1.Y + t * d1y);
        }

        return null;
    }

    private static List<PointF> SegmentCircleIntersection(
        PointF p1, PointF p2, PointF center, float radius)
    {
        var result = new List<PointF>();

        float dx = p2.X - p1.X;
        float dy = p2.Y - p1.Y;
        float fx = p1.X - center.X;
        float fy = p1.Y - center.Y;

        float a = dx * dx + dy * dy;
        float b = 2 * (fx * dx + fy * dy);
        float c = fx * fx + fy * fy - radius * radius;

        float discriminant = b * b - 4 * a * c;
        if (discriminant < 0) return result;

        discriminant = (float)Math.Sqrt(discriminant);

        float t1 = (-b - discriminant) / (2 * a);
        float t2 = (-b + discriminant) / (2 * a);

        if (t1 >= 0 && t1 <= 1)
            result.Add(new PointF(p1.X + t1 * dx, p1.Y + t1 * dy));

        if (t2 >= 0 && t2 <= 1 && Math.Abs(t2 - t1) > 0.001f)
            result.Add(new PointF(p1.X + t2 * dx, p1.Y + t2 * dy));

        return result;
    }
}