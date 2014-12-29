using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Web;
using UrlKatana.Business.Services.DataAccess;
using Dapper;
using System.IO;
using System.Web.Hosting;

namespace UrlKatana.WebApp.Infrastructure.Installers
{
    public class SqlLiteConnectionProvider : IConnectionProvider
    {
        static string DbFilePath
        {
            get
            {
                return string.Format("{0}UrlKatanaDb.sqlite", HostingEnvironment.ApplicationPhysicalPath); 
            }
        }

        public System.Data.IDbConnection GetConnection()
        {
            if (!File.Exists(DbFilePath))
            {
                CreateDatabase();
            }

            return GetSQLiteConnection();
        }

        private static SQLiteConnection GetSQLiteConnection()
        {
            var connectionString = string.Format("Data Source={0}", DbFilePath);
            return new SQLiteConnection(connectionString);
        }

        private static void CreateDatabase()
        {
            SQLiteConnection.CreateFile(DbFilePath); 
            using (var connection = GetSQLiteConnection())
            {
                connection.Open();
                connection.Execute(
                    @"create table TransformedUrl
                      (
                         Id         integer primary key autoincrement,
                         LongUrl    varchar(2000) not null
                      )");

                connection.Close();
            }
        }
    }
}