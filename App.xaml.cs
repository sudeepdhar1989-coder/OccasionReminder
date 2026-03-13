using OccasionReminder.Services;
using Plugin.LocalNotification;

namespace OccasionReminder;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        MainPage = new NavigationPage(new MainPage());
    }

    protected override async void OnStart()
    {
        base.OnStart();

#if ANDROID || IOS
        // Request notification permission
        await LocalNotificationCenter.Current.RequestNotificationPermission();
#endif

        // Load database and reschedule reminders
        var db = new DatabaseService();
        await db.Init();

        var occasions = await db.GetAllAsync();

        foreach (var item in occasions)
        {
            await ReminderService.ScheduleAsync(item);
        }
    }
}