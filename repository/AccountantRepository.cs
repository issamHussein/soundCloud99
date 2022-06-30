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
    public class AccountantRepository: IAccountantRepository
    {


        private readonly IDbContext dbContext;
        public AccountantRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<Accountant> GetAllAccountants()
        {

            IEnumerable<Accountant> result = dbContext.Connection.Query<Accountant>("ACCOUNTANT_PACKAGE.GetAllACCOUNTANT", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateAccountant(Accountant accountant)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ACCNAME", accountant.AccountantName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ACCEMAIL", accountant.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ACCROLEID", accountant.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ACCSALARY", accountant.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@image1", accountant.Image, dbType: DbType.String, direction: ParameterDirection.Input);

            p.Add("@ACCPASSWORD", accountant.Password, dbType: DbType.String, direction: ParameterDirection.Input);



            var result = dbContext.Connection.ExecuteAsync("ACCOUNTANT_PACKAGE.CreateACCOUNTANT", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateAccountant(Accountant accountant)
        {

            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)


            p.Add("@ACCId", accountant.AccountantID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ACCNAME", accountant.AccountantName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ACCEMAIL", accountant.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@ACCROLEID", accountant.RoleID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@ACCSALARY", accountant.Salary, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@ACCPASSWORD", accountant.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@image1", accountant.Image, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.Connection.ExecuteAsync("ACCOUNTANT_PACKAGE.UpdateACCOUNTANT", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteAccountant(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@ACCId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("ACCOUNTANT_PACKAGE.DeleteACCOUNTANT", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public List<Accountant> GetByAccountantName(string accountantName)
        {
            var p = new DynamicParameters();
            p.Add("@ACCNAME", accountantName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Accountant>("ACCOUNTANT_PACKAGE.GETACCOUNTANTBYNAME", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }





        public LoginDTO auth(LoginDTO loginDTO)
        {
            var p = new DynamicParameters();
            p.Add("UEMAIL", loginDTO.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("PASS", loginDTO.Password, dbType: DbType.String, direction: ParameterDirection.Input);

            IEnumerable<LoginDTO> result = dbContext.Connection.Query<LoginDTO>("ACCOUNTANT_PACKAGE.Accountant_Login", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }








        public List<profitReportsDTO> GetProfitReport(DateTime dateFrom, DateTime dateTo)
        {
            var p = new DynamicParameters();
            p.Add("@DateFrom", dateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", dateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<profitReportsDTO>("report_Package.profitReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }




        public List<profitReportsDTO> GetSumProfitReport(DateTime dateFrom, DateTime dateTo)
        {
            var p = new DynamicParameters();
            p.Add("@DateFrom", dateFrom, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@DateTo", dateTo, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<profitReportsDTO>("report_Package.SumprofitReport", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        


        public List<LossesReportDTO> GetSalaryReport()
        {
            var result = dbContext.Connection.Query<LossesReportDTO>("report_Package.salaryReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public List<LossesReportDTO> GetSumSalaryReport()
        {
            var result = dbContext.Connection.Query<LossesReportDTO>("report_Package.lossesReport", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }



        public List<Accountant> GetByAccountantEmail(string email)
        {
            var p = new DynamicParameters();
            p.Add("@AEmail", email, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Accountant>("ACCOUNTANT_PACKAGE.GETAccountantBYEmail", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }






        public Accountant GetByAccountantID(int accId)
        {
            var p = new DynamicParameters();
            p.Add("@ACCID", accId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Accountant>("ACCOUNTANT_PACKAGE.GETACCOUNTANTBYID", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }








    }
}
