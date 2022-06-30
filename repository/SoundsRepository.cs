using Dapper;
using NAudio.Wave;
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
    public class SoundsRepository: ISoundsRepository
    {
        private readonly IDbContext dbContext;
        public SoundsRepository(IDbContext _dbContext)
        {
            dbContext = _dbContext;
        }

        //select * frome cource

        public List<Sounds> GetAllSounds()
        {

            IEnumerable<Sounds> result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetAllSounds",commandType:CommandType.StoredProcedure);
            return result.ToList();
        }

        public bool CreateSounds(Sounds sounds)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SName", sounds.SoundName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundInterval", sounds.interval, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@CATID", sounds.CategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SOUNDIMAGE", sounds.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundDescription", sounds.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundPrice", sounds.price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@PDate", sounds.publishDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@song1", sounds.song, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Sounds_Package.CreateSounds", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool UpdateSOUNDS(Sounds sounds)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SID", sounds.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SName", sounds.SoundName, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundInterval", sounds.interval, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@CATID", sounds.CategoryID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@SOUNDIMAGE", sounds.Image, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundDescription", sounds.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("@SoundPrice", sounds.price, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("@PDate", sounds.publishDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("@song1", sounds.song, dbType: DbType.String, direction: ParameterDirection.Input);




            var result = dbContext.Connection.ExecuteAsync("Sounds_Package.UpdateSOUNDS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public bool DeleteSOUNDS(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Sounds_Package.DeleteSOUNDS", p, commandType: CommandType.StoredProcedure);
            return true;
        }

        public List<Sounds> GetBySOUNDName(string SoundName)
        {
            var p = new DynamicParameters();
            p.Add("@SName",SoundName, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetBySOUNDName", p,commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public List<Sounds> GetByCATEGORYID(int id)
        {
            var p = new DynamicParameters();
            p.Add("@CATID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Sounds> result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetByCATEGORYID",p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        //public List<Sounds> GetByPUBLISHDATE(Sounds sounds)
        //{
        //    var p = new DynamicParameters();
        //    p.Add("@DateFrom", sounds.CategoryID, dbType: DbType.String, direction: ParameterDirection.Input);
        //    IEnumerable<Sounds> result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetByCATEGORYID", commandType: CommandType.StoredProcedure);
        //    return result.ToList();
        //}


        public List<Top10SoundsDTO> GetTop10Sounds()
        {
            IEnumerable<Top10SoundsDTO> result = dbContext.Connection.Query<Top10SoundsDTO>("Sounds_Package.GetTop10Sounds", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Sounds GetBySOUNDId(int soundId)
        {
            var p = new DynamicParameters();
            p.Add("@Sid", soundId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetBySOUNDID", p, commandType: CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }



        public List<Sounds> GetBySOUNDIdForAnguler(int soundId)
        {
            var p = new DynamicParameters();
            p.Add("@Sid", soundId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<Sounds>("Sounds_Package.GetBySOUNDID", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public bool buySound(DownloadedSounds downloadedSounds)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SId", downloadedSounds.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UId", downloadedSounds.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@DateOfD", downloadedSounds.dateOfDownload, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("DownLoadedSounds_Package.buySound", p, commandType: CommandType.StoredProcedure);
            return true;
        }





        public List<DownloadedSounds> Check(DownloadedSounds downloadedSounds)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SId", downloadedSounds.SoundID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UId", downloadedSounds.UserID, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<DownloadedSounds>("DownLoadedSounds_Package.checkDownload", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


        public List<RetriveSoundsUploadedByUserDTO> soundsUploadedByTheUser(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@UId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<RetriveSoundsUploadedByUserDTO>("Uploaded_Package.soundsUploadedByTheUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }





        public bool uploadSound(UploadedSounds uploadedSounds)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@SId", uploadedSounds.SoundId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@UId", uploadedSounds.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("@DateOfU", uploadedSounds.UploadedDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            var result = dbContext.Connection.ExecuteAsync("Uploaded_Package.UploadedSound", p, commandType: CommandType.StoredProcedure);
            return true;
        }


        public List<SoundDownloadedByTheUserDTO> SoundDownloadedByTheUser(int id)
        {
            var p = new DynamicParameters(); // 1-Dapper 2- provide add method 3-enabling you to pass parameter to DBase (Stored Proc)
            p.Add("@UId", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = dbContext.Connection.Query<SoundDownloadedByTheUserDTO>("DownLoadedSounds_Package.soundsDownloadedByTheUser", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }


    }
}
