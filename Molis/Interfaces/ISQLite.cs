using System;
using SQLite;

namespace Molis.Interfaces
{
    public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
