﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Ward.Application.Dtos.Ads;
using Ward.Application.Dtos.Reports;
using Ward.Domain;

namespace Ward.Application.Profiles
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Ads, AdsDto>().ForMember(x => x.UrlImages, opt => opt.MapFrom(y => y.UrlImagesJson)).AfterMap((src, des) =>
            {
                if (src.UrlImages is not null && src.UrlImages.Count > 0)
                {
                    des.UrlImages = JsonConvert.DeserializeObject<List<string>>(src.UrlImagesJson);
                }
            });
            CreateMap<CreateAdsDto, Ads>().ForMember(x => x.UrlImages, opt => opt.MapFrom(y => y.UrlImages)).AfterMap((src, des) =>
            {
                if(src.UrlImages is not null && src.UrlImages.Count > 0)
                {
                    des.UrlImagesJson = JsonConvert.SerializeObject(src.UrlImages);
                }
            });
            CreateMap<Ads, AdsDto>().ReverseMap();
            CreateMap<Ads, PushAdsGovInforDto>().ReverseMap();
            //ReportWarm
            CreateMap<CreateReportWarmDto, ReportWarm>().ForMember(x => x.UrlStringJson, opt => opt.MapFrom(y => y.UrlString)).AfterMap((src, des) =>
            {
               
                    des.UrlStringJson = JsonConvert.SerializeObject(src.UrlString);
                
            });
            CreateMap<ReportWarm, ReportWarmDto>().ForMember(x => x.UrlString, opt => opt.MapFrom(y => y.UrlStringJson)).AfterMap((src, des) =>
            {
                if (!string.IsNullOrWhiteSpace(src.UrlStringJson ) )
                {
                    des.UrlString = JsonConvert.DeserializeObject<List<string>>(src.UrlStringJson);
                }
            });
        }
    }
}
