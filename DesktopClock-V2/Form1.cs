using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.IO;
using System.ComponentModel;
using System.Security.Cryptography;
namespace DesktopClock_V2
{



    public partial class Form1 : Form
    {

#if DEBUG
        private readonly bool isDebug = true;
#else
        private readonly bool isDebug = false;
#endif

        bool ikamode = false;

        private readonly string posFP;
        private readonly string picFP;
        string SFPath;
        bool isikamode;

        string SysLang = System.Globalization.CultureInfo.CurrentCulture.Name;
        string PCN = Environment.MachineName;

        string chlang = "ja";
        public Form1()
        {
            InitializeComponent();
            posFP = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fPOS.txt");
            picFP = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fPIC.txt");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            

            dev1.Text = PCN;

            apdatetime();
            if (PCN.Contains("IKA004"))
            {
               ikamode = true;
                toggleIka004modeToolStripMenuItem.Visible = true;

                if (isDebug)
                {
                    dev1.Visible = true;
                    this.Text = this.Text + " -DEBUG";
                }


                if (SysLang != "ja-JP")
                {
                    chlang = "en";
                }
                LangChange();
                changewp();
                
            }
            LFpos();
            LFpic();

        }


        private void changewp()
        {
            if (ikamode && isikamode == false)
            {
                try
                {
                    string ikapicpath = "C:\\Users\\ika004\\Pictures\\GEKIKAWANENECHANWALLPAPERFORIKACLOCK.png";
                    Image iimage = Image.FromFile(ikapicpath);
                    this.BackgroundImage = iimage;
                }
                catch (FileNotFoundException)
                {

                }
            }
            else
            {
                // idk to change to default wallpaper
                /*
                string ikapicpath = "Properties.Resources._default";
                 Image iimage = Image.FromFile(ikapicpath);
                 this.BackgroundImage = iimage;
                */
            }
        }

        private void apdatetime()
        {
            DateTime dt = DateTime.Now;
            // DateTime dt = DateTime.Parse("2025/02/01  00:47:00");
            // timetxt.Text = (dt.Hour.ToString() + ":" + dt.Minute.ToString());
            timetxt.Text = dt.ToString("HH:mm");


            if (SysLang == "ja-JP")
            {
                datetxt.Text = (dt.ToString("M") + " (" + dt.ToString("ddd") + ")");
            }
            else
            {
                datetxt.Text = (dt.ToString("dddd") + ", " + dt.ToString("M"));
            }

            // datetxt.Text = (dt.ToString("") + " (" + dt.ToString("ddd") + ")");

        }
        private void LangChange()
        {
            if (chlang == "ja")
            {
                ChangeWP_crop.Text = "壁紙変更 (&C)";
                Strip_Close.Text = "終了";
                ChangeLangsw.Text = "言語変更";
                ChangeE.Checked = false;
                ChangeJ.Checked = true;
            }
            else
            {
                ChangeWP_crop.Text = "Change Wallpaper (&C)";
                Strip_Close.Text = "Close";
                ChangeLangsw.Text = "Change Language";
                ChangeE.Checked = true;
                ChangeJ.Checked = false;
            }
        }


        private void uptime_Tick(object sender, EventArgs e)
        {
            apdatetime();
        }

        private void Strip_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }






        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            if (isDebug)
            {
                var ofd = new OpenFileDialog();
                ofd.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
                if (ofd.ShowDialog() == DialogResult.OK)

                {
                    string FilePath = ofd.FileName;
                    try
                    {
                        Image SelectedImage = Image.FromFile(FilePath);
                        string filePath = ofd.FileName;

                        float aspe = 9f / 16f;
                        float imgaspe = (float)SelectedImage.Width / SelectedImage.Height;
                        if (Math.Abs(imgaspe - aspe) < 0.01f)
                        {
                            this.BackgroundImage = SelectedImage;
                            this.BackgroundImageLayout = ImageLayout.Zoom;
                            MessageBox.Show("壁紙を変更しました");
                        }
                        else
                        {
                            Image CropIMG = Crop(SelectedImage);
                            this.BackgroundImage = CropIMG;
                        }


                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"画像の読み込み中にエラーが発生しました: {ex.Message}");
                    }
                }
            }
        }


        public static Image Crop(Image SelectedImage, double targetAspectRatio = 9.0 / 16.0)
        {
            Rectangle ClopArea;
            float imgaspe = (float)SelectedImage.Width / SelectedImage.Height;
            double targetAspe = 9.0 / 16.0;
            if (imgaspe > targetAspe)
            {
                int NewW = (int)(SelectedImage.Height * targetAspe);
                int XOffset = (SelectedImage.Width - NewW) / 2;
                ClopArea = new Rectangle(XOffset, 0, NewW, SelectedImage.Height);
            }
            else
            {
                int newH = (int)(SelectedImage.Width / targetAspe);
                int YOffset = (SelectedImage.Height - newH) / 2;
                ClopArea = new Rectangle(0, YOffset, SelectedImage.Width, newH);
            }

            Bitmap CroppedIMG = new Bitmap(ClopArea.Width, ClopArea.Height);
            using (Graphics g = Graphics.FromImage(CroppedIMG))
            {
                g.DrawImage(SelectedImage, new Rectangle(0, 0, CroppedIMG.Width, CroppedIMG.Height), ClopArea, GraphicsUnit.Pixel);
            }
            return CroppedIMG;
        }

        private void ChangeWP_crop_Click(object sender, EventArgs e)
        {
            //Change Wallpaper (Crop)

            var ofd = new OpenFileDialog();
            ofd.Filter = "Image File(*.bmp,*.jpg,*.png,*.tif)|*.bmp;*.jpg;*.png;*.tif|Bitmap(*.bmp)|*.bmp|Jpeg(*.jpg)|*.jpg|PNG(*.png)|*.png";
            if (ofd.ShowDialog() == DialogResult.OK)

            {
                string FilePath = ofd.FileName;
                try
                {
                    Image SelectedImage = Image.FromFile(FilePath);
                    string filePath = ofd.FileName;

                    float aspe = 9f / 16f;
                    float imgaspe = (float)SelectedImage.Width / SelectedImage.Height;
                    if (Math.Abs(imgaspe - aspe) < 0.01f)
                    {
                        this.BackgroundImage = SelectedImage;
                        this.BackgroundImageLayout = ImageLayout.Zoom;
                        MessageBox.Show("壁紙を変更しました");
                    }
                    else
                    {
                        Image CropIMG = Crop(SelectedImage);
                        this.BackgroundImage = CropIMG;
                        MessageBox.Show("壁紙をクロップして変更しました");
                    }

                    //save picture path

                    bool uwagaki = false;

                    if (ikamode == true)
                    {
                        DialogResult result = MessageBox.Show("現在、ika004 モードで起動しています。起動時にこの画像を読み込みますか？","確認",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);

                        if (result == DialogResult.No)
                        {
                            uwagaki = true;
                        }
                    }
                    
                    File.WriteAllText(picFP, $"{filePath},{uwagaki}");


                }
                catch (Exception ex)
                {
                    MessageBox.Show($"画像の読み込み中にエラーが発生しました: {ex.Message}");
                }
            }
        }

        private void ChangeJ_Click(object sender, EventArgs e)
        {
            if (chlang == "en")
            {
                chlang = "ja";
                LangChange();
            }
        }

        private void ChangeE_Click(object sender, EventArgs e)
        {
            if (chlang == "ja")
            {
                chlang = "en";
                LangChange();
            }
        }

        private void toggleIka004modeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (toggleIka004modeToolStripMenuItem.Checked == true)
            {
                ikamode = false;
            }
            else
            {
                ikamode = true;
            }
            changewp();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            SFpos();
        }

        private void SFpos()
        {
            try
            {
                string x = this.Location.X.ToString();
                string y = this.Location.Y.ToString();

                File.WriteAllText(posFP, $"{x},{y}");
            }
            catch (Exception)
            {
                //保存中にエラー
            }

        }

        private void LFpos()
        {
            if (File.Exists(posFP))
            {
                try
                {
                    string[] pos = File.ReadAllText(posFP).Split(",");

                    if (pos.Length == 2)
                    {
                        if (int.TryParse(pos[0], out int x) && int.TryParse(pos[1], out int y))
                        {
                            this.Location = new Point(x, y);
                        }
                        else
                        {

                        }
                    }
                }
                catch (Exception)
                {

                }
            }
        }

        private void LFpic()
        {
            try
            {
                string[] images = File.ReadAllText(picFP).Split(",");


                if (images.Length == 2 && bool.TryParse(images[1], out isikamode))
                {
                    SFPath = images[0];
                }

                //ここから頭悪い
                if (isikamode == false)
                {
                    try
                    {
                        Image SelectedImage = Image.FromFile(SFPath);
                        string filePath = SFPath;

                        float aspe = 9f / 16f;
                        float imgaspe = (float)SelectedImage.Width / SelectedImage.Height;
                        if (Math.Abs(imgaspe - aspe) < 0.01f)
                        {
                            this.BackgroundImage = SelectedImage;
                            this.BackgroundImageLayout = ImageLayout.Zoom;
                            //    MessageBox.Show("壁紙を変更しました");
                        }
                        else
                        {
                            Image CropIMG = Crop(SelectedImage);
                            this.BackgroundImage = CropIMG;
                            //  MessageBox.Show("壁紙をクロップして変更しました");
                        }
                    }
                    catch

                    { }
                }
            }
            catch
            {

            }
            
        }
    }
}
