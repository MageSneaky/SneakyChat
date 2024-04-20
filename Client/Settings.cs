using SneakyChat.Client.Tabs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakyChat.Client
{
    public partial class Settings : Form
    {
        #region Variables
        public Main main;
        #endregion

        #region Constructor
        public Settings()
        {
            InitializeComponent();
        }
        #endregion

        #region Control Events
        private void Settings_Load(object sender, EventArgs e)
        {
            Tab_General tab_General = new Tab_General();
            AddTab(tab_General);
        }

        private void Settings_FormClosing(object sender, FormClosingEventArgs e)
        {
            main.Enabled = true;
            main.settings = null;
        }
        #endregion

        #region Methods
        private void AddTab(UserControl userControl)
        {
            userControl.Dock = DockStyle.Fill;
            containerPanel.Controls.Clear();
            containerPanel.Controls.Add(userControl);
            userControl.BringToFront();
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