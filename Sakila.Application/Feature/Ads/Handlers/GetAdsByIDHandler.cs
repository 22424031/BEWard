﻿using AutoMapper;
using MediatR;
using Sakila.Application.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserMap.Application.Contracts.Ads;
using UserMap.Application.Dtos.Ads;
using UserMap.Application.Feature.Ads.Requests;

namespace UserMap.Application.Feature.Ads.Handlers
{
    public class GetAdsByIDHandler : IRequestHandler<GetAdsByIDRequest, BaseResponse<AdsDto>>
    {
        private readonly IMapper _mapper;
        private readonly IAdsRepository _adsRepository;
        public GetAdsByIDHandler(IMapper mapper, IAdsRepository adsRepository)
        {
            _mapper = mapper;
            _adsRepository = adsRepository;
        }

        public async Task<BaseResponse<AdsDto>> Handle(GetAdsByIDRequest request, CancellationToken cancellationToken)
        {
            BaseResponse<AdsDto> rs = new();
            try
            {
                var data = await _adsRepository.Get(request.adsID);
                if (data == null)
                {
                    rs.Status = 204;
                    return rs;
                }
                rs.Data = _mapper.Map<AdsDto>(data);
            }
            catch(Exception ex)
            {
                rs.IsError = true;
                rs.ErrorMessage = ex.Message;
                rs.Status = 500;
            }
            return rs;
        }
    }
}
