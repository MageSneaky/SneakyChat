using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SneakyChat.Client
{
    public partial class UserInput : Form
    {
        #region Variables
        public IniFile settingsfile = new IniFile("settings.ini");
        private string avatar;
        private string username;
        #endregion

        #region Constructor
        public UserInput()
        {
            InitializeComponent();
            if (Properties.Settings.Default.avatar != "")
            {
                avatar = Properties.Settings.Default.avatar;
            }
            if (File.Exists("settings.ini") && settingsfile.KeyExists("username") && Properties.Settings.Default.avatar != "")
            {
                Console.WriteLine("MEOW: " + avatar);
                username = settingsfile.Read("username");
                Main main = new Main();
                main.avatar = avatar;
                main.username = username;
                main.Show();
                main.Focus();
                this.Close();
            }
            else
            {
                this.Show();
                this.Focus();
            }
        }
        #endregion

        #region Control Events

        private void avatarPictureBox_Click(object sender, EventArgs e)
        {
            if (avatarFileDialog.ShowDialog() == DialogResult.OK)
            {
                avatarPictureBox.Image = Image.FromFile(avatarFileDialog.FileName);
            }
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (avatarFileDialog.FileName != "" && usernameTextbox.Text != "" && !char.IsWhiteSpace(usernameTextbox.Text, 0))
            {
                avatar = Base64Image(avatarFileDialog.FileName);
                username = usernameTextbox.Text;
                Properties.Settings.Default.avatar = avatar;
                Properties.Settings.Default.Save();
                settingsfile.Write("username", username);
                Main main = new Main();
                main.avatar = avatar;
                main.username = username;
                main.Show();
                main.Focus();
                this.Close();
            }
        }
        #endregion

        #region Methods
        private string Base64Image(string path)
        {
            using (Image image = Image.FromFile(path))
            {
                Image newimage = ResizeImage(image, 50, 50);
                using (MemoryStream m = new MemoryStream())
                {
                    newimage.Save(m, image.RawFormat);
                    byte[] imageBytes = m.ToArray();

                    string base64String = Convert.ToBase64String(imageBytes);
                    return base64String;
                }
            }
        }
        public static Bitmap ResizeImage(Image image, int width, int height)
        {
            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
        #endregion

        #region Title Bar Color
        [DllImport("DwmApi")]
        private static extern int DwmSetWindowAttribute(IntPtr hwnd, int attr, int[] attrValue, int attrSize);

        protected override void OnHandleCreated(EventArgs e)
        {
            if (DwmSetWindowAttribute(Handle, 19, new[] { 1 }, 4) != 0)
                DwmSetWindowAttribute(Handle, 20, new[] { 1 }, 4);
        }
        #endregion
    }
}
