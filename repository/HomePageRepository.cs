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
    public class HomePageRepository: IHomePageRepository
    {
        private readonly IDbContext dbContext;
        public HomePageRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<Home> GetAllHomePage()
        {

            IEnumerable<Home> result = dbContext.Connection.Query<Home>("HOME_Package.GetAllHOME", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateHomePage(Home home)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@HOMEIMAGE1", home.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEIMAGE2", home.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMELOGO", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER1", home.Slider1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER2", home.Slider2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER3", home.Slider3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEIMAGE3", home.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEDESCRIPTION", home.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMETEXT", home.text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMETEXT2", home.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("HOME_Package.CreateHOME", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool UpdateHomePage(Home home)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)

            p.Add("@HId", home.HomeId, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEIMAGE1", home.Image1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEIMAGE2", home.Image2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMELOGO", home.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER1", home.Slider1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER2", home.Slider2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMESLIDER3", home.Slider3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEIMAGE3", home.Image3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMEDESCRIPTION", home.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMETEXT", home.text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@HOMETEXT2", home.text2, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("HOME_Package.UpdateHOME", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public bool DeleteHomePage(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@HId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("HOME_Package.DeleteHOME", p, commandType: CommandType.StoredProcedure);
            return true;
        }


    }
}
