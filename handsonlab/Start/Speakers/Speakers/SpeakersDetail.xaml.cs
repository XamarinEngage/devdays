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
    public partial class SpeakersDetail : ContentPage
    {
        private Speaker speaker;
        public SpeakersDetail(Speaker item)
        {
            InitializeComponent();
            speaker = item;
            BindingContext = speaker;
        }
    }
}