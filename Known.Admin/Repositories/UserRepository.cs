﻿using System.Collections.Generic;
using Known.Admin.Entities;
using Known.Data;

namespace Known.Admin.Repositories
{
    public interface IUserRepository : IRepository
    {
        User GetUser(string userName);
        List<Module> GetUserModules(string userName);
    }

    internal class UserRepository : DbRepository, IUserRepository
    {
        public UserRepository(Database database) : base(database)
        {
        }

        public User GetUser(string userName)
        {
            var sql = "select * from t_plt_users where user_name=@user_name";
            return Database.Query<User>(sql, new { user_name = userName });
        }

        public List<Module> GetUserModules(string userName)
        {
            var sql = "select * from t_plt_modules";
            return Database.QueryList<Module>(sql);
        }
    }
}
