using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.SoundCloud.Core.Common;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;

namespace Tahaluf.SoundCloud.Infra.Repository
{
    public class CategoryRepository: ICategoryRepository
    {
        private readonly IDbContext dbContext;
        public CategoryRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }
        public List<Category> GetAllCATEGORY()
        {

            IEnumerable<Category> result = dbContext.Connection.Query<Category>("CATEGORY_Package.GetAllCATEGORY", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public bool CreateCATEGORY(Category category)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@CName", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CATIMAGE", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);
  
            var result = dbContext.Connection.ExecuteAsync("CATEGORY_Package.CreateCATEGORY", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateCATEGORY(Category category)
        {
            var p = new DynamicParameters();
            // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@CID", category.CategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CName", category.CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CATIMAGE", category.Image, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("CATEGORY_Package.UpdateCATEGORY", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteCATEGORY(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@CID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CATEGORY_Package.DeleteCATEGORY", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public List<Category> GetByCATEGORYName(string CategoryName)
        {
            var p = new DynamicParameters();
            p.Add("CName", CategoryName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Category>("CATEGORY_Package.GetByCATEGORYName", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}
