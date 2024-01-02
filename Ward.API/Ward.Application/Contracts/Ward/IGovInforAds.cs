using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos.Ads;

namespace Ward.Application.Contracts.Ward
{
    public interface IGovInforAds
    {
        Task<BaseResponse<bool>> PushToGovInfor(PushAdsGovInforDto dto);
    }
}
