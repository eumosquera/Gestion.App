using System;
using System.Collections.Generic;
using System.Text;
using Gestion.App.DTOs;
using Gestion.App.Views.Forms;
using Xamarin.Forms;

namespace Gestion.App.ViewsModels.Forms
{
    public class RequestItemViewModel : RequestsDTO
    {
        #region Methods
        async void OnItemClicked()
        {
            await Application.Current.MainPage.DisplayAlert("Notify","$Select {this.RequestID}","Ok");
            RequestDetailPage detailPage = new RequestDetailPage();
            detailPage.BindingContext = new RequestDetailViewModel(this);
            await Application.Current.MainPage.Navigation.PushAsync(detailPage);

        }

        public RequestItemViewModel()
        {
            this.OnItemClickedCommand = new Command(OnItemClicked);
        }
        #endregion
        public Command OnItemClickedCommand { get; set; }
    }
}
