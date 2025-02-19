using GreenTrack.Services;
using GreenTrack.ViewModels.Register;

namespace GreenTrack.Views.Register;

public partial class CompleteInformation : ContentPage
{
    #region Constructor
    public CompleteInformation(CompleteInformationViewModel completeInformationViewModel)
	{
	    InitializeComponent();
        BindingContext = completeInformationViewModel;
    }
    #endregion
}