using System;
using System.Data.Common;
using HospitalManager.Api.Data;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace HospitalManager.UnitTests
{
    public sealed class DbFixture : IDisposable
    {
        public AppDbContext Context {get;}
        private DbConnection Connection { get; set; }

        public DbFixture()
        {
        }

        public DbContextOptions CreateDbContextOptions()
        {
            Connection = new SqliteConnection("Data Source=:memory:");
            Connection.Open();
            var options = new DbContextOptionsBuilder()
                .UseSqlite(Connection).Options;

            return options;
        }

        public AppDbContext GetContext() => new(CreateDbContextOptions());

        public void Dispose()
        {
            Context?.Dispose();
            Connection?.Close();
        }
    }
}