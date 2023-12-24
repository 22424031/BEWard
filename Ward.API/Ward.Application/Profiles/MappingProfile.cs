using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Newtonsoft.Json;
using Ward.Application.Dtos.Ads;
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
        }
    }
}
