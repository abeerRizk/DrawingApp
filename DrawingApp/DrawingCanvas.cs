using DrawingApp.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

public class DrawingCanvas : UserControl
{
    private List<Shape> _shapes = new List<Shape>();
    private List<Shape> undo_shapes = new List<Shape>();

    private Shape _previewShape;
    private bool _isDrawing;
    private PointF _startPoint;

    public DrawingTool ActiveTool { get; set; }

    public int GridSize { get; set; } = 50;
    public bool ShowGrid { get; set; } = true;



    public DrawingCanvas()
    {
        this.DoubleBuffered = true;
        this.BackColor = Color.White;
    }


    protected override void OnMouseDown(MouseEventArgs e)
    {
        if (e.Button != MouseButtons.Left) return;

        _isDrawing = true;
        _startPoint = e.Location;

        switch (ActiveTool)
        {
            case DrawingTool.Line:
                _previewShape = new line
                {
                    StartPoint = _startPoint,
                    EndPoint = _startPoint
                };
                break;

            case DrawingTool.Rectangle:
                _previewShape = new rectangle
                {
                    StartPoint = _startPoint,
                    EndPoint = _startPoint
                };
                break;

            case DrawingTool.Circle:
                _previewShape = new circle
                {
                    Center = _startPoint,
                    Radius = 0
                };
                break;
        }
    }

    protected override void OnMouseMove(MouseEventArgs e)
    {
        if (!_isDrawing || _previewShape == null) return;

        if (_previewShape is line line)
        {
            line.EndPoint = e.Location;
        }
        else if (_previewShape is rectangle rect)
        {
            rect.EndPoint = e.Location;
        }
        else if (_previewShape is circle circle)
        {
            float dx = e.X - circle.Center.X;
            float dy = e.Y - circle.Center.Y;
            circle.Radius = (float)Math.Sqrt(dx * dx + dy * dy);
        }

        Invalidate();
    }

    protected override void OnMouseUp(MouseEventArgs e)
    {
        if (!_isDrawing || _previewShape == null) return;

        _shapes.Add(_previewShape);
        _previewShape = null;
        _isDrawing = false;
        Invalidate();
    }

    private void DrawGrid(Graphics g)
    {
        if (!ShowGrid) return;

        using (var pen = new Pen(Color.LightGray, 0.5f))
        {
            for (int x = 0; x < this.Width; x += GridSize)
            {
                g.DrawLine(pen, x, 0, x, this.Height);
            }

            for (int y = 0; y < this.Height; y += GridSize)
            {
                g.DrawLine(pen, 0, y, this.Width, y);
            }
        }
    }
    protected override void OnPaint(PaintEventArgs e)
    {

        Graphics g = e.Graphics;


        DrawGrid(g);
        foreach (var shape in _shapes)
        {
            shape.draw(g);
        }

        if (_previewShape != null)
        {
            _previewShape.draw(g);
        }
        DrawIntersections(g);
    }

    private void DrawIntersections(Graphics g)
    {
        float dotSize = 8f;

        using (var brush = new SolidBrush(Color.Red))
        {
            for (int i = 0; i < _shapes.Count; i++)
            {
                for (int j = i + 1; j < _shapes.Count; j++)
                {
                    var points = Intersection.FindIntersections(
                        _shapes[i], _shapes[j]);

                    foreach (var point in points)
                    {
                        g.FillEllipse(brush,
                            point.X - dotSize / 2,
                            point.Y - dotSize / 2,
                            dotSize, dotSize);
                    }
                }
            }
        }
    }

    public void SaveAsImage(string filePath)
    {
        using (Bitmap bitmap = new Bitmap(this.Width, this.Height))
        {
            this.DrawToBitmap(bitmap, new Rectangle(0, 0, this.Width, this.Height));
            bitmap.Save(filePath);
        }
    }

    public void clearShapes()
    {

        this._shapes.Clear();
        this.undo_shapes.Clear();
    }
    public void UndoChanges() {
        if (this._shapes.Count > 0 )
        {
            this.undo_shapes.Add(this._shapes[this._shapes.Count - 1]);
            this._shapes.Remove(this._shapes[this._shapes.Count - 1]);
          
        }
        Invalidate();

    }
    public void RedoChanges()
    {
        if (this.undo_shapes.Count > 0)
        {
            this._shapes.Add(this.undo_shapes[this.undo_shapes.Count - 1]);
            this.undo_shapes.Remove(this.undo_shapes[this.undo_shapes.Count - 1]);
            Invalidate();
        }
    }
    private void DrawingCanvas_Load(object sender, EventArgs e)
    {

    }


    private void DrawingCanvas_Load_1(object sender, EventArgs e)
    {

    }

    private void InitializeComponent()
    {
        this.SuspendLayout();
        // 
        // DrawingCanvas
        // 
        this.Name = "DrawingCanvas";
        this.Load += new System.EventHandler(this.DrawingCanvas_Load_2);
        this.ResumeLayout(false);

    }

    private void DrawingCanvas_Load_2(object sender, EventArgs e)
    {

    }
}