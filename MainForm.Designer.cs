namespace ShapeDetection
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CaptureBtn = new System.Windows.Forms.Button();
            this.MaxValText = new System.Windows.Forms.TextBox();
            this.MinValText = new System.Windows.Forms.TextBox();
            this.MaxSatText = new System.Windows.Forms.TextBox();
            this.MinSatText = new System.Windows.Forms.TextBox();
            this.MaxHueText = new System.Windows.Forms.TextBox();
            this.MinHueText = new System.Windows.Forms.TextBox();
            this.MaxValTB = new System.Windows.Forms.TrackBar();
            this.MinValTB = new System.Windows.Forms.TrackBar();
            this.MaxSatTB = new System.Windows.Forms.TrackBar();
            this.MinSatTB = new System.Windows.Forms.TrackBar();
            this.MaxHueTB = new System.Windows.Forms.TrackBar();
            this.MinHueTB = new System.Windows.Forms.TrackBar();
            this.fileNameTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.loadImageButton = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.originalImageBox = new Emgu.CV.UI.ImageBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.circleImageBox = new Emgu.CV.UI.ImageBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.triangleRectangleImageBox = new Emgu.CV.UI.ImageBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lineImageBox = new Emgu.CV.UI.ImageBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxValTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinValTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSatTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSatTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHueTB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinHueTB)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circleImageBox)).BeginInit();
            this.panel4.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.triangleRectangleImageBox)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineImageBox)).BeginInit();
            this.panel5.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CaptureBtn);
            this.panel1.Controls.Add(this.MaxValText);
            this.panel1.Controls.Add(this.MinValText);
            this.panel1.Controls.Add(this.MaxSatText);
            this.panel1.Controls.Add(this.MinSatText);
            this.panel1.Controls.Add(this.MaxHueText);
            this.panel1.Controls.Add(this.MinHueText);
            this.panel1.Controls.Add(this.MaxValTB);
            this.panel1.Controls.Add(this.MinValTB);
            this.panel1.Controls.Add(this.MaxSatTB);
            this.panel1.Controls.Add(this.MinSatTB);
            this.panel1.Controls.Add(this.MaxHueTB);
            this.panel1.Controls.Add(this.MinHueTB);
            this.panel1.Controls.Add(this.fileNameTextBox);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.loadImageButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1494, 65);
            this.panel1.TabIndex = 0;
            // 
            // CaptureBtn
            // 
            this.CaptureBtn.Location = new System.Drawing.Point(40, 32);
            this.CaptureBtn.Name = "CaptureBtn";
            this.CaptureBtn.Size = new System.Drawing.Size(75, 23);
            this.CaptureBtn.TabIndex = 22;
            this.CaptureBtn.Text = "Video";
            this.CaptureBtn.UseVisualStyleBackColor = true;
            this.CaptureBtn.Click += new System.EventHandler(this.CaptureBtn_Click);
            // 
            // MaxValText
            // 
            this.MaxValText.Location = new System.Drawing.Point(1319, 32);
            this.MaxValText.Name = "MaxValText";
            this.MaxValText.Size = new System.Drawing.Size(47, 22);
            this.MaxValText.TabIndex = 21;
            // 
            // MinValText
            // 
            this.MinValText.Location = new System.Drawing.Point(1320, 6);
            this.MinValText.Name = "MinValText";
            this.MinValText.Size = new System.Drawing.Size(46, 22);
            this.MinValText.TabIndex = 20;
            // 
            // MaxSatText
            // 
            this.MaxSatText.Location = new System.Drawing.Point(912, 38);
            this.MaxSatText.Name = "MaxSatText";
            this.MaxSatText.Size = new System.Drawing.Size(47, 22);
            this.MaxSatText.TabIndex = 19;
            // 
            // MinSatText
            // 
            this.MinSatText.Location = new System.Drawing.Point(913, 6);
            this.MinSatText.Name = "MinSatText";
            this.MinSatText.Size = new System.Drawing.Size(46, 22);
            this.MinSatText.TabIndex = 18;
            // 
            // MaxHueText
            // 
            this.MaxHueText.Location = new System.Drawing.Point(495, 37);
            this.MaxHueText.Name = "MaxHueText";
            this.MaxHueText.Size = new System.Drawing.Size(47, 22);
            this.MaxHueText.TabIndex = 16;
            // 
            // MinHueText
            // 
            this.MinHueText.Location = new System.Drawing.Point(496, 6);
            this.MinHueText.Name = "MinHueText";
            this.MinHueText.Size = new System.Drawing.Size(46, 22);
            this.MinHueText.TabIndex = 9;
            // 
            // MaxValTB
            // 
            this.MaxValTB.Location = new System.Drawing.Point(1035, 37);
            this.MaxValTB.Maximum = 255;
            this.MaxValTB.Name = "MaxValTB";
            this.MaxValTB.Size = new System.Drawing.Size(259, 56);
            this.MaxValTB.TabIndex = 8;
            this.MaxValTB.Scroll += new System.EventHandler(this.MaxValTB_Scroll);
            // 
            // MinValTB
            // 
            this.MinValTB.Location = new System.Drawing.Point(1035, 3);
            this.MinValTB.Maximum = 255;
            this.MinValTB.Name = "MinValTB";
            this.MinValTB.Size = new System.Drawing.Size(259, 56);
            this.MinValTB.TabIndex = 7;
            this.MinValTB.Scroll += new System.EventHandler(this.MinValTB_Scroll);
            // 
            // MaxSatTB
            // 
            this.MaxSatTB.Location = new System.Drawing.Point(612, 37);
            this.MaxSatTB.Maximum = 255;
            this.MaxSatTB.Name = "MaxSatTB";
            this.MaxSatTB.Size = new System.Drawing.Size(295, 56);
            this.MaxSatTB.TabIndex = 6;
            this.MaxSatTB.Scroll += new System.EventHandler(this.MaxSatTB_Scroll);
            // 
            // MinSatTB
            // 
            this.MinSatTB.Location = new System.Drawing.Point(612, 6);
            this.MinSatTB.Maximum = 255;
            this.MinSatTB.Name = "MinSatTB";
            this.MinSatTB.Size = new System.Drawing.Size(295, 56);
            this.MinSatTB.TabIndex = 5;
            this.MinSatTB.Scroll += new System.EventHandler(this.MinSatTB_Scroll);
            // 
            // MaxHueTB
            // 
            this.MaxHueTB.Location = new System.Drawing.Point(224, 32);
            this.MaxHueTB.Maximum = 360;
            this.MaxHueTB.Name = "MaxHueTB";
            this.MaxHueTB.Size = new System.Drawing.Size(255, 56);
            this.MaxHueTB.TabIndex = 4;
            this.MaxHueTB.Scroll += new System.EventHandler(this.MaxHueTB_Scroll);
            // 
            // MinHueTB
            // 
            this.MinHueTB.Location = new System.Drawing.Point(224, 2);
            this.MinHueTB.Maximum = 360;
            this.MinHueTB.Name = "MinHueTB";
            this.MinHueTB.Size = new System.Drawing.Size(255, 56);
            this.MinHueTB.TabIndex = 3;
            this.MinHueTB.Scroll += new System.EventHandler(this.MinHueTB_Scroll);
            // 
            // fileNameTextBox
            // 
            this.fileNameTextBox.Location = new System.Drawing.Point(74, 2);
            this.fileNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.fileNameTextBox.Name = "fileNameTextBox";
            this.fileNameTextBox.ReadOnly = true;
            this.fileNameTextBox.Size = new System.Drawing.Size(104, 22);
            this.fileNameTextBox.TabIndex = 2;
            this.fileNameTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            //
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 2);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "File:";
            // 
            // loadImageButton
            // 
            this.loadImageButton.Location = new System.Drawing.Point(186, 4);
            this.loadImageButton.Margin = new System.Windows.Forms.Padding(4);
            this.loadImageButton.Name = "loadImageButton";
            this.loadImageButton.Size = new System.Drawing.Size(40, 28);
            this.loadImageButton.TabIndex = 0;
            this.loadImageButton.Text = "...";
            this.loadImageButton.UseVisualStyleBackColor = true;
            this.loadImageButton.Click += new System.EventHandler(this.loadImageButton_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 65);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(1494, 980);
            this.splitContainer1.SplitterDistance = 734;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 1;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.originalImageBox);
            this.splitContainer2.Panel1.Controls.Add(this.panel2);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.circleImageBox);
            this.splitContainer2.Panel2.Controls.Add(this.panel4);
            this.splitContainer2.Size = new System.Drawing.Size(734, 980);
            this.splitContainer2.SplitterDistance = 501;
            this.splitContainer2.SplitterWidth = 5;
            this.splitContainer2.TabIndex = 0;
            // 
            // originalImageBox
            // 
            this.originalImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.originalImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.originalImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.originalImageBox.Location = new System.Drawing.Point(0, 31);
            this.originalImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.originalImageBox.Name = "originalImageBox";
            this.originalImageBox.Size = new System.Drawing.Size(734, 470);
            this.originalImageBox.TabIndex = 3;
            this.originalImageBox.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(734, 31);
            this.panel2.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 6);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Original Image";
            // 
            // circleImageBox
            // 
            this.circleImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.circleImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.circleImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.circleImageBox.Location = new System.Drawing.Point(0, 31);
            this.circleImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.circleImageBox.Name = "circleImageBox";
            this.circleImageBox.Size = new System.Drawing.Size(734, 443);
            this.circleImageBox.TabIndex = 4;
            this.circleImageBox.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.label3);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(734, 31);
            this.panel4.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 6);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(111, 17);
            this.label3.TabIndex = 0;
            this.label3.Text = "Detected Circles";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Margin = new System.Windows.Forms.Padding(4);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.triangleRectangleImageBox);
            this.splitContainer3.Panel1.Controls.Add(this.panel3);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.lineImageBox);
            this.splitContainer3.Panel2.Controls.Add(this.panel5);
            this.splitContainer3.Size = new System.Drawing.Size(755, 980);
            this.splitContainer3.SplitterDistance = 501;
            this.splitContainer3.SplitterWidth = 5;
            this.splitContainer3.TabIndex = 0;
            // 
            // triangleRectangleImageBox
            // 
            this.triangleRectangleImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.triangleRectangleImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.triangleRectangleImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.triangleRectangleImageBox.Location = new System.Drawing.Point(0, 31);
            this.triangleRectangleImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.triangleRectangleImageBox.Name = "triangleRectangleImageBox";
            this.triangleRectangleImageBox.Size = new System.Drawing.Size(755, 470);
            this.triangleRectangleImageBox.TabIndex = 4;
            this.triangleRectangleImageBox.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.label2);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel3.Location = new System.Drawing.Point(0, 0);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(755, 31);
            this.panel3.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 6);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(235, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Detected Triangles and  Rectangles";
            // 
            // lineImageBox
            // 
            this.lineImageBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lineImageBox.Cursor = System.Windows.Forms.Cursors.Cross;
            this.lineImageBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineImageBox.Location = new System.Drawing.Point(0, 31);
            this.lineImageBox.Margin = new System.Windows.Forms.Padding(4);
            this.lineImageBox.Name = "lineImageBox";
            this.lineImageBox.Size = new System.Drawing.Size(755, 443);
            this.lineImageBox.TabIndex = 4;
            this.lineImageBox.TabStop = false;
            // 
            // panel5
            // 
            this.panel5.Controls.Add(this.label4);
            this.panel5.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel5.Location = new System.Drawing.Point(0, 0);
            this.panel5.Margin = new System.Windows.Forms.Padding(4);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(755, 31);
            this.panel5.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(21, 6);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(103, 17);
            this.label4.TabIndex = 0;
            this.label4.Text = "Detected Lines";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1494, 1045);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "MainForm";
            this.Text = "Shape Detection";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MaxValTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinValTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxSatTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinSatTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaxHueTB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MinHueTB)).EndInit();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.originalImageBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.circleImageBox)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.triangleRectangleImageBox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.lineImageBox)).EndInit();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Label label4;
        private Emgu.CV.UI.ImageBox originalImageBox;
        private Emgu.CV.UI.ImageBox circleImageBox;
        private Emgu.CV.UI.ImageBox triangleRectangleImageBox;
        private Emgu.CV.UI.ImageBox lineImageBox;
        private System.Windows.Forms.TextBox fileNameTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button loadImageButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox MaxValText;
        private System.Windows.Forms.TextBox MinValText;
        private System.Windows.Forms.TextBox MaxSatText;
        private System.Windows.Forms.TextBox MinSatText;
        private System.Windows.Forms.TextBox MaxHueText;
        private System.Windows.Forms.TextBox MinHueText;
        private System.Windows.Forms.TrackBar MaxValTB;
        private System.Windows.Forms.TrackBar MinValTB;
        private System.Windows.Forms.TrackBar MaxSatTB;
        private System.Windows.Forms.TrackBar MinSatTB;
        private System.Windows.Forms.TrackBar MaxHueTB;
        private System.Windows.Forms.TrackBar MinHueTB;
        private System.Windows.Forms.Button CaptureBtn;

    }
}

