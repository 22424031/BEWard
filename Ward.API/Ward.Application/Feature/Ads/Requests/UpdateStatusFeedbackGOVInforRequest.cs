using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ward.Application.Dtos;
using Ward.Application.Dtos.Common;

namespace Ward.Application.Feature.Ads.Requests
{
    public class UpdateStatusFeedbackGOVInforRequest : IRequest<BaseResponse<bool>>
    {
        public StatusFeedbackDto StatusFeedbackDto { get; set; }
    }
}
