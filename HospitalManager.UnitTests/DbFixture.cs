using System;
using HospitalManager.Api.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.UnitTests
{
    public sealed class DbFixture : IDisposable
    {
        public AppDbContext Context {get;}

        public DbFixture()
        {
            var connection = new SqliteConnection("Data Source=:memory:");
            connection.Open();
            var options = new DbContextOptionsBuilder()
                .UseSqlite(connection).Options;
            Context = new AppDbContext(options);
        }

        public void Dispose()
        {
            Context?.Dispose();
        }
    }
}