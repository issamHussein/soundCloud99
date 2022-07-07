using System;
using System.Collections.Generic;
using System.Text;
using Tahaluf.SoundCloud.Core.Data;
using Tahaluf.SoundCloud.Core.Repository;
using Tahaluf.SoundCloud.Core.Service;

namespace Tahaluf.SoundCloud.Infra.Service
{
    public class VisaCardService: IVisaCardService
    {


        private readonly IVisaCardRepository visaCardRepository;

        public VisaCardService(IVisaCardRepository _visaCardRepository)
        {
            visaCardRepository = _visaCardRepository;
        }

        public VisaCard CheckVisa(int VisaID, int CCV, string ExpireDate, string Expiredyear)
        {
            return visaCardRepository.CheckVisa(VisaID,CCV, ExpireDate, Expiredyear);
        }

        public bool UpdateBalance(int VisaID, double Balance)
        {
            return visaCardRepository.UpdateBalance(VisaID,Balance);
        }
    }
}
