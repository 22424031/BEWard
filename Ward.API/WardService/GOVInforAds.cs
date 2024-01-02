using Microsoft.Extensions.Configuration;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ward;
using Ward.Application.Dtos.Ads;

namespace GOVInforService
{
    public class GOVInforAds : BaseClient,IGovInforAds
    {
        public GOVInforAds(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<BaseResponse<bool>> PushToGovInfor(PushAdsGovInforDto dto)
        {
            return await this.PostAsync("api/Ads/ReceiveAds",dto);
        }
    }
}
