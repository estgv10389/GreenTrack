using GreenTrack.ViewModels;

namespace GreenTrack
{
    public partial class MainPage : ContentPage
    {
        public MainPage(LoginViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
    }

}
