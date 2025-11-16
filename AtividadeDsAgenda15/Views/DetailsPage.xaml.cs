using AtividadeDsAgenda15.Model;

namespace AtividadeDsAgenda15.Views;

public partial class DetailsPage : ContentPage
{
	public DetailsPage(Event eventDetails)
	{
        InitializeComponent();
		BindingContext = eventDetails;
	}

    private async void Button_Clicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}