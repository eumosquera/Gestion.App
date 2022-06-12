using System;
using System.Collections.Generic;
using System.Text;
using Gestion.App.ViewsModels;
using Gestion.App.DTOs;
using System.Collections.ObjectModel;
using System.Net.Http;
using Newtonsoft;
using Newtonsoft.Json;
using Xamarin.Forms;
using Gestion.App.ViewModels;

namespace Gestion.App.ViewsModels.Forms
{
    public class TechniciansViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<TechnicianItemViewModel> _technicians;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<TechnicianItemViewModel> Technicians
        {
            get { return _technicians; }
            set { this.SetValue(ref _technicians, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion


        #region Methods
        async void GetTechnicians()
        {
            this.IsRefreshing = true;

            var url = "https://62a2880ecc8c0118ef636563.mockapi.io/tecnicos";

            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var technicians = JsonConvert.DeserializeObject<ObservableCollection<TechnicianItemViewModel>>(result);
                    this.Technicians = technicians;
                
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Notify", "Fail", "Ok");

                }
            }
            this.IsRefreshing = false;

        }

        #endregion

        #region Commands
        public Command RefreshCommand { get; set; }

        #endregion

        public TechniciansViewModel()
        {
            this.RefreshCommand = new Command(GetTechnicians);
            this.RefreshCommand.Execute(null);
        }
    }
}
