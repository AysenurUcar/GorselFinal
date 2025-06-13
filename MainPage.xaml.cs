
using GorselFinal.Modeller;

namespace GorselFinal
{
    public partial class MainPage : ContentPage
    {


        public MainPage()
        {
            InitializeComponent();
        }

        private void EkranGoster(object sender, EventArgs e)
        {
            if (loginStack.IsVisible)
            {
                loginStack.IsVisible = false;
                registerStack.IsVisible = true;
            }
            else
            {
                loginStack.IsVisible = true;
                registerStack.IsVisible = false;
            }
        }

        private async void RegisterClicked(object sender, EventArgs e)
        {
            var user = await FirebaseServices.Register(txtNickname.Text, txtRegisterEmail.Text, txtRegisterPassword.Text);
            if (user != null)
            {

                if (Application.Current.MainPage is AppShell shell)
                {
                    shell.SetFlyoutBehavior(FlyoutBehavior.Flyout);
                    shell.OpenFlyout();
                }

                await DisplayAlert("Başarılı", $"Uygulamaya Hoş Geldin {user.Info.DisplayName}", "OK");

                await Shell.Current.GoToAsync("//Home");

            }
            else
            {
                await DisplayAlert("Hata", "Kayıt Başarısız", "OK");
            }
        }

        private async void LoginClicked(object sender, EventArgs e)
        {
            var user = await FirebaseServices.Login(txtEmail.Text, txtPassword.Text);
            if (user != null)
            {
                if (Application.Current.MainPage is AppShell shell)
                {
                    shell.SetFlyoutBehavior(FlyoutBehavior.Flyout);
                    shell.OpenFlyout();
                }

                await DisplayAlert("Başarılı", $"Uygulamaya Hoş Geldin {user.Info.DisplayName}", "OK");

                await Shell.Current.GoToAsync("//Home");


            }
            else
            {
                await DisplayAlert("Hata", "Kullanıcı Adı Veya Şifre Yanlış", "OK");
            }
        }
    }

}