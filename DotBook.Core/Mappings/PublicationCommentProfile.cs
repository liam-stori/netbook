using AutoMapper;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;

namespace DotBook.Core.Mappings
{
    public class PublicationCommentProfile : Profile
    {
        public PublicationCommentProfile()
        {
            CreateMap<PublicationComment, PublicationCommentDTO>()
                .ForMember(pcDTO => pcDTO.Content, pc => pc.MapFrom(attr => attr.Content))
                .ForMember(pcDTO => pcDTO.Username, pc => pc.MapFrom(attr => attr.User.FirstName));
        }
    }
}
