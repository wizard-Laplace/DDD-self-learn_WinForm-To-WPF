using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Infrastructure.SQLite
{

    /// <summary>
    /// CommonConstから構文はコピーしてきてCommonConstは削除した
    /// </summary>
    internal class SQLiteHelper
    {
        internal const string ConnectionString = @"Data Source=C:\Users\宰\Desktop\C#_Udemy\DDD\DDD.db;Version=3;";

        internal static IReadOnlyList<T> Query<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity)
        {
            return Query<T>(sql, null, createEntity);
        }

        internal static IReadOnlyList<T> Query<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader,T> createEntity)
        {
            var result = new List<T>();
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(createEntity(reader));
                    }
                }
            }

            return result;
        }

        internal static T QuerySingle<T>(
            string sql,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            return QuerySingle<T>(sql, null, nullEntity);
        }

        internal static T QuerySingle<T>(
            string sql,
            SQLiteParameter[] parameters,
            Func<SQLiteDataReader, T> createEntity,
            T nullEntity)
        {
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        return createEntity(reader);
                    }
                }
            }

            return nullEntity;
        }

        internal static void Execute(
            string insert,
            string update,
            SQLiteParameter[] parameters)
        {
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(update, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }

                if(command.ExecuteNonQuery() < 1)
                {
                    command.CommandText = insert;
                    command.ExecuteNonQuery();
                }
            }
        }

        internal static void Execute(
            string sql,
            SQLiteParameter[] parameters)
        {
            using (var connection =
                new SQLiteConnection(SQLiteHelper.ConnectionString))
            using (var command = new SQLiteCommand(sql, connection))
            {
                connection.Open();

                if (parameters != null)
                {
                    command.Parameters.AddRange(parameters);
                }
                
                command.ExecuteNonQuery();
            }
        }
    }
}
