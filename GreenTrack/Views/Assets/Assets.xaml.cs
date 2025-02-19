using GreenTrack.ViewModels.Assets;

namespace GreenTrack.Views.Assets;

public partial class Assets : ContentPage
{
    #region Constructor
    public Assets(AssetsViewModel assetsViewModel)
	{
		InitializeComponent();
        BindingContext = assetsViewModel;
    }
    #endregion
}