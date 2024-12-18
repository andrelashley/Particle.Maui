using Particle.Maui.Pages;

namespace Particle.Maui
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ConfettiPage();
        }
    }
}
