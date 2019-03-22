namespace Lands.ViewModels
{
    using Services;
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text;
    using Xamarin.Forms;

    public class LandsViewModel : BaseViewModel
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Attributes
        private ObservableCollection<Land> lands;
        #endregion

        #region Properties
        public ObservableCollection<Land> Lands
        {
            get { return this.lands; }
            set { SetValue(ref this.lands, value); }
        }
        #endregion

        #region Constructor
        public LandsViewModel()
        {
            this.LoadLands();
            this.LoadLands();
        }
        #endregion
        
        
        #region Methods
        private async void LoadLands()
        {
            var response = await this.apiService.GetList<Land>(
                "https://restcountries.eu",
                "/rest",
                "/v2/all");
            if (!response.IsSuccess)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error", 
                    response.Message, 
                    "Accept");
                return;
            }

            var list = (List<Land>)response.Result;
            this.Lands = new ObservableCollection<Land>(list);
        } 
       
        #endregion
    }
}
