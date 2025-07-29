namespace DesktopClock_V2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            timetxt = new Label();
            uptime = new System.Windows.Forms.Timer(components);
            datetxt = new Label();
            contextMenuStrip1 = new ContextMenuStrip(components);
            壁紙変更CToolStripMenuItem = new ToolStripMenuItem();
            ChangeWP_crop = new ToolStripMenuItem();
            ChangeLangsw = new ToolStripMenuItem();
            ChangeJ = new ToolStripMenuItem();
            ChangeE = new ToolStripMenuItem();
            toolStripMenuItem1 = new ToolStripSeparator();
            Strip_Close = new ToolStripMenuItem();
            testToolStripMenuItem = new ToolStripMenuItem();
            toggleIka004modeToolStripMenuItem = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            dev1 = new Label();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timetxt
            // 
            timetxt.BackColor = Color.Transparent;
            timetxt.Font = new Font("Yu Gothic UI Semilight", 45F, FontStyle.Regular, GraphicsUnit.Point);
            timetxt.ForeColor = SystemColors.ControlLightLight;
            timetxt.Location = new Point(2, 351);
            timetxt.Name = "timetxt";
            timetxt.Size = new Size(273, 129);
            timetxt.TabIndex = 0;
            timetxt.Text = "00:40";
            // 
            // uptime
            // 
            uptime.Enabled = true;
            uptime.Interval = 1000;
            uptime.Tick += uptime_Tick;
            // 
            // datetxt
            // 
            datetxt.AutoSize = true;
            datetxt.BackColor = Color.Transparent;
            datetxt.Font = new Font("Yu Gothic UI Semilight", 20F, FontStyle.Regular, GraphicsUnit.Point);
            datetxt.ForeColor = SystemColors.ControlLightLight;
            datetxt.Location = new Point(12, 420);
            datetxt.Name = "datetxt";
            datetxt.Size = new Size(138, 37);
            datetxt.TabIndex = 1;
            datetxt.Text = "1月2日(木)";
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 壁紙変更CToolStripMenuItem, ChangeWP_crop, ChangeLangsw, toolStripMenuItem1, Strip_Close, testToolStripMenuItem, toggleIka004modeToolStripMenuItem });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(201, 142);
            // 
            // 壁紙変更CToolStripMenuItem
            // 
            壁紙変更CToolStripMenuItem.Name = "壁紙変更CToolStripMenuItem";
            壁紙変更CToolStripMenuItem.Size = new Size(200, 22);
            壁紙変更CToolStripMenuItem.Text = "壁紙変更(クロップなし)(&N)";
            壁紙変更CToolStripMenuItem.Visible = false;
            壁紙変更CToolStripMenuItem.Click += 壁紙変更CToolStripMenuItem_Click;
            // 
            // ChangeWP_crop
            // 
            ChangeWP_crop.Name = "ChangeWP_crop";
            ChangeWP_crop.Size = new Size(200, 22);
            ChangeWP_crop.Text = "壁紙変更(&C)";
            ChangeWP_crop.Click += ChangeWP_crop_Click;
            // 
            // ChangeLangsw
            // 
            ChangeLangsw.DropDownItems.AddRange(new ToolStripItem[] { ChangeJ, ChangeE });
            ChangeLangsw.Name = "ChangeLangsw";
            ChangeLangsw.Size = new Size(200, 22);
            ChangeLangsw.Text = "言語変更";
            // 
            // ChangeJ
            // 
            ChangeJ.Checked = true;
            ChangeJ.CheckState = CheckState.Checked;
            ChangeJ.Name = "ChangeJ";
            ChangeJ.Size = new Size(112, 22);
            ChangeJ.Text = "日本語";
            ChangeJ.Click += ChangeJ_Click;
            // 
            // ChangeE
            // 
            ChangeE.Name = "ChangeE";
            ChangeE.Size = new Size(112, 22);
            ChangeE.Text = "English";
            ChangeE.Click += ChangeE_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(197, 6);
            // 
            // Strip_Close
            // 
            Strip_Close.Name = "Strip_Close";
            Strip_Close.Size = new Size(200, 22);
            Strip_Close.Text = "終了";
            Strip_Close.Click += Strip_Close_Click;
            // 
            // testToolStripMenuItem
            // 
            testToolStripMenuItem.Name = "testToolStripMenuItem";
            testToolStripMenuItem.Size = new Size(200, 22);
            testToolStripMenuItem.Text = "test";
            testToolStripMenuItem.Click += testToolStripMenuItem_Click;
            // 
            // toggleIka004modeToolStripMenuItem
            // 
            toggleIka004modeToolStripMenuItem.Checked = true;
            toggleIka004modeToolStripMenuItem.CheckState = CheckState.Checked;
            toggleIka004modeToolStripMenuItem.Name = "toggleIka004modeToolStripMenuItem";
            toggleIka004modeToolStripMenuItem.Size = new Size(200, 22);
            toggleIka004modeToolStripMenuItem.Text = "toggle ika004mode";
            toggleIka004modeToolStripMenuItem.Visible = false;
            toggleIka004modeToolStripMenuItem.Click += toggleIka004modeToolStripMenuItem_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // dev1
            // 
            dev1.AutoSize = true;
            dev1.ForeColor = SystemColors.ButtonFace;
            dev1.Location = new Point(12, 9);
            dev1.Name = "dev1";
            dev1.Size = new Size(38, 15);
            dev1.TabIndex = 2;
            dev1.Text = "label1";
            dev1.Visible = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            BackColor = SystemColors.Desktop;
            BackgroundImage = Properties.Resources._default;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(287, 510);
            ContextMenuStrip = contextMenuStrip1;
            Controls.Add(dev1);
            Controls.Add(datetxt);
            Controls.Add(timetxt);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(303, 549);
            MinimumSize = new Size(303, 549);
            Name = "Form1";
            ShowIcon = false;
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Desktop Clock V2.3";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            contextMenuStrip1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label timetxt;
        private System.Windows.Forms.Timer uptime;
        private Label datetxt;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem 壁紙変更CToolStripMenuItem;
        private ToolStripSeparator toolStripMenuItem1;
        private ToolStripMenuItem Strip_Close;
        private OpenFileDialog openFileDialog1;
        private ToolStripMenuItem testToolStripMenuItem;
        private Label dev1;
        private ToolStripMenuItem ChangeWP_crop;
        private ToolStripMenuItem ChangeLangsw;
        private ToolStripMenuItem ChangeJ;
        private ToolStripMenuItem ChangeE;
        private ToolStripMenuItem toggleIka004modeToolStripMenuItem;
    }
}
