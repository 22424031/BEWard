using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.Ward;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.Application.Feature.Ads.Handlers
{
    public class PushAdsToGOVInforHandler : IRequestHandler<PushAdsToGOVInforRequest, BaseResponse<bool>>
    {
        private readonly IMapper _mapper;
        private readonly IGovInforAds _govInforAds;
        private readonly IAdsRepository _adsRepository;
        public PushAdsToGOVInforHandler(IMapper mapper, IGovInforAds govInforAds, IAdsRepository adsRepository)
        {
            _mapper = mapper;
            _govInforAds = govInforAds;
            _adsRepository = adsRepository;
        }
        public async Task<BaseResponse<bool>> Handle(PushAdsToGOVInforRequest request, CancellationToken cancellationToken)
        {
            var rs = new BaseResponse<bool>();
            try
            {
                var ads = await _adsRepository.GetAdsById(request.AdsId);
                if(ads == null)
                {
                    return new BaseResponse<bool>
                    {
                        IsError = true,
                        Status = 400,
                        ErrorMessage = "AdsId not found in database"
                    };
                }
                var dataPush = _mapper.Map<PushAdsGovInforDto>(ads);
                dataPush.Status = "Mới";
                await _govInforAds.PushToGovInfor(dataPush);
                rs.Data = true;
            }
            catch (Exception ex)
            {
                return new BaseResponse<bool>
                {
                    IsError = true,
                    ErrorMessage = ex.Message,
                    Status = 500
                };
            }
            return rs;
        }
    }
}
