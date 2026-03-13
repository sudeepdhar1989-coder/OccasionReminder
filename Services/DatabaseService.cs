using SQLite;
using OccasionReminder.Models;

namespace OccasionReminder.Services
{
    public class DatabaseService
    {
        SQLiteAsyncConnection db;

        public async Task Init()
        {
            if (db != null)
                return;

            var path = Path.Combine(FileSystem.AppDataDirectory, "occasions.db");

            db = new SQLiteAsyncConnection(path);

            await db.CreateTableAsync<Occasion>();
        }

        public Task<List<Occasion>> GetAllAsync()
        {
            return db.Table<Occasion>().ToListAsync();
        }

        public Task<int> AddAsync(Occasion item)
        {
            return db.InsertAsync(item);
        }

        public Task<int> DeleteAsync(Occasion item)
        {
            return db.DeleteAsync(item);
        }
    }
}