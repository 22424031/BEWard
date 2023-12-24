using Microsoft.Extensions.Configuration;
using Ward.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ward;
using Ward.Application.Dtos.Ads;

namespace WardService
{
    public class WardAds : BaseClient,IWardAds
    {
        public WardAds(IConfiguration configuration) : base(configuration)
        {
        }

        public async Task<BaseResponse<bool>> PushToWard(AdsDto dto)
        {
            return await this.PostAsync("api/ward/ReceiveAds",dto);
        }
    }
}
