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
    public class RequestDetailViewModel : BaseViewModel
    {
        #region Attributes
        private ObservableCollection<ComputersDTO> _computer;
        private bool _isRefreshing;
        private RequestsDTO _request;
        #endregion
       
        #region Properties
        public RequestsDTO Requests
        {
            get { return _request; }
            set { this.SetValue(ref _request, value); }

        }

        public ObservableCollection<ComputersDTO> Computer
        {
            get { return _computer; }
            set { this.SetValue(ref _computer, value); }
        }
        public bool IsRefreshing
        {
            get { return _isRefreshing; }
            set { this.SetValue(ref _isRefreshing, value); }
        }
        #endregion

        #region Methods

        async void GetComputer()
        {
            this.IsRefreshing = true;

            var url = "https://62a2880ecc8c0118ef636563.mockapi.io/Equipos";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.GetAsync(url);  
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var computer = JsonConvert.DeserializeObject<ObservableCollection<ComputersDTO>>(result);
                    var computerFilter = computer.Where(x => x.ComputerID == _request.ComputerID).ToList();
                    this.Computer = new ObservableCollection<ComputersDTO>(computerFilter);
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Notify", "Fail", "OK");
                }
            }
            this.IsRefreshing = false;

        }

        public RequestDetailViewModel( RequestsDTO request)
        {
            this.Requests = request;
            this.RefreshCommand = new Command(GetComputer);
            this.RefreshCommand.Execute(null);
        }
        public RequestDetailViewModel()
        {

        }
        public Command RefreshCommand { get; set; }
        #endregion


    }
}
