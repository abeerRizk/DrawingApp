using DrawingApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DrawingApp
{

    public partial class MainForm : Form
    {
        private Panel header;
        private CheckBox lineCheck;
        private Panel footer;
        private Button ClearButton;
        private CheckBox RectCheck;
        private CheckBox CircleCheck;
        private Button saveButton;
        private DrawingCanvas drawingCanvas1;
        private DrawingCanvas _canvas;

        public MainForm()
        {
            InitializeComponent();
            _canvas = new DrawingCanvas();
            _canvas.Dock = DockStyle.Fill;

            this.Controls.Add(_canvas);
            _canvas.BringToFront();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }



        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {

        }

        private void drawingCanavas1_Load(object sender, EventArgs e)
        {

        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.header = new System.Windows.Forms.Panel();
            this.CircleCheck = new System.Windows.Forms.CheckBox();
            this.RectCheck = new System.Windows.Forms.CheckBox();
            this.lineCheck = new System.Windows.Forms.CheckBox();
            this.footer = new System.Windows.Forms.Panel();
            this.ClearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.drawingCanvas1 = new DrawingCanvas();
            this.header.SuspendLayout();
            this.footer.SuspendLayout();
            this.SuspendLayout();
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.HotTrack;
            this.header.Controls.Add(this.CircleCheck);
            this.header.Controls.Add(this.RectCheck);
            this.header.Controls.Add(this.lineCheck);
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Location = new System.Drawing.Point(0, 0);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(1117, 60);
            this.header.TabIndex = 0;
            // 
            // CircleCheck
            // 
            this.CircleCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.CircleCheck.AutoSize = true;
            this.CircleCheck.Image = ((System.Drawing.Image)(resources.GetObject("CircleCheck.Image")));
            this.CircleCheck.Location = new System.Drawing.Point(203, 4);
            this.CircleCheck.Name = "CircleCheck";
            this.CircleCheck.Size = new System.Drawing.Size(56, 56);
            this.CircleCheck.TabIndex = 4;
            this.CircleCheck.UseVisualStyleBackColor = true;
            this.CircleCheck.CheckedChanged += new System.EventHandler(this.CircleCheck_CheckedChanged);
            // 
            // RectCheck
            // 
            this.RectCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.RectCheck.AutoSize = true;
            this.RectCheck.Image = ((System.Drawing.Image)(resources.GetObject("RectCheck.Image")));
            this.RectCheck.Location = new System.Drawing.Point(121, 4);
            this.RectCheck.Name = "RectCheck";
            this.RectCheck.Size = new System.Drawing.Size(56, 56);
            this.RectCheck.TabIndex = 3;
            this.RectCheck.UseVisualStyleBackColor = true;
            this.RectCheck.CheckedChanged += new System.EventHandler(this.RectCheck_CheckedChanged);
            // 
            // lineCheck
            // 
            this.lineCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineCheck.AutoSize = true;
            this.lineCheck.Image = ((System.Drawing.Image)(resources.GetObject("lineCheck.Image")));
            this.lineCheck.Location = new System.Drawing.Point(40, 3);
            this.lineCheck.Name = "lineCheck";
            this.lineCheck.Size = new System.Drawing.Size(56, 56);
            this.lineCheck.TabIndex = 2;
            this.lineCheck.UseVisualStyleBackColor = true;
            this.lineCheck.CheckedChanged += new System.EventHandler(this.lineCheck_CheckedChanged);
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.SystemColors.HotTrack;
            this.footer.Controls.Add(this.ClearButton);
            this.footer.Controls.Add(this.saveButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 431);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(1117, 60);
            this.footer.TabIndex = 1;
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(968, 17);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(105, 31);
            this.ClearButton.TabIndex = 1;
            this.ClearButton.Text = "Clear";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(840, 17);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(105, 31);
            this.saveButton.TabIndex = 0;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // drawingCanvas1
            // 
            this.drawingCanvas1.ActiveTool = DrawingApp.Models.DrawingTool.Select;
            this.drawingCanvas1.BackColor = System.Drawing.Color.White;
            this.drawingCanvas1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.drawingCanvas1.GridSize = 50;
            this.drawingCanvas1.Location = new System.Drawing.Point(0, 60);
            this.drawingCanvas1.Name = "drawingCanvas1";
            this.drawingCanvas1.ShowGrid = true;
            this.drawingCanvas1.Size = new System.Drawing.Size(1117, 371);
            this.drawingCanvas1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1117, 491);
            this.Controls.Add(this.drawingCanvas1);
            this.Controls.Add(this.footer);
            this.Controls.Add(this.header);
            this.Name = "MainForm";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.header.ResumeLayout(false);
            this.header.PerformLayout();
            this.footer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }




        private void lineCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (lineCheck.Checked)
            {
                RectCheck.Checked = false;
                CircleCheck.Checked = false;
                _canvas.ActiveTool = DrawingTool.Line;
            }
        }

        private void RectCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (RectCheck.Checked)
            {
                lineCheck.Checked = false;
                CircleCheck.Checked = false;
                _canvas.ActiveTool = DrawingTool.Rectangle;
            }
        }

        private void CircleCheck_CheckedChanged(object sender, EventArgs e)
        {
            if (CircleCheck.Checked)
            {
                lineCheck.Checked = false;
                RectCheck.Checked = false;
                _canvas.ActiveTool = DrawingTool.Circle;
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                dialog.Title = "Save Drawing";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _canvas.SaveAsImage(dialog.FileName);
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog dialog = new SaveFileDialog())
            {
                dialog.Filter = "PNG Image|*.png|JPEG Image|*.jpg";
                dialog.Title = "Save Drawing";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    _canvas.SaveAsImage(dialog.FileName);
                }
            }
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            var currentTool = _canvas.ActiveTool;
            _canvas = new DrawingCanvas();
            _canvas.Dock = DockStyle.Fill;
            _canvas.ActiveTool = currentTool;
            this.Controls.Add(_canvas);
            _canvas.BringToFront();
        }
    }
}