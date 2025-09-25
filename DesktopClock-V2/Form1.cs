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
        private readonly bool _isDebug = true;
#else
        private readonly bool _isDebug = false;
#endif

        bool ikamode = false;

        private readonly string _posFP;
        private readonly string _picFP;
        private string SFPath;
        bool isikamode;

        private readonly string _systemLocale = System.Globalization.CultureInfo.CurrentCulture.Name;
        private readonly string _machineName = Environment.MachineName;

        string chlang = "ja";

        public Form1()
        {
            InitializeComponent();

            _posFP = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fPOS.txt");
            _picFP = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "fPIC.txt");

            dev1.Text = _machineName;
            dev1.Visible = _isDebug;

            if (_isDebug)
                this.Text = this.Text + " -DEBUG";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            updateTime();
            if (_machineName.Contains("IKA004"))
            {
                ikamode = true;
                toggleIka004modeToolStripMenuItem.Visible = true;

                if (_systemLocale != "ja-JP")
                {
                    chlang = "en";
                }
                changeLang();
                changeWallpaper();
            }
            LFpos();
            LFpic();
        }

        private void changeWallpaper()
        {
            if (ikamode && isikamode == false)
            {
                try
                {
                    string ikapicpath = @"C:\Users\ika004\Pictures\GEKIKAWANENECHANWALLPAPERFORIKACLOCK.png";
                    Image image = Image.FromFile(ikapicpath);
                    this.BackgroundImage = image;
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

        private void updateTime()
        {
            DateTime dateTime = DateTime.Now;
            // DateTime dt = DateTime.Parse("2025/02/01  00:47:00");
            // timetxt.Text = (dt.Hour.ToString() + ":" + dt.Minute.ToString());
            timetxt.Text = dateTime.ToString("HH:mm");

            // JP : EN
            datetxt.Text = (_systemLocale == "ja-JP") ? $"{dateTime:M} ({dateTime:ddd})" : $"{dateTime:dddd}, {dateTime:M}";

            // datetxt.Text = (dt.ToString("") + " (" + dt.ToString("ddd") + ")");

        }
        private void changeLang()
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
            updateTime();
        }

        private void Strip_Close_Click(object sender, EventArgs e) => this.Close();


        private void testToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!_isDebug) return;

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

        public static Image Crop(Image selectedImage, float targetAspectRatio = 9.0f / 16.0f)
        {
            Rectangle ClopArea;
            float originalAspectRatio = selectedImage.Width / selectedImage.Height;
            if (originalAspectRatio > targetAspectRatio)
            {
                int NewW = (int)(selectedImage.Height * targetAspectRatio);
                int XOffset = (selectedImage.Width - NewW) / 2;
                ClopArea = new Rectangle(XOffset, 0, NewW, selectedImage.Height);
            }
            else
            {
                int newH = (int)(selectedImage.Width / targetAspectRatio);
                int YOffset = (selectedImage.Height - newH) / 2;
                ClopArea = new Rectangle(0, YOffset, selectedImage.Width, newH);
            }

            Bitmap croppedImage = new Bitmap(ClopArea.Width, ClopArea.Height);
            using (Graphics g = Graphics.FromImage(croppedImage))
            {
                g.DrawImage(selectedImage, new Rectangle(0, 0, croppedImage.Width, croppedImage.Height), ClopArea, GraphicsUnit.Pixel);
            }
            return croppedImage;
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
                        DialogResult result = MessageBox.Show("現在、ika004 モードで起動しています。起動時にこの画像を読み込みますか？", "確認", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                        if (result == DialogResult.No)
                        {
                            uwagaki = true;
                        }
                    }

                    File.WriteAllText(_picFP, $"{filePath},{uwagaki}");

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
                changeLang();
            }
        }

        private void ChangeE_Click(object sender, EventArgs e)
        {
            if (chlang == "ja")
            {
                chlang = "en";
                changeLang();
            }
        }

        private void toggleIka004modeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleIka004modeToolStripMenuItem.Checked = !ikamode;

            changeWallpaper();
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

                File.WriteAllText(_posFP, $"{x},{y}");
            }
            catch (Exception)
            {
                //保存中にエラー
            }

        }

        private void LFpos()
        {
            if (File.Exists(_posFP))
            {
                try
                {
                    string[] pos = File.ReadAllText(_posFP).Split(",");

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
                string[] images = File.ReadAllText(_picFP).Split(",");


                if (images.Length == 2 && bool.TryParse(images[1], out isikamode))
                {
                    SFPath = images[0];
                }

                //ここから頭悪い
                if (isikamode == false)
                {
                    try
                    {
                        Image image = Image.FromFile(SFPath);

                        float targetAspectRatio = 9f / 16f;
                        float originalAspectRatio = (float)image.Width / image.Height;
                        if (Math.Abs(originalAspectRatio - targetAspectRatio) < 0.01f)
                        {
                            this.BackgroundImage = image;
                            this.BackgroundImageLayout = ImageLayout.Zoom;
                            //    MessageBox.Show("壁紙を変更しました");
                        }
                        else
                        {
                            Image croppedImage = Crop(image);
                            this.BackgroundImage = croppedImage;
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
