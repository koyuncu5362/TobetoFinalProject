using Application.Features.Missions.Commands.Create;
using Application.Features.Missions.Commands.Delete;
using Application.Features.Missions.Commands.Update;
using Application.Features.Missions.Queries.GetById;
using Application.Features.Missions.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Missions.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Mission, CreateMissionCommand>().ReverseMap();
        CreateMap<Mission, CreatedMissionResponse>().ReverseMap();
        CreateMap<Mission, UpdateMissionCommand>().ReverseMap();
        CreateMap<Mission, UpdatedMissionResponse>().ReverseMap();
        CreateMap<Mission, DeleteMissionCommand>().ReverseMap();
        CreateMap<Mission, DeletedMissionResponse>().ReverseMap();
        CreateMap<Mission, GetByIdMissionResponse>().ReverseMap();
        CreateMap<Mission, GetListMissionListItemDto>().ReverseMap();
        CreateMap<IPaginate<Mission>, GetListResponse<GetListMissionListItemDto>>().ReverseMap();
    }
}