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
        }

        async Task<ObservableCollection<Speaker>> GetSpeakers()
        {
            var speakers = new ObservableCollection<Speaker>();
            try
            {

            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error: " + ex);
                await Application.Current.MainPage.DisplayAlert("Error!", ex.Message, "OK");
            }
            finally
            {

            }

            return speakers;
        }

    }


}