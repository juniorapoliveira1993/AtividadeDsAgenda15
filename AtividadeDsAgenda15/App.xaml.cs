
using Location = AtividadeDsAgenda15.Model.Location;

namespace AtividadeDsAgenda15
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

           
        }

        protected override Window CreateWindow(IActivationState? activationState)
        {
            Views.Register mainPage = new();
            Window window = new(new NavigationPage(mainPage));
            window.Width = 396;
            window.Height = 704;
            window.X = 1368 - 400;
            window.Y = 20;
            return window;
        }
    }
}