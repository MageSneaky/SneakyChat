using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SneakyChat.Client.Tabs
{
    public partial class Tab_General : UserControl
    {
        public IniFile settingsfile = new IniFile("settings.ini");
        public string ip = "127.0.0.1";
        public int port = 5000;
        public Tab_General()
        {
            InitializeComponent();
            if (!settingsfile.KeyExists("ip") || !settingsfile.KeyExists("port"))
            {
                settingsfile.Write("ip", ip);
                settingsfile.Write("port", port.ToString());
            }
            else
            {
                ip = settingsfile.Read("ip");
                int.TryParse(settingsfile.Read("port"), out port);
            }
            ipTextBox.Text = ip;
            portTextBox.Text = port.ToString();
        }
    }
}
