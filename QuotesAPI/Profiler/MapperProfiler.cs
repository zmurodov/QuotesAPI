using AutoMapper;
using QuotesAPI.Dtos;
using QuotesAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuotesAPI.Profiler
{
    public class MapperProfiler : Profile
    {
        public MapperProfiler()
        {
            //CreateMap<QuoteModel, QuoteDto>()
            //    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            //    .ForMember(dest => dest.Quote, opt => opt.MapFrom(src => src.Quote))
            //    .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category.Name))
            //    .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src.Author.Username));
        }
    }
}
