using System;
using System.Collections.Generic;
using Known.Admin.Entities;
using Known.Admin.Repositories;

namespace Known.Admin.Services
{
    public class UserService : AdminService<IUserRepository>
    {
        public UserService(Context context) : base(context)
        {
        }

        public Result<User> SignIn(string userName, string password)
        {
            var result = ValidateLogin(userName, password);
            if (!result.IsValid)
                return Result.Error<User>(result.Message);

            var user = result.Data;
            user.Token = Utils.NewGuid;
            if (!user.FirstLoginTime.HasValue)
                user.FirstLoginTime = DateTime.Now;
            user.LastLoginTime = DateTime.Now;
            Repository.Save(user);

            return Result.Success("登录成功！", user);
        }

        public Result SignOut(string userName)
        {
            var user = GetUser(userName);
            if (user == null)
                return Result.Error("用户名不存在！");

            user.Token = string.Empty;
            Repository.Save(user);

            return Result.Success("注销成功！");
        }

        public Result<User> ValidateLogin(string userName, string password)
        {
            var user = GetUser(userName);
            if (user == null)
                return Result.Error<User>("用户名不存在！");

            if (user.Password != password)
                return Result.Error<User>("用户密码不正确！");

            return Result.Success("登录成功！", user);
        }

        public User GetUser(string userName)
        {
            return Repository.GetUser(userName);
        }

        public List<Module> GetUserModules(string userName)
        {
            //var path = Path.Combine(HttpRuntime.AppDomainAppPath, "menu.json");
            //var json = File.ReadAllText(path);
            //return ApiResult.Success(json.FromJson<object>());

            return Repository.GetUserModules(userName);
        }
    }
}
