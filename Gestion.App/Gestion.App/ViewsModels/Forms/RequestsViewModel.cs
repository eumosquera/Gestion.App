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
    public class RequestsViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<RequestItemViewModel> _requests;
        private bool _isRefreshing;
        #endregion

        #region Properties
        public ObservableCollection<RequestItemViewModel> Requests
        {
            get { return _requests; }
            set { this.SetValue(ref _requests, value); }
        }

        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods
        async void GetRequests()
        {
            this.IsRefreshing = true;

            var url = "https://62a2880ecc8c0118ef636563.mockapi.io/solicitud_servicio";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var requests = JsonConvert.DeserializeObject<ObservableCollection<RequestItemViewModel>>(result);
                    this.Requests = requests;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Notify", "Fail", "Ok");

                }
            }
            this.IsRefreshing = false;
        }

        public RequestsViewModel()
        {
            this.RefreshCommand = new Command(GetRequests);
            this.RefreshCommand.Execute(null);
        }

        #endregion
        #region Commands
        public Command RefreshCommand { get; set; }
        #endregion

    }
}
