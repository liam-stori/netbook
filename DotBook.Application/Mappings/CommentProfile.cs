using AutoMapper;
using DotBook.Core.DTOs;
using DotBook.Core.Entities;

namespace DotBook.Core.Mappings
{
    public class CommentProfile : Profile
    {
        public CommentProfile()
        {
            CreateMap<Comment, CommentDTO>()
                .ForMember(dto => dto.Content, pb => pb.MapFrom(attr => attr.Content))
                .ForMember(dto => dto.Username, pb => pb.MapFrom(attr => attr.User.FirstName))
                .ForMember(dto => dto.Status, pb => pb.MapFrom(attr => attr.Status));
        }
    }
}
