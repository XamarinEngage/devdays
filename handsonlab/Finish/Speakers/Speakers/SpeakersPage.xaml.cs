using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Speakers
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SpeakersPage : ContentPage
    {
        public SpeakersPage()
        {
            InitializeComponent();
        }

        private async void SyncbuttonCLicked(object sender, EventArgs e)
        {
            ObservableCollection<Speaker> speakers = await GetSpeakers();
            SpeakersList.ItemsSource = speakers;
        }

        private async void SpeakersList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var speaker = e.SelectedItem as Speaker;
            if (speaker == null)
                return;

            await Navigation.PushAsync(new SpeakersDetail(speaker));
            SpeakersList.SelectedItem = null;
        }

        async Task<ObservableCollection<Speaker>> GetSpeakers()
        {
            var speakers = new ObservableCollection<Speaker>();
            try
            {
                Loader.IsVisible = true;
                Loader.IsRunning = true;

                var service = new AzureService();
                var items = await service.GetSpeakers();

                speakers.Clear();
                foreach (var item in items)
                    speakers.Add(item);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {
                Loader.IsVisible = false;
                Loader.IsRunning = false;
            }

            return speakers;
        }

        private async void MenuItem_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AddSpeakerPage(new Speaker()));
        }

    }


}