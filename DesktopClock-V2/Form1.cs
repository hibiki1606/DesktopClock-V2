using System.Runtime.CompilerServices;

namespace DesktopClock_V2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }



        private void apdatetime()
        {
            DateTime dt = DateTime.Now;
            // timetxt.Text = (dt.Hour.ToString() + ":" + dt.Minute.ToString());
            timetxt.Text = dt.ToString("HH:mm");
            datetxt.Text = (dt.ToString("M") + " (" + dt.ToString("ddd") + ")");
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            apdatetime();
        }
        private void uptime_Tick(object sender, EventArgs e)
        {
            apdatetime();
        }

        private void Strip_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void �ǎ��ύXCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //9:16�̏c����̎ʐ^�����s���Ȃ��f�����b�g�͂��邯�ǁA�Ƃ肠�����͂ł���
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
                        MessageBox.Show("�ǎ���ύX���܂���");
                    }
                    else
                    {
                        MessageBox.Show("�ǎ���ύX�ł��܂���ł����B\n �摜�t�@�C���̏c���䂪9:16�ł͂���܂���B","Error", MessageBoxButtons.OK , MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"�摜�̓ǂݍ��ݒ��ɃG���[���������܂���: {ex.Message}");
                }

                
            }
        }
    }
}
