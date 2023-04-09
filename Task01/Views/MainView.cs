using System.Windows.Forms;

namespace Task01.Views
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();
            this.Text = "sadasasd";
        }

        public void setText(string text)
        {
            this.Text = text;
            button1.Text = " Text on button";
        }
    }
}
