namespace BankApp.IServices
{
    public interface ISerializer<T>
    {
        void Serialize(T obj, string path);
        List<T?> DeserializeToList(string path);
    }
}