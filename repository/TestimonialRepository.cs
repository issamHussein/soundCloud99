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
    public class TestimonialRepository: ITestimonialRepository
    {

        private readonly IDbContext dbContext;
        public TestimonialRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<TestimonialDTO> GetAllTestimonial()
        {

            IEnumerable<TestimonialDTO> result = dbContext.Connection.Query<TestimonialDTO>("TESTIMONIAL_PACKAGE.GetAllTESTIMONIAL", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@TESTIMONIALMASSAGE", testimonial.Message  , dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@adminAbrove1", testimonial.AdminAbrove, dbType: DbType.Int16, direction: ParameterDirection.Input);

            
            p.Add("@ACCID", testimonial.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
           


            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.CreateTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateTestimonial(AproveTestDTO testimonial)
        {

            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@testId", testimonial.TestimonialId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@adminAbrove1", testimonial.AdminAbrove, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.UpdateTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteTestimonial(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@testid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("TESTIMONIAL_PACKAGE.DeleteTESTIMONIAL", p, commandType: CommandType.StoredProcedure);
            return true;
        }



    }
}
