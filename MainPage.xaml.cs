using OccasionReminder.Pages;

namespace OccasionReminder;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    async void AddClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddOccasionPage());
    }

    async void ViewClicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new UpcomingPage());
    }
}