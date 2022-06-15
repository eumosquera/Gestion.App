using Gestion.App.Views.Forms;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Gestion.App.ViewsModels.Forms
{
    internal class HomeViewModel
    {

        #region Navigation

        async void Technician()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new TechniciansPage());
        }

        async void Requests()
        {
            await Application.Current.MainPage.Navigation.PushAsync(new RequestsPage());
        }

        public Command TechnicianGoCommand { get; set; }
        public Command RequestsGoCommand { get; set; }


        public HomeViewModel()
        {
            this.TechnicianGoCommand = new Command(Technician);
            this.RequestsGoCommand = new Command(Requests);
        }
        #endregion
    }
}
