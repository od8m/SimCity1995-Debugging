using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Microsoft.Win32;
using System.IO;
using System.Reflection;
using System.Media;
using System.Runtime.InteropServices;
using System.Linq;

namespace KeygenApp
{
    public partial class KeygenForm : Form
    {
        private const int WM_NCLBUTTONDOWN = 0xA1;
        private const int HTCAPTION = 0x2;
        private Color gradientTop = Color.FromArgb(25, 25, 112);
        private Color gradientBottom = Color.FromArgb(72, 61, 139);
        private Font retroFont;
        private Timer marqueeTimer;
        private int marqueePosition = 0;
        private const string SCROLLING_TEXT = "[ BINARY FEMBOYS CRACK TEAM PRESENTS - SIMCITY 2000 KEYGEN - CRACKED BY TEAM BF - GREETZ TO ALL SCENE MEMBERS - FREE SOFTWARE FOR EVERYONE! ]    ";
        private SoundPlayer soundPlayer;
        private bool isMusicPlaying = false;

        [DllImport("user32.dll")]
        private static extern bool ReleaseCapture();

        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hWnd, int msg, int wParam, int lParam);

        public KeygenForm()
        {
            InitializeComponent();
            InitializeAudio();
            SetupScrollingText();
        }

        private void InitializeAudio()
        {
            try
            {
                string projectDirectory = Path.GetDirectoryName(Application.ExecutablePath);
                string wavFile = Path.Combine(projectDirectory, "IDM_Products_Core_Keygen_Music.WAV");

                if (File.Exists(wavFile))
                {
                    soundPlayer = new SoundPlayer(wavFile);
                }
                else
                {
                    var assembly = Assembly.GetExecutingAssembly();
                    string[] resources = assembly.GetManifestResourceNames();
                    string resourceName = resources.FirstOrDefault(name => name.EndsWith("IDM_Products_Core_Keygen_Music.WAV", StringComparison.OrdinalIgnoreCase));

                    if (resourceName != null)
                    {
                        using (Stream audioStream = assembly.GetManifestResourceStream(resourceName))
                        {
                            if (audioStream != null)
                            {
                                byte[] audioData = new byte[audioStream.Length];
                                audioStream.Read(audioData, 0, (int)audioStream.Length);
                                string tempFile = Path.Combine(Path.GetTempPath(), "temp_music.wav");
                                File.WriteAllBytes(tempFile, audioData);
                                soundPlayer = new SoundPlayer(tempFile);
                            }
                        }
                    }
                }

                if (soundPlayer != null)
                {
                    soundPlayer.PlayLooping();
                    isMusicPlaying = true;
                    if (btnToggleMusic != null)
                        btnToggleMusic.Text = "🔇";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading audio: {ex.Message}", "Audio Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SetupScrollingText()
        {
            retroFont = new Font("Consolas", 9, FontStyle.Bold);
            marqueeTimer = new Timer();
            marqueeTimer.Interval = 50;
            marqueeTimer.Tick += MarqueeTimer_Tick;
            marqueeTimer.Start();

            if (scrollLabel != null)
            {
                scrollLabel.Font = retroFont;
                scrollLabel.ForeColor = Color.Yellow;
                scrollLabel.Text = SCROLLING_TEXT;
            }
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle, gradientTop, gradientBottom, 90);
            e.Graphics.FillRectangle(brush, this.ClientRectangle);
        }

        private void MarqueeTimer_Tick(object sender, EventArgs e)
        {
            marqueePosition--;
            if (marqueePosition < -SCROLLING_TEXT.Length * 8)
                marqueePosition = scrollLabel.Width;

            scrollLabel.Location = new Point(marqueePosition, scrollLabel.Location.Y);
            scrollLabel.Refresh();
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            string mayorName = txtMayorName.Text.Trim();
            if (string.IsNullOrWhiteSpace(mayorName))
            {
                MessageBox.Show("Please enter a mayor name.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // get desktop path
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string sc2kBasePath = Path.Combine(desktopPath, "WIN95", "SC2K");
            string dataPath = Path.Combine(sc2kBasePath, "DATA");
            string graphicsPath = Path.Combine(sc2kBasePath, "BITMAPS");

            // make registration key
            using (RegistryKey regKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Maxis\SimCity 2000\REGISTRATION"))
            {
                if (regKey != null)
                {
                    regKey.SetValue("MAYOR NAME", mayorName);
                }
            }

            // set regedit
            using (RegistryKey pathsKey = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\Maxis\SimCity 2000\PATHS"))
            {
                if (pathsKey != null)
                {
                    pathsKey.SetValue("DATA", dataPath);
                    pathsKey.SetValue("GRAPHICS", graphicsPath);
                }
            }

            MessageBox.Show("License and paths generated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnToggleMusic_Click(object sender, EventArgs e)
        {
            if (isMusicPlaying)
            {
                soundPlayer.Stop();
                isMusicPlaying = false;
                btnToggleMusic.Text = "🔊";
            }
            else
            {
                soundPlayer.PlayLooping();
                isMusicPlaying = true;
                btnToggleMusic.Text = "🔇";
            }
        }

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
    }
}