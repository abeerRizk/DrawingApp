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
        private Button CancelButton;
        private CheckBox RectCheck;
        private CheckBox CircleCheck;
        private Button saveButton;
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
            this.header = new System.Windows.Forms.Panel();
            this.CircleCheck = new System.Windows.Forms.CheckBox();
            this.RectCheck = new System.Windows.Forms.CheckBox();
            this.lineCheck = new System.Windows.Forms.CheckBox();
            this.footer = new System.Windows.Forms.Panel();
            this.CancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
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
            this.CircleCheck.Location = new System.Drawing.Point(245, 12);
            this.CircleCheck.Name = "CircleCheck";
            this.CircleCheck.Size = new System.Drawing.Size(58, 30);
            this.CircleCheck.TabIndex = 4;
            this.CircleCheck.Text = "Circle";
            this.CircleCheck.UseVisualStyleBackColor = true;
            this.CircleCheck.CheckedChanged += new System.EventHandler(this.CircleCheck_CheckedChanged);
            // 
            // RectCheck
            // 
            this.RectCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.RectCheck.AutoSize = true;
            this.RectCheck.Location = new System.Drawing.Point(124, 12);
            this.RectCheck.Name = "RectCheck";
            this.RectCheck.Size = new System.Drawing.Size(92, 30);
            this.RectCheck.TabIndex = 3;
            this.RectCheck.Text = "Rectangle";
            this.RectCheck.UseVisualStyleBackColor = true;
            this.RectCheck.CheckedChanged += new System.EventHandler(this.RectCheck_CheckedChanged);
            // 
            // lineCheck
            // 
            this.lineCheck.Appearance = System.Windows.Forms.Appearance.Button;
            this.lineCheck.AutoSize = true;
            this.lineCheck.Location = new System.Drawing.Point(27, 12);
            this.lineCheck.Name = "lineCheck";
            this.lineCheck.Size = new System.Drawing.Size(49, 30);
            this.lineCheck.TabIndex = 2;
            this.lineCheck.Text = "Line";
            this.lineCheck.UseVisualStyleBackColor = true;
            this.lineCheck.CheckedChanged += new System.EventHandler(this.lineCheck_CheckedChanged);
            // 
            // footer
            // 
            this.footer.BackColor = System.Drawing.SystemColors.HotTrack;
            this.footer.Controls.Add(this.CancelButton);
            this.footer.Controls.Add(this.saveButton);
            this.footer.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.footer.Location = new System.Drawing.Point(0, 431);
            this.footer.Name = "footer";
            this.footer.Size = new System.Drawing.Size(1117, 60);
            this.footer.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(968, 17);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(105, 31);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
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
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1117, 491);
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
    }
}
