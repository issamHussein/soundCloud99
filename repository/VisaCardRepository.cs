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
    public class VisaCardRepository: IVisaCardRepository
    {

        private readonly IDbContext dbContext;
        public VisaCardRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        public VisaCard CheckVisa(int VisaID, int CCV , string ExpireDate, string Expiredyear)
        {
            var p = new DynamicParameters(); 
            p.Add("@CId", VisaID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CCCV", CCV, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@EXP", ExpireDate, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@expy", Expiredyear, dbType: DbType.String, direction: ParameterDirection.Input);
            IEnumerable<VisaCard> result = dbContext.Connection.Query<VisaCard>("Visa_Package.CheckCard", p, commandType: CommandType.StoredProcedure);

            return result.SingleOrDefault();
            
        }




        public bool UpdateBalance(int VisaID, double Balance)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@VID", VisaID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@BAl", Balance, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Visa_Package.updateBalance", p, commandType: CommandType.StoredProcedure);
            return true;
        }
    }











    }

