using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenTrack.DTO;
using GreenTrack.Models;
using GreenTrack.Services;
using GreenTrack.Views;
using System.ComponentModel.DataAnnotations;

namespace GreenTrack.ViewModels.Register
{
    public partial class CompleteInformationViewModel : ObservableValidator
    {
        #region Properties
        private readonly CarbonGoalsService _carbonGoalsService;
        private readonly SessionService _sessionService;
        private readonly INavigation _navigation;

        [Required(ErrorMessage = "The field Target Emission is required.")]
        [ObservableProperty]
        private decimal _targetEmission;

        [ObservableProperty]
        string _targetValidationMessage;

        [ObservableProperty]
        bool _targetHasValidationError;

        [ObservableProperty]
        private DateTime _deadline;

        [ObservableProperty]
        private string _description;

        [ObservableProperty]
        private bool _isBusy;
        #endregion
        #region Constructor
        public CompleteInformationViewModel(CarbonGoalsService carbonGoalsService, SessionService sessionService)
        {
            _carbonGoalsService = carbonGoalsService;
            _sessionService = sessionService;
        }
        #endregion
        #region Methods
        [RelayCommand]
        public async Task CompleteInformationAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            ValidateAllProperties();
            if (HasErrors)
            {
                return;
            }

            ApiResponse<CarbonGoal>? newCarbonGoal = await _carbonGoalsService.SaveGoals(new CarbonGoalsDTO
            {
                Description = Description,
                Deadline = Deadline,
                TargetEmission = TargetEmission,
                UserId = _sessionService.LoggedInUser!.Id!
            });

            if (newCarbonGoal != null)
            {
                if (newCarbonGoal.Success)
                {
                    await Application.Current!.MainPage!.DisplayAlert("Success", "Information Completed", "Continue");
                    Application.Current.MainPage = new AppShell();
               

                }
                else
                {
                    await Application.Current!.MainPage!.DisplayAlert("Error", newCarbonGoal.ErrorMessage, "Continue");
                }
            }

            IsBusy = false;
        }
        #endregion
    }
}
