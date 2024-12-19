namespace Core.Intefraces;

public interface ISettings
{
    string GetValue(string name);
    T GetValue<T>(string name);
}