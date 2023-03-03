using AutoMapper;
using NetBook.Core.DTOs;
using NetBook.Core.Entities;

namespace NetBook.Core.Mappings
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
