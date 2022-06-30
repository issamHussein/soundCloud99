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
    public class AdminRepository : IAdminRepository
    {

        private readonly IDbContext dbContext;
        public AdminRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<Admin> GetAllAdmin()
        {

            IEnumerable<Admin> result = dbContext.Connection.Query<Admin>("ADMIN_PACKAGE.GetAllADMIN", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateAdmin(Admin admin)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ADNAME", admin.AdminName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ADEMAIL", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ADROLEID", admin.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ADPASSWORD", admin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@AdminImage", admin.image, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("ADMIN_PACKAGE.CreateADMIN", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateAdmin(Admin admin)
        {

            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ADId", admin.AdminID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@ADNAME", admin.AdminName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ADEMAIL", admin.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ADROLEID", admin.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ADPASSWORD", admin.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@AdminImage", admin.image, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("ADMIN_PACKAGE.UpdateADMIN", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteAdmin(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ADId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ADMIN_PACKAGE.DeleteADMIN", p, commandType: CommandType.StoredProcedure);
            return true;
        }
        public List<Admin> GetByAdminEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("@AEmail", email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Admin>("ADMIN_PACKAGE.GETADMENBYEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public LoginDTO auth(LoginDTO loginDTO)
        {
            var p = new DynamicParameters();
            p.Add("UEMAIL", loginDTO.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", loginDTO.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<LoginDTO> result = dbContext.Connection.Query<LoginDTO>("ADMIN_PACKAGE.Admin_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }



    }
}
