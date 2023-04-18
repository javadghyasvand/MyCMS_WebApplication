using System.Linq;

namespace DataBase
{
    public class LoginAdmin:ILoginAdmin
    {
        private readonly MyCmsContext _cms;

        public LoginAdmin(MyCmsContext cmsContext)
        {
            _cms = cmsContext;
        }

        public bool IsExistUser(string username, string password)
        {
            return _cms.Logins.Any(u => u.UserName == username && u.Password == password);
        }
    }
}