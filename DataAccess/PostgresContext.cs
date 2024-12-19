using System.Data;
using Core.Intefraces;
using Dapper;
using DataAccess.Intefaces;
using Npgsql;

namespace DataAccess;

public class PostgresContext(ISettings settings) : IPostgresContext
{
    private string ConnectionString => settings.GetValue("postgres:connectionString");

    public async Task<T?> Get<T>(string query, object? parameters = null)
    {
        using IDbConnection conn = new NpgsqlConnection(ConnectionString);
        return await conn.QueryFirstOrDefaultAsync<T>(query, parameters);
    }

    public async Task<List<T>> Select<T>(string query, object? parameters = null)
    {
        using IDbConnection conn = new NpgsqlConnection(ConnectionString);
        return (await conn.QueryAsync<T>(query, parameters)).ToList();
    }

    public async Task<bool> Exec(string query, object? parameters = null)
    {
        using IDbConnection conn = new NpgsqlConnection(ConnectionString);
        return await conn.ExecuteAsync(query, parameters) > 0;
    }
}