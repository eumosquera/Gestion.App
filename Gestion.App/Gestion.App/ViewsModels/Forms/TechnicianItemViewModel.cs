using System;
using System.Collections.Generic;
using System.Text;
using Gestion.App.DTOs;
using Gestion.App.Views.Forms;

using Xamarin.Forms;


namespace Gestion.App.ViewsModels.Forms
{
    public class TechnicianItemViewModel : TechniciansDTO
    {
        async void OnItemClicked()
        {

            await Application.Current.MainPage.DisplayAlert("Notify",$"Selected {this.FirtsName + " " + LastName}", "Ok");
            TechnicianDetailPage detailPage = new TechnicianDetailPage();
            detailPage.BindingContext = new TechnicianDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);
        }

        public Command OnItemClickedCommand { get; set; }

        public TechnicianItemViewModel()
        {
                this.OnItemClickedCommand = new Command(OnItemClicked);
        }
    }
}
