using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Contracts.Ads;
using Ward.Application.Contracts.UserMap;
using Ward.Application.Dtos.Common;
using Ward.Application.Feature.Ads.Requests;

namespace Ward.Application.Feature.Ads.Handlers
{
    public class UpdateStatusFeedbackGOVInforHandler : IRequestHandler<UpdateStatusFeedbackGOVInforRequest, BaseResponse<bool>>
    {
        private readonly IAdsRepository _adsRepository;
        private readonly IUserMapAds _userMapAds;
        public UpdateStatusFeedbackGOVInforHandler(IAdsRepository adsRepository, IUserMapAds userMapAds)
        {
            _adsRepository = adsRepository;
            _userMapAds = userMapAds;
        }
        public async Task<BaseResponse<bool>> Handle(UpdateStatusFeedbackGOVInforRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<bool> rs = new();
            var ads = await _adsRepository.GetAdsById(request.StatusFeedbackDto.Id);
            try
            {
                if (ads == null)
                {
                    return new BaseResponse<bool> { IsError = true, Status = 400, ErrorMessage = "AdsId not found in database" };
                }
                ads.Feedback = request.StatusFeedbackDto.Comment;
                ads.Status = request.StatusFeedbackDto.Status;
                await _adsRepository.Update(ads);
                await _adsRepository.SaveChange();
                await _userMapAds.UpdateStatusUserMap(request.StatusFeedbackDto);
                rs.Data = true;
            }
            catch (Exception ex)
            {
                rs.IsError = true;
                rs.Data = false;
                rs.ErrorMessage = ex.Message;

            }
            return rs;
        }
    }
}
