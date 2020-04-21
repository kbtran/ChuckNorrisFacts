using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IdentityModel.Tokens.Jwt;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ChuckNorrisFacts
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginView : ContentView
    {
        public event EventHandler<string> LoginChanged;
        public LoginView()
        {
            InitializeComponent();
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            var loginProvider = DependencyService.Get<ILoginProvider>();
            var idToken = await loginProvider.LoginAsync();

            string userName = null;
            if (idToken != null)
            {
                var jwtHandler = new JwtSecurityTokenHandler();
                var token = jwtHandler.ReadJwtToken(idToken);
                userName = token.Claims.FirstOrDefault(c => c.Type == "preferred_username")?.Value;
            }

            if (LoginChanged != null) LoginChanged(this, userName);

            if (userName == null)
            {
                ErrorLabel.Text = "Login failed.";
                return;
            }

            LoginPanel.IsVisible = false;
            LogoutPanel.IsVisible = true;
            ErrorLabel.Text = "";
            LoggedInLabel.Text = "You are logged in as " + userName;
        }

        private void LogoutClicked(object sender, EventArgs e)
        {
            LoginPanel.IsVisible = true;
            LogoutPanel.IsVisible = false;
            if (LoginChanged != null) LoginChanged(this, null);
        }
    }

}