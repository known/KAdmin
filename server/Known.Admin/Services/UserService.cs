using Known.Admin.Repositories;

namespace Known.Admin.Services
{
    public class UserService : AdminService<IUserRepository>
    {
        public UserService(Context context) : base(context)
        {
        }
    }
}
