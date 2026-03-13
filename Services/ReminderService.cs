using OccasionReminder.Models;
using Plugin.LocalNotification;

namespace OccasionReminder.Services
{
    public static class ReminderService
    {
        public static async Task ScheduleAsync(Occasion occasion)
        {
#if ANDROID || IOS

            if (occasion == null)
                return;

            var nextDate = new DateTime(
                DateTime.Now.Year,
                occasion.Date.Month,
                occasion.Date.Day,
                9, 0, 0);

            if (nextDate < DateTime.Now)
                nextDate = nextDate.AddYears(1);

            var request = new NotificationRequest
            {
                NotificationId = occasion.Id,
                Title = occasion.Type,
                Description = $"{occasion.Title} today!",
                Schedule = new NotificationRequestSchedule
                {
                    NotifyTime = nextDate
                }
            };

            await LocalNotificationCenter.Current.Show(request);

#endif
        }
    }
}