using System;
using System.Diagnostics;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SneakyChat.Client
{
    public partial class About : Form
    {
        #region Variables
        public Main main;
        #endregion

        #region Constructor
        public About()
        {
            InitializeComponent();
            this.Text = String.Format("About {0}", AssemblyTitle);
            this.labelProductName.Text = AssemblyTitle;
            this.labelVersion.Text = String.Format("Version {0}", AssemblyVersion);
            this.labelCompanyName.Text = String.Format("Made By {0}", AssemblyCompany);

            ToolTip toolTip = new ToolTip();
            toolTip.InitialDelay = 400;

            toolTip.SetToolTip(this.productPictureBox, "Open https://github.com/MageSneaky/SneakyChat in browser");
        }
        #endregion

        #region Control Events
        private void About_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.about = null;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void productPictureBox_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/MageSneaky/SneakyChat");
        }
        #endregion

        #region Assembly Attribute Accessors

        public string AssemblyTitle
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                if (attributes.Length > 0)
                {
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    if (titleAttribute.Title != "")
                    {
                        return titleAttribute.Title;
                    }
                }
                return System.IO.Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
            }
        }

        public string AssemblyVersion
        {
            get
            {
                return Assembly.GetExecutingAssembly().GetName().Version.ToString();
            }
        }

        public string AssemblyCompany
        {
            get
            {
                object[] attributes = Assembly.GetExecutingAssembly().GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                if (attributes.Length == 0)
                {
                    return "";
                }
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            }
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
