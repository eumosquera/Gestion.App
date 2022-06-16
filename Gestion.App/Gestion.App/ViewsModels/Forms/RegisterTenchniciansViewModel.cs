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
using Gestion.App.Views.Forms;
namespace Gestion.App.ViewsModels.Forms
{
    public class RegisterTenchniciansViewModel : BaseViewModel
    {
        #region Attributes
        private int _id_tecnico;
        private string _nombre_tecnico;
        private string _apellidos_tecnico;
        private string _email_tecnico;
        private string _nivel_tecnico;
        #endregion

        #region Propierties
        public int TechnicianID
        {
            get { return _id_tecnico; }
            set { this.SetValue(ref _id_tecnico, value); }
        }
        public string FirstName
        {
            get { return _nombre_tecnico; }
            set { this.SetValue(ref _nombre_tecnico, value); }
        }
        public string LastName
        {
            get { return _apellidos_tecnico; }
            set { this.SetValue(ref _apellidos_tecnico, value); }
        }
        public string Email
        {
            get { return _email_tecnico; }
            set { this.SetValue(ref _email_tecnico, value); }
        }
        public string Level
        {
            get { return _nivel_tecnico; }
            set { this.SetValue(ref _nivel_tecnico, value); }
        }
        #endregion

        #region Methods
        async void Register()
        {
            var data = new TechniciansDTO
            {
                TechnicianID = this.TechnicianID,
                FirtsName = this.FirstName,
                LastName = this.LastName,
                Email = this.Email,
                Level = this.Level
            };
            var json = JsonConvert.SerializeObject(data);
            var req = new StringContent(json, Encoding.UTF8, "application/json");
            var url = "https://62a2880ecc8c0118ef636563.mockapi.io/tecnicos";
            var result = string.Empty;

            using (var client = new HttpClient())
            {
                var response = await client.PostAsync(url, req);
                var statusCode = response.StatusCode;
                result = await response.Content.ReadAsStringAsync();

                if (response.IsSuccessStatusCode)
                {
                    var registerAnw = JsonConvert.DeserializeObject<TechniciansDTO>(result);
                    var id = registerAnw.TechnicianID;
                    var name = registerAnw.FirtsName;
                    var lastName = registerAnw.LastName;
                    await Application.Current.MainPage.DisplayAlert("Notify",$"{id + " "+ name + " "+ lastName}","Ok");

                    //redirect to TechniciaPage
                    await Application.Current.MainPage.Navigation.PushAsync(new TechniciansPage());

                }
                else
                {
                    var loginFail = JsonConvert.DeserializeObject<LogFail>(result);
                    var error = loginFail.Error;
                    await Application.Current.MainPage.DisplayAlert("Notify", error, "Aceptar");
                }
            }


        }

        #endregion

        #region Commands
        public Command RegisterCommand { get; set; }
        #endregion

        public RegisterTenchniciansViewModel()
        {
            this.RegisterCommand = new Command(Register);
        }

    }
}
