using System.Drawing;
using System.Windows.Forms;

namespace KeygenApp
{
    partial class KeygenForm
    {
        private System.ComponentModel.IContainer components = null;
        private Panel mainPanel;
        private Label asciiArtLabel;
        private Label scrollLabel;
        private System.Windows.Forms.TextBox txtMayorName;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.Button btnToggleMusic;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtMayorName = new System.Windows.Forms.TextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.asciiArtLabel = new System.Windows.Forms.Label();
            this.scrollLabel = new System.Windows.Forms.Label();
            this.btnToggleMusic = new System.Windows.Forms.Button();

            this.SuspendLayout();

            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 400);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "KeygenForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SimCity2000 Keygen";

            this.ResumeLayout(false);

            InitializeCustomComponents();
        }

        private void InitializeCustomComponents()
        {
            retroFont = new Font("Consolas", 9, FontStyle.Bold);

            // scrolling text speed
            marqueeTimer = new Timer(this.components);
            marqueeTimer.Interval = 30; 
            marqueeTimer.Tick += new System.EventHandler(this.MarqueeTimer_Tick);
            marqueePosition = this.ClientSize.Width;  
            marqueeTimer.Start();

            mainPanel = new Panel();
            mainPanel.Dock = DockStyle.Fill;
            mainPanel.Paint += new PaintEventHandler(this.MainPanel_Paint);
            this.Controls.Add(mainPanel);

            asciiArtLabel = new Label();
            asciiArtLabel.Font = new Font("Consolas", 8, FontStyle.Regular);
            asciiArtLabel.ForeColor = Color.Lime;
            asciiArtLabel.BackColor = Color.Transparent;
            asciiArtLabel.AutoSize = false;
            asciiArtLabel.Size = new Size(460, 180);
            asciiArtLabel.Location = new Point(20, 20);
            asciiArtLabel.Text = @"
           ░██████╗██╗███╗   ███╗ ██████╗██╗████████╗██╗   ██╗
           ██╔════╝██║████╗ ████║██╔════╝██║╚══██╔══╝╚██╗ ██╔╝
           ╚█████╗ ██║██╔████╔██║██║     ██║   ██║    ╚████╔╝ 
            ╚═══██╗██║██║╚██╔╝██║██║     ██║   ██║     ╚██╔╝  
           ██████╔╝██║██║ ╚═╝ ██║╚██████╗██║   ██║      ██║   
           ╚═════╝ ╚═╝╚═╝     ╚═╝ ╚═════╝╚═╝   ╚═╝      ╚═╝   
           ╔════════════════════  2 0 0 0  ════════════════════╗
           ║  [BINARY FEMBOYS CRACK TEAM PROUDLY PRESENTS...]  ║
           ╚═══════════════════════════════════════════════════╝
            ♪♫♬ Cracked with love - No fucking DRM! v1.0 ♪♫♬  
           ";
            mainPanel.Controls.Add(asciiArtLabel);

            scrollLabel = new Label();
            scrollLabel.Font = retroFont;
            scrollLabel.ForeColor = Color.Yellow;
            scrollLabel.BackColor = Color.Transparent;
            scrollLabel.AutoSize = true;  
            scrollLabel.Location = new Point(marqueePosition, 200);
            mainPanel.Controls.Add(scrollLabel);

            Label mayorLabel = new Label();
            mayorLabel.Text = "ENTER MAYOR NAME:";
            mayorLabel.Font = retroFont;
            mayorLabel.ForeColor = Color.Cyan;
            mayorLabel.BackColor = Color.Transparent;
            mayorLabel.AutoSize = true;
            mayorLabel.Location = new Point(20, 240);
            mainPanel.Controls.Add(mayorLabel);

            txtMayorName.Font = retroFont;
            txtMayorName.Size = new Size(460, 25);
            txtMayorName.Location = new Point(20, 265);
            txtMayorName.BackColor = Color.Black;
            txtMayorName.ForeColor = Color.Lime;
            txtMayorName.BorderStyle = BorderStyle.FixedSingle;
            mainPanel.Controls.Add(txtMayorName);

            btnGenerate.Font = retroFont;
            btnGenerate.Size = new Size(460, 35);
            btnGenerate.Location = new Point(20, 305);
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.BackColor = Color.FromArgb(0, 64, 0);
            btnGenerate.ForeColor = Color.Lime;
            btnGenerate.Text = "GENERATE LICENSE";
            btnGenerate.FlatAppearance.BorderColor = Color.Lime;
            btnGenerate.FlatAppearance.MouseOverBackColor = Color.FromArgb(0, 96, 0);
            btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            mainPanel.Controls.Add(btnGenerate);

            Button btnExit = new Button();
            btnExit.Font = retroFont;
            btnExit.Size = new Size(460, 35);
            btnExit.Location = new Point(20, 350);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.BackColor = Color.FromArgb(64, 0, 0);
            btnExit.ForeColor = Color.Red;
            btnExit.Text = "EXIT";
            btnExit.FlatAppearance.BorderColor = Color.Red;
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(96, 0, 0);
            btnExit.Click += (s, e) => Application.Exit();
            mainPanel.Controls.Add(btnExit);

            btnToggleMusic = new Button();
            btnToggleMusic.Size = new Size(30, 30);
            btnToggleMusic.Location = new Point(450, 20);
            btnToggleMusic.FlatStyle = FlatStyle.Flat;
            btnToggleMusic.BackColor = Color.Transparent;
            btnToggleMusic.ForeColor = Color.Cyan;
            btnToggleMusic.Text = "🔊";
            btnToggleMusic.Font = new Font("Segoe UI", 12);
            btnToggleMusic.FlatAppearance.BorderSize = 0;
            btnToggleMusic.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, 40, 40);
            btnToggleMusic.Click += new System.EventHandler(this.btnToggleMusic_Click);
            mainPanel.Controls.Add(btnToggleMusic);

            this.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            asciiArtLabel.MouseDown += new MouseEventHandler(this.Form_MouseDown);
            mainPanel.MouseDown += new MouseEventHandler(this.Form_MouseDown);

            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint |
                ControlStyles.UserPaint |
                ControlStyles.DoubleBuffer |
                ControlStyles.OptimizedDoubleBuffer,
                true);

            foreach (Control control in this.Controls)
            {
                if (control is Button || control is TextBox)
                    continue;
                control.BackColor = Color.Transparent;
            }
        }
    }
}
