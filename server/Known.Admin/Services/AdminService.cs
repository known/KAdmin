using Known.Data;

namespace Known.Admin.Services
{
    public abstract class AdminService<TRepository> : ServiceBase<TRepository>
        where TRepository : IRepository
    {
        public AdminService(Context context) : base(context)
        {
        }
    }
}
