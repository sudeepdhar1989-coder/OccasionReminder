using OccasionReminder.Models;
using OccasionReminder.Services;
using Plugin.LocalNotification;

namespace OccasionReminder.Pages;

public partial class UpcomingPage : ContentPage
{
    DatabaseService db = new DatabaseService();

    public UpcomingPage()
    {
        InitializeComponent();
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();

        await db.Init();

        list.ItemsSource = await db.GetAllAsync();
    }

    async void DeleteClicked(object sender, EventArgs e)
    {
        var button = sender as Button;

        if (button == null)
            return;

        var occasion = button.CommandParameter as Occasion;

        if (occasion == null)
            return;

        bool confirm = await DisplayAlert("Delete", "Delete this occasion?", "Yes", "No");

        if (!confirm)
            return;

        await db.DeleteAsync(occasion);

#if ANDROID || IOS
        // cancel scheduled notification
        LocalNotificationCenter.Current.Cancel(occasion.Id);
#endif

        list.ItemsSource = await db.GetAllAsync();
    }
}