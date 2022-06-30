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
    public class LikesRepository: ILikesRepository
    {
        private readonly IDbContext dbContext;
        public LikesRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }



        public List<AmtOfLikesDTO> GetAmountOfLikes()
        {
            //var p = new DynamicParameters();
            //p.Add("@Sid", soundId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<AmtOfLikesDTO> result = dbContext.Connection.Query<AmtOfLikesDTO>("Like_Package.GetLikeBySoundId", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool CreateLikes(Likes like)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@UID", like.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SID", like.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = dbContext.Connection.ExecuteAsync("Like_Package.CreateLike", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        
        public bool DeleteLike(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@Lid", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Like_Package.DeleteLike", p, commandType: CommandType.StoredProcedure);
            return false;
        }






        public Likes CheckLike(Likes like)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@sid", like.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UID", like.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Likes>("Like_Package.checkLike", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();


        }





    }
}


