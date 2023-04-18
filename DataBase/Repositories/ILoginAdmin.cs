namespace DataBase
{
    public interface ILoginAdmin
    {
        bool IsExistUser(string username, string password);
    }
}