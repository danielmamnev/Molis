using System;
using SQLite;

namespace Molis.Models
{
    public class PrayerItem
    {

        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Notes { get; set; }
        public string LastChecked { get; set; }
        public string ColorCategory { get; set; }

    }
}
