using OccasionReminder.Models;
using OccasionReminder.Services;

namespace OccasionReminder.Pages;

public partial class AddOccasionPage : ContentPage
{
    DatabaseService db = new DatabaseService();

    public AddOccasionPage()
    {
        InitializeComponent();
    }

    async void SaveClicked(object sender, EventArgs e)
    {
        await db.Init();

        var occasion = new Occasion
        {
            Title = titleEntry.Text,
            Type = typePicker.SelectedItem?.ToString(),
            Date = datePicker.Date ?? DateTime.Now
        };

        await db.AddAsync(occasion);

        await ReminderService.ScheduleAsync(occasion);

        await DisplayAlert("Saved", "Occasion added successfully", "OK");

        await Navigation.PopAsync();
    }
}