using AutoMapper;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;

namespace DotBook.Core.Mappings
{
    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<Publication, PublicationDTO>()
                .ForMember(dto => dto.Content, opt => opt.MapFrom(src => src.Content))
                .ForMember(dto => dto.CreatedAt, opt => opt.MapFrom(src => src.CreatedAt))
                .ForMember(dto => dto.Username, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dto => dto.Comments, opt => opt.MapFrom(src => src.Comments)); ;
        }
    }
}
