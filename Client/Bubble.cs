using System.Windows.Forms;

namespace SneakyChat.Client
{
    public partial class Bubble : UserControl
    {
        public Bubble()
        {
            InitializeComponent();
            this.ClientSize = new System.Drawing.Size(this.ClientSize.Width, (this.ClientSize.Height - messageText.Height) + (14 * (messageText.Lines.Length)));
        }
    }
}
