using AutoMapper;
using NetBook.Core.DTOs;
using NetBook.Core.Entities;

namespace NetBook.Core.Mappings
{
    public class PublicationProfile : Profile
    {
        public PublicationProfile()
        {
            CreateMap<Publication, PublicationDTO>()
                .ForMember(dto => dto.Content, pb => pb.MapFrom(attr => attr.Content))
                .ForMember(dto => dto.CreatedAt, pb => pb.MapFrom(attr => attr.CreatedAt))
                .ForMember(dto => dto.Username, pb => pb.MapFrom(attr => attr.User.FirstName))
                .ForMember(dto => dto.Status, pb => pb.MapFrom(attr => attr.Status))
                .ForMember(dto => dto.Comments, pb => pb.MapFrom(attr => attr.Comments)); ;
        }
    }
}
