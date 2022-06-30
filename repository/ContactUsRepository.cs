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
    public class ContactUsRepository : IContactUsRepository
    {


        private readonly IDbContext dbContext;
        public ContactUsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }



        public bool CreateContactUs(ContactUs contactUs)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@FNAME", contactUs.FullName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CONTACTEMAIL", contactUs.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CONTACTMESSAGE", contactUs.Message, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CONTACTUS_Package.CreateCONTACTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteContactUs(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@CId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("CONTACTUS_Package.DeleteCONTACTUS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<ContactUs> GetAllContactUs()
        {
            IEnumerable<ContactUs> result = dbContext.Connection.Query<ContactUs>("CONTACTUS_Package.GetAllCONTACTUS", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
    }
}
