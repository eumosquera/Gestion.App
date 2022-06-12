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
using System.Linq;

namespace Gestion.App.ViewsModels.Forms
{
    public class TechnicianDetailViewModel : BaseViewModel
    {
        #region Attributes

        private ObservableCollection<RequestDTO> _solicitud;
        private bool _isRefreshing;
        private TechniciansDTO _technician;
        #endregion

        #region Properties
        public TechniciansDTO Technician
        {
            get { return _technician; }
            set { this.SetValue(ref _technician, value); }

        }

        public ObservableCollection<RequestDTO> Request
        {
            get { return _solicitud; }
            set { this.SetValue(ref _solicitud, value); }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }

        #endregion

        #region Methods

        async void GetRequest()
        {
            this._isRefreshing = true;

            var url = "https://62a2880ecc8c0118ef636563.mockapi.io/solicitud_servicio";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var request = JsonConvert.DeserializeObject<ObservableCollection<RequestDTO>>(result);
                    var requestFilter = request.Where(x => x.TechnicianID == _technician.TechnicianID).ToList();
                    this.Request = new ObservableCollection<RequestDTO>(requestFilter);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Notify", "Fail", "OK");
                }

            }
            this.IsRefreshing = false;

        }

        public TechnicianDetailViewModel(TechniciansDTO technicians)
        {
            this.Technician = technicians;
            this.RefreshCommand = new Command(GetRequest);
            this.RefreshCommand.Execute(null);

        }

        public TechnicianDetailViewModel()
        {

        }

        public Command RefreshCommand { get; set; }
        #endregion

    }
}
