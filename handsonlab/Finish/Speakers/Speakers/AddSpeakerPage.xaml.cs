using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddSpeakerPage : ContentPage
    {
        private Speaker Speaker;
        public AddSpeakerPage(Speaker speaker)
        {
            InitializeComponent();
            Speaker = speaker;
            BindingContext = speaker;
        }


        private async void Button_OnClicked(object sender, EventArgs e)
        {
            await AddUser();
            await Navigation.PopAsync();
        }

        //Add a New User
        async Task AddUser()
        {
            try
            {
                Loader.IsVisible = true;
                Loader.IsRunning = true;
                var service = new AzureService();
                await service.AddSpeaker(Speaker);
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                Loader.IsVisible = false;
                Loader.IsRunning = false;
            }
        }
    }
}