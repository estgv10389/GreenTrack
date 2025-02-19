using GreenTrack.Views;

namespace GreenTrack
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("HomePage", typeof(HomePage));
        }
    }
}
