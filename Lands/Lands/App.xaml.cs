namespace Lands
{
    using Lands.Views;
    using Xamarin.Forms;
    using Helpers;
    using ViewModels;

    public partial class App : Application
    {
        #region Properties
        public static NavigationPage Navigator
        {
            get;
            internal set;
        } 
        #endregion

        #region Constructors
        public App()
        {
            InitializeComponent();

            if (string.IsNullOrEmpty(Settings.Token))
            {
                this.MainPage = new NavigationPage(new LoginPage());
            }
            else
            {
                var mainViewModels = MainViewModel.GetInstance();
                mainViewModels.Token = Settings.Token;
                mainViewModels.TokenType = Settings.TokenType;
                mainViewModels.Lands = new LandsViewModel();
                this.MainPage = new MasterPage();
            }
        }
        #endregion

        #region Methods
        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        } 
        #endregion
    }
}
