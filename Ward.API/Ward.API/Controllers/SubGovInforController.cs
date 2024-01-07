using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ward.Application.Dtos.Common;
using Ward.Application.Dtos;
using Ward.Application.Feature.Ads.Requests;
using Ward.Application.Feature.ReportWarms.Requests;
using MediatR;

namespace Ward.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubGovInforController : ControllerBase
    {
        private readonly IMediator _mediator;
        public SubGovInforController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpPost("StatusFeedback")]
        public async Task<ActionResult<BaseResponse<bool>>> StatusFeedback(StatusFeedbackDto feedbackDto)
        {
            var data = await _mediator.Send(new UpdateStatusFeedbackGOVInforRequest { StatusFeedbackDto = feedbackDto });
            return data;
        }
        //[HttpPost("StatusReportWarmFeedback")]
        //public async Task<ActionResult<BaseResponse<bool>>> StatusReportWarmFeedback(StatusFeedbackDto feedbackDto)
        //{
        //    var data = await _mediator.Send(new UpdateReportWarmStatusRequest { StatusFeedback = feedbackDto });
        //    return data;

        //}
    }
}
