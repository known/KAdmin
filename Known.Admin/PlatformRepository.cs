using System.Collections.Generic;
using Known.Data;
using Known.Platform;

namespace Known.Admin
{
    public class PlatformRepository : DbRepository, IPlatformRepository
    {
        public PlatformRepository(Database database) : base(database)
        {
        }

        public string GetApiUrl(string apiId)
        {
            var apiUrl = string.Empty;
            if (apiId == "plt")
                apiUrl = "http://localhost:8089";

            return apiUrl;
        }

        public Dictionary<string, object> GetCodes()
        {
            return new Dictionary<string, object>();
        }

        public Module GetModule(string id)
        {
            var module = QueryById<Entities.Module>(id);
            return AutoMapper.MapTo<Module, Entities.Module>(module);
        }

        public List<Module> GetModules()
        {
            var modules = QueryList<Entities.Module>();
            return AutoMapper.MapToList<Module, Entities.Module>(modules);
        }

        public List<Module> GetUserModules(string userName)
        {
            var sql = "select * from t_plt_modules";
            var modules = Database.QueryList<Entities.Module>(sql);
            return AutoMapper.MapToList<Module, Entities.Module>(modules);
        }

        public User GetUser(string userName)
        {
            var sql = "select * from t_plt_users where user_name=@userName";
            var user = Database.Query<Entities.User>(sql, new { userName });
            return AutoMapper.MapTo<User, Entities.User>(user);
        }

        public void SaveUser(User user)
        {
            var entity = AutoMapper.MapTo<Entities.User, User>(user);
            Database.Update(entity);
        }
    }
}
