using Application.Features.StreamVideos.Commands.Create;
using Application.Features.StreamVideos.Commands.Delete;
using Application.Features.StreamVideos.Commands.Update;
using Application.Features.StreamVideos.Queries.GetById;
using Application.Features.StreamVideos.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.StreamVideos.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<StreamVideo, CreateStreamVideoCommand>().ReverseMap();
        CreateMap<StreamVideo, CreatedStreamVideoResponse>().ReverseMap();
        CreateMap<StreamVideo, UpdateStreamVideoCommand>().ReverseMap();
        CreateMap<StreamVideo, UpdatedStreamVideoResponse>().ReverseMap();
        CreateMap<StreamVideo, DeleteStreamVideoCommand>().ReverseMap();
        CreateMap<StreamVideo, DeletedStreamVideoResponse>().ReverseMap();
        CreateMap<StreamVideo, GetByIdStreamVideoResponse>().ReverseMap();
        CreateMap<StreamVideo, GetListStreamVideoListItemDto>().ReverseMap();
        CreateMap<IPaginate<StreamVideo>, GetListResponse<GetListStreamVideoListItemDto>>().ReverseMap();
    }
}