using SQLite;

namespace OccasionReminder.Models
{
    public class Occasion
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Type { get; set; }

        public DateTime Date { get; set; }
    }
}