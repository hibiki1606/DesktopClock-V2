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
            toolStripMenuItem1 = new ToolStripSeparator();
            Strip_Close = new ToolStripMenuItem();
            openFileDialog1 = new OpenFileDialog();
            contextMenuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // timetxt
            // 
            timetxt.AutoSize = true;
            timetxt.BackColor = Color.Transparent;
            timetxt.Font = new Font("Yu Gothic UI Semilight", 45F, FontStyle.Regular, GraphicsUnit.Point);
            timetxt.ForeColor = SystemColors.ControlLightLight;
            timetxt.Location = new Point(2, 351);
            timetxt.Name = "timetxt";
            timetxt.Size = new Size(176, 81);
            timetxt.TabIndex = 0;
            timetxt.Text = "00:00";
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
            contextMenuStrip1.Items.AddRange(new ToolStripItem[] { 壁紙変更CToolStripMenuItem, toolStripMenuItem1, Strip_Close });
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(138, 54);
            // 
            // 壁紙変更CToolStripMenuItem
            // 
            壁紙変更CToolStripMenuItem.Name = "壁紙変更CToolStripMenuItem";
            壁紙変更CToolStripMenuItem.Size = new Size(137, 22);
            壁紙変更CToolStripMenuItem.Text = "壁紙変更(&C)";
            壁紙変更CToolStripMenuItem.Click += 壁紙変更CToolStripMenuItem_Click;
            // 
            // toolStripMenuItem1
            // 
            toolStripMenuItem1.Name = "toolStripMenuItem1";
            toolStripMenuItem1.Size = new Size(134, 6);
            // 
            // Strip_Close
            // 
            Strip_Close.Name = "Strip_Close";
            Strip_Close.Size = new Size(137, 22);
            Strip_Close.Text = "終了";
            Strip_Close.Click += Strip_Close_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = SystemColors.Desktop;
            BackgroundImage = Properties.Resources.タイトルなし;
            BackgroundImageLayout = ImageLayout.Zoom;
            ClientSize = new Size(287, 510);
            ContextMenuStrip = contextMenuStrip1;
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
            Text = "Desktop Clock V2";
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
    }
}
