using Application.Features.Videos.Commands.Create;
using Application.Features.Videos.Commands.Delete;
using Application.Features.Videos.Commands.Update;
using Application.Features.Videos.Queries.GetById;
using Application.Features.Videos.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Videos.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Video, CreateVideoCommand>().ReverseMap();
        CreateMap<Video, CreatedVideoResponse>().ReverseMap();
        CreateMap<Video, UpdateVideoCommand>().ReverseMap();
        CreateMap<Video, UpdatedVideoResponse>().ReverseMap();
        CreateMap<Video, DeleteVideoCommand>().ReverseMap();
        CreateMap<Video, DeletedVideoResponse>().ReverseMap();
        CreateMap<Video, GetByIdVideoResponse>().ReverseMap();
        CreateMap<Video, GetListVideoListItemDto>().ReverseMap();
        CreateMap<IPaginate<Video>, GetListResponse<GetListVideoListItemDto>>().ReverseMap();
    }
}