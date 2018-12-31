﻿using Known.Admin.Entities;
using Known.Data;

namespace Known.Admin.Repositories
{
    public interface IModuleRepository : IRepository
    {
        PagingResult QueryModules(PagingCriteria criteria);
    }

    internal class ModuleRepository : DbRepository, IModuleRepository
    {
        public ModuleRepository(Database database) : base(database)
        {
        }

        public PagingResult QueryModules(PagingCriteria criteria)
        {
            var sql = "select * from t_plt_modules where parent_id=@pid";

            var key = (string)criteria.Parameter.key;
            if (!string.IsNullOrWhiteSpace(key))
            {
                sql += " and (code like @key or name like @key)";
                criteria.Parameter.key = $"%{key}%";
            }

            return Database.QueryPage<Module>(sql, criteria);
        }
    }
}
