using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Tahaluf.SoundCloud.Core.Common;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;

namespace Tahaluf.SoundCloud.Infra.Repository
{
    public class UsersRepository: IUsersRepository
    {



        private readonly IDbContext dbContext;
        public UsersRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<Users> GetAllUsers()
        {

            IEnumerable<Users> result = dbContext.Connection.Query<Users>("User_Package.GetAllUsers", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateUsers(Users user)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@UName", user.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UEmail", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Upassword", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UphoneNum", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@URoleID", user.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@image1", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("User_Package.CreateUsers", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateUsers(Users user)
        {

            var p = new DynamicParameters();
            p.Add("@UId", user.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UName", user.UserName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UEmail", user.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@Upassword", user.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@UphoneNum", user.PhoneNumber, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@URoleID", user.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@image1", user.Image, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.Connection.ExecuteAsync("User_Package.UpdateUsers", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteUsers(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@UId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("User_Package.DeleteUsers", p, commandType: CommandType.StoredProcedure);
            return true;
        }




        public List<Users> GetByUserName(string userName)
        {
            var p = new DynamicParameters();
            p.Add("@uname", userName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Users>("User_Package.GETuserBYNAME", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }





        public List<Users> GetByUserEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("@uEmail", email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Users>("User_Package.GETuserBYEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        public int GetIdByUserEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("@uEmail", email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<int>("User_Package.GETuserIDBYEmail", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }





        public LoginDTO auth(LoginDTO loginDTO)
        {
            var p = new DynamicParameters();
            p.Add("UEMAIL", loginDTO.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", loginDTO.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<LoginDTO> result = dbContext.Connection.Query<LoginDTO>("User_Package.User_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }






        public List<profitReportsDTO> GetProfitReport(DateTime dateFrom, DateTime dateTo, int userId )
        {
            var p = new DynamicParameters();
            p.Add("@DateFrom", dateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", dateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@Uid", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<profitReportsDTO>("report_Package.UserprofitReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<profitReportsDTO> GetSumProfitReport(DateTime dateFrom, DateTime dateTo, int userId)
        {
            var p = new DynamicParameters();
            p.Add("@DateFrom", dateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", dateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@Uid", userId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<profitReportsDTO>("report_Package.SumUserProfitReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



    }
}
