using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Molis.Models;
using SQLite;

namespace Molis.Data
{
    public class PrayerItemDatabase
    {
        static readonly Lazy<SQLiteAsyncConnection> lazyInitializer = new Lazy<SQLiteAsyncConnection>(() =>
        {
            return new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
        });

        static SQLiteAsyncConnection Database => lazyInitializer.Value;
        static bool initialized = false;

        public PrayerItemDatabase()
        {
            InitializeAsync().SafeFireAndForget(false);
        }

        async Task InitializeAsync()
        {
            if (!initialized)
            {
                if (!Database.TableMappings.Any(m => m.MappedType.Name == typeof(PrayerItem).Name))
                {
                    await Database.CreateTablesAsync(CreateFlags.None, typeof(PrayerItem)).ConfigureAwait(false);
                }
                initialized = true;
            }
        }

        public async Task<List<PrayerItem>> GetItemsAsync()
        {
            var list =  await Database.Table<PrayerItem>().OrderBy(i => i.LastChecked).ToListAsync();

            foreach (PrayerItem i in list)
            {
                var lastChecked = DateTime.Parse(i.LastChecked);
                int daysApart = (DateTime.Now - lastChecked).Days;
                
                if(daysApart > 3)
                {
                    i.ColorCategory = "Red";
                }
                else if(daysApart > 1 && daysApart < 3)
                {
                    i.ColorCategory = "Orange";
                }
                else if(daysApart < 1)
                {
                    i.ColorCategory = "Green";
                }

               
            }


            return list;
        }

        public Task<List<PrayerItem>> GetItemsNotDoneAsync()
        {
            return Database.QueryAsync<PrayerItem>("SELECT * From [PrayerItem] WHERE [Done] = 0");
            
        }

        public Task<PrayerItem> GetItemAsync(int id)
        {
            return Database.Table<PrayerItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PrayerItem item)
        {
            if (item.ID != 0)
            {
                return Database.UpdateAsync(item);
            }
            else
            {
                return Database.InsertAsync(item);
            }
        }


        public Task<int> DeleteItemAsync(PrayerItem item)
        {
            return Database.DeleteAsync(item);
        }

    }
}
