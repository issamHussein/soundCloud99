using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.DTO;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class SoundsService: ISoundsService
    {
        private readonly ISoundsRepository soundRepository;

        public SoundsService(ISoundsRepository _soundRepository)
        {
            soundRepository = _soundRepository;
        }

        public List<Sounds> GetAllSounds()
        {
            return soundRepository.GetAllSounds();
        }

        public bool CreateSounds(Sounds sounds)
        {
            return soundRepository.CreateSounds(sounds);
        }

        public bool UpdateSOUNDS(Sounds sounds)
        {
            return soundRepository.UpdateSOUNDS(sounds);

        }

        public bool DeleteSOUNDS(int id)
        {
            return soundRepository.DeleteSOUNDS(id);

        }

        public List<Sounds> GetBySOUNDName(string SoundName)
        {
            return soundRepository.GetBySOUNDName(SoundName);

        }
        public List<Sounds> GetByCATEGORYID(int id)

        {
            return soundRepository.GetByCATEGORYID(id);

        }


        public List<Top10SoundsDTO> GetTop10Sounds()
        {
            return soundRepository.GetTop10Sounds();
        }

        public Sounds GetBySOUNDId(int soundId)
        {
            return soundRepository.GetBySOUNDId(soundId);
        }

        public bool buySound(DownloadedSounds downloadedSounds)
        {
            return soundRepository.buySound(downloadedSounds);
        }




        public List<DownloadedSounds> Check(DownloadedSounds downloadedSounds)
        {
            return soundRepository.Check(downloadedSounds);
        }


        public List<Sounds> GetBySOUNDIdForAnguler(int soundId)
        {
            return soundRepository.GetBySOUNDIdForAnguler(soundId);
        }


        public List<RetriveSoundsUploadedByUserDTO> soundsUploadedByTheUser(int id)
        {
            return soundRepository.soundsUploadedByTheUser(id);
        }

        public bool uploadSound(UploadedSounds uploadedSounds)
        {
            return soundRepository.uploadSound(uploadedSounds);
        }



        public List<SoundDownloadedByTheUserDTO> SoundDownloadedByTheUser(int id)
        {
            return soundRepository.SoundDownloadedByTheUser(id);
        }





    }
}
