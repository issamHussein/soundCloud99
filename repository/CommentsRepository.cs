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
   public class CommentsRepository : ICommentsRepository
    {
        private readonly IDbContext dbContext;
        public CommentsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        public List<CommentsDTO> GetAllComments(int id)
        {
            var p = new DynamicParameters();
            p.Add("@SID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<CommentsDTO>("COMMENT_PACKAGE.GetAllCOMMENT", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

    //    public async Task<List<StudentCourseDTO>> GetAllStudentCourseList()
    //    {
    //        var result = await dbContext.Connection.QueryAsync<StudentCourseDTO, Course, StudentCourseDTO>
    //        ("StudentCourse2", (studentCourseDTO, course) =>
    //        {
    //            studentCourseDTO.course = studentCourseDTO.course ?? new List<Course>(); //if course.books != null { course.books = course.books} else course.books = new List<Book>
    //                                                                                     // course.books = course.books != null ? course.books : new List<Book>()
    //            studentCourseDTO.course.Add(course);
    //            return studentCourseDTO;
    //        },
    //        splitOn: "Course_id",
    //        param: null,// p = null
    //        commandType: CommandType.StoredProcedure
    //        );
    //        //result
    //        // 1- OOp ==== OOP_Book
    //        //1- OOP ===== OOP_Book2
    //        //2-API ==== API_Book
    //        var finalresult = result.AsList<StudentCourseDTO>().GroupBy(p => p.SName).Select(Course =>
    //        {
    //            StudentCourseDTO studentCourseDTO = Course.First();


    //            studentCourseDTO.course = Course.Where(g => g.course.Any() && g.course.Count() > 0)
    //           .Select(p => p.course.Single()).GroupBy(Course => Course.Course_id).Select(Course => new Course
    //           {
    //               Course_id = Course.First().Course_id,
    //               Name = Course.First().Name
    //           }
    //           ).ToList();
    //            return studentCourseDTO;
    //        }).ToList();
    //        return finalresult;



    //    }
    //}



    public bool CreateComments(Comments comments)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@COMMENTTEXT", comments.text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@CSOUNDID", comments.SoundId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CUSERID", comments.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("COMMENT_PACKAGE.CreateCOMMENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }



        public bool UpdateComments(Comments comments)
        {

            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@COMId", comments.CommentId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            p.Add("@COMMENTTEXT", comments.text, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@PHONENUM", comments.SoundId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@DESCRIPTIN", comments.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("COMMENT_PACKAGE.UpdateCOMMENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public bool DeleteComments(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@COMId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("COMMENT_PACKAGE.DeleteCOMMENT", p, commandType: CommandType.StoredProcedure);
            return true;
        }

    }
}
