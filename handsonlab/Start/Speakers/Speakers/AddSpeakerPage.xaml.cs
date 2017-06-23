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


        //Add a New User
        async Task AddUser()
        {
            try
            {
               
            }
            catch (Exception ex)
            {
                await Application.Current.MainPage.DisplayAlert("Error", ex.Message, "OK");
            }
            finally
            {
                
            }
        }
    }
}