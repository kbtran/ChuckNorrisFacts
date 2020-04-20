using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisFacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FactsView : ContentView
    {
        public FactsView()
        {
            InitializeComponent();
        }

        private void GetFavoriteClicked(object sender, EventArgs e)
        {
        }

        private void GetFactClicked(object sender, EventArgs e)
        {
        }

        private void AddFavoriteClicked(object sender, EventArgs e)
        {
        }
    }
}