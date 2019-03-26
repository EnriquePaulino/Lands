namespace Lands.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using Lands.ViewsModels;
    using Services;
    using System.Windows.Input;
    using Xamarin.Forms;
    using Helpers;

    public class LoginViewModel : BaseViewModel
    {
        #region Service
        private ApiService apiService;
        #endregion

        #region Attributes
        private string email;
        private string password;
        private bool isRunning;
        private bool isEnabled;
        #endregion

        #region Properties
        public string Email
        {
            get { return this.email; }
            set { SetValue(ref this.email, value); }
        }
        public string Password
        {
            get { return this.password; }
            set { SetValue(ref this.password, value); }
        }

        public bool IsRunning
        {
            get { return this.isRunning; }
            set { SetValue(ref this.isRunning, value); }
        }

        public bool IsRemembered
        {
            get;
            set;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
            set { SetValue(ref this.isEnabled, value); }
        }
        #endregion

        #region Constructors
        public LoginViewModel()
        {
            this.apiService = new ApiService();

            this.IsRemembered = true;
            this.IsEnabled = true;

            this.Email = "paulinoenrique@gmail.com";
            this.Password = "123456";
        }
        #endregion

        #region Commands
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(Login);
            }
        }

        private async void Login()
        {
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    Languages.EmailValidation,
                    Languages.Accept);
                this.Email = string.Empty;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    "Languages.PasswordValidation",
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = true;

            if (this.Email != "paulinoenrique@gmail.com" || this.Password != "123456")
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    Languages.Error,
                    "Email or Password incorrect.",
                    Languages.Accept);
                this.Password = string.Empty;
                return;
            }
            this.IsRunning = false;
            this.IsEnabled = true;

            MainViewModel.GetInstance().Lands = new LandsViewModel();
            await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());

            //this.IsRunning = true;
            //this.IsEnabled = true;

            //var connection = await this.apiService.CheckConnection();

            //if (!connection.IsSuccess)
            //{
            //    this.IsRunning = false;
            //    this.IsEnabled = true;

            //    await Application.Current.MainPage.DisplayAlert(
            //        "Error",
            //        connection.Message,
            //        "Accept");
            //    this.Email = string.Empty;
            //    return;
            //}

            //var token = await this.apiService.GetToken(
            //    "http://localhost:51259",
            //    this.Email,
            //    this.Password);

            //if (token == null)
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //       "Error",
            //       "Semething was wrong, please try later.",
            //       "Accept");
            //    return;
            //}

            //if (string.IsNullOrEmpty(token.AccessToken))
            //{
            //    await Application.Current.MainPage.DisplayAlert(
            //       "Error",
            //       token.ErrorDescription,
            //       "Accept");
            //    this.Email = string.Empty;
            //    return;
            //}

            //var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;
            //mainViewModel.Lands = new LandsViewModel();
            //await Application.Current.MainPage.Navigation.PushAsync(new LandsPage());


            //this.IsRunning = false;
            //this.IsEnabled = true;

            //this.Email = string.Empty;
            //this.Password = string.Empty;
        }
        #endregion
    }
}
