using AtividadeDsAgenda15.Model;
using Location = AtividadeDsAgenda15.Model.Location;

namespace AtividadeDsAgenda15.Views;

public partial class Register : ContentPage
{
    
    public Register()
    {
        InitializeComponent();

        Location[] locations = new Location[]{ new("Citibank Hall", 25000, 7000), new("Arena Anhembi", 150000, 40000), new("Maracanã", 250000, 78000) };

        pck_local.ItemsSource = locations;
        pck_local.ItemDisplayBinding = new Binding("Name");
        pck_local.SelectedIndex = 0;

        dtp_start.MinimumDate = DateTime.Now;
        dtp_start.MaximumDate = DateTime.Now.AddMonths(3);

        DateTime tomorrow = DateTime.Now.AddDays(1);
        dtp_end.MinimumDate = tomorrow;
        dtp_end.MaximumDate = tomorrow.AddMonths(3);

    }

    private async void OpenEventDetails(object sender, EventArgs e)
    {
        string eventName = ent_name.Text;
        if (string.IsNullOrWhiteSpace(eventName)) {
           await DisplayAlertAsync("", "Informe o nome do evento", "ok");
            return;
        }


        DateTime startDate = dtp_start.Date.Value;
        DateTime endDate = dtp_end.Date.Value;
        double numberParticipants =  stp_number_participants.Value;
        double costParticipants =  stp_cost_participants.Value;
        Location location = (Location)pck_local.SelectedItem;

      await  Navigation.PushAsync(new Views.DetailsPage(new Model.Event(eventName,startDate, endDate, numberParticipants, costParticipants, location )));
    }

    private void dtp_start_DateSelected(object sender, DateChangedEventArgs e)
    {

        DateTime date = dtp_start.Date.Value.AddDays(1);
        dtp_end.MinimumDate = date;
        dtp_end.MaximumDate = date.AddMonths(3);

    }


    private void pck_local_SelectedIndexChanged(object sender, EventArgs e)
    {
        var picker = (Picker)sender;
        var selectedLocation = (Location)picker.SelectedItem;
        stp_number_participants.Value = 0;
        stp_number_participants.Maximum = selectedLocation.Capacity;
        stp_number_participants.Increment = selectedLocation.Capacity / 20;
    }
}