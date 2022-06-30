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
    public class AboutUsRepository: IAboutUsRepository
    {
        private readonly IDbContext dbContext;
        public AboutUsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<AboutUs> GetAllAboutUs()
        {

            IEnumerable<AboutUs> result = dbContext.Connection.Query<AboutUs>("ABOUTUS_Package.GetAllABOUTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateAboutUs(AboutUs aboutUs)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ABOUTIMAGE", aboutUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PHONENUM", aboutUs.PHONENUMBER, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DESCRIPTIN", aboutUs.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ABOUTEMAIL", aboutUs.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@aboutLocation", aboutUs.location, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ABOUTUS_Package.CreateABOUTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateAboutUs(AboutUs aboutUs)
        {

            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@AId", aboutUs.AboutusID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@ABOUTIMAGE", aboutUs.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PHONENUM", aboutUs.PHONENUMBER, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@DESCRIPTIN", aboutUs.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ABOUTEMAIL", aboutUs.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@aboutLocation", aboutUs.location, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ABOUTUS_Package.UpdateABOUTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteAboutUs(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@AId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ABOUTUS_Package.DeleteABOUTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }


    }
}
