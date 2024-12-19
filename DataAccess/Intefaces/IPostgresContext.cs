namespace DataAccess.Intefaces;

public interface IPostgresContext
{
    Task<T?> Get<T>(string query, object? parameters = null);
    Task<List<T>> Select<T>(string query, object? parameters = null);
    Task<bool> Exec(string query, object? parameters = null);
}