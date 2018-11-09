using System.Windows.Controls;

namespace WheelsCallCenterDashboard.Views
{
    /// <summary>
    /// Interaction logic for BrowserView.xaml
    /// </summary>
    public partial class BrowserView : UserControl
    {
        public BrowserView()
        {
            InitializeComponent();
            webBrowser.Navigate("http://whqmarquee41/IWP/Marquee/p/ReplaceCOBOX");
            //DataContext = new WebBrowser
        }
    }
}
