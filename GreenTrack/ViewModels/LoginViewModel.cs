using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GreenTrack.Services;
using GreenTrack.ViewModels.Register;
using GreenTrack.Views.Register;
using System.ComponentModel.DataAnnotations;

namespace GreenTrack.ViewModels
{
    public partial class LoginViewModel : ObservableValidator
    {
        #region Properties 
        private readonly AuthService _authService;
        private readonly SessionService _sessionService;
        private readonly CarbonGoalsService _carbonGoalsService;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Email is required!")]
        [EmailAddress(ErrorMessage = "Invalid email format!")]
        private string email;

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Password is required!")]
        [MinLength(6, ErrorMessage = "A Senha deve ter pelo menos 6 caracteres.")]
        private string password;

        [ObservableProperty]
        private bool isBusy;
        #endregion

        [ObservableProperty]
        string _emailValidationMessage;

        [ObservableProperty]
        string _passwordValidationMessage;

        [ObservableProperty]
        bool _emailHasValidationError;

        #region Constructor
        public LoginViewModel(AuthService authService, SessionService sessionService, CarbonGoalsService carbonGoalsService)
        {
            _authService = authService;
            _sessionService = sessionService;
            _carbonGoalsService = carbonGoalsService;
        }
        #endregion

        #region Methods
        [RelayCommand]
        public async Task LoginAsync()
        {
            if (IsBusy) return;
            IsBusy = true;
            ValidateAllProperties();
            if (HasErrors)
            {
                EmailValidationMessage = GetErrors(nameof(Email)).FirstOrDefault()!.ErrorMessage ?? string.Empty;
                if (EmailValidationMessage != string.Empty)
                {
                    EmailHasValidationError = true;
                }
                else
                {
                    EmailHasValidationError = false;
                }

                PasswordValidationMessage = GetErrors(nameof(Password))?.FirstOrDefault()!.ErrorMessage ?? string.Empty;
                if (PasswordValidationMessage != string.Empty)
                {
                    EmailHasValidationError = true;
                }
                else
                {
                    EmailHasValidationError = false;
                }

                return;
            }
            else
            {
                EmailValidationMessage = string.Empty;
                PasswordValidationMessage = string.Empty;
            }

            var success = await _authService.LoginDataAsync(Email, Password);
            if (success)
            {
                if (_sessionService.LoggedInUser!.IsNew)
                {
                      Application.Current!.MainPage = new NavigationPage(new CompleteInformation(new CompleteInformationViewModel(_carbonGoalsService, _sessionService)));
                }
                else
                {
                    Application.Current!.MainPage = new AppShell();
                }
            }
            else
            {
                await Application.Current!.MainPage!.DisplayAlert("Erro", "Login falhou", "OK");
            }
            IsBusy = false;
        }
        #endregion
    }
}
