using Application.Features.Manufacturs.Commands.Create;
using Application.Features.Manufacturs.Commands.Delete;
using Application.Features.Manufacturs.Commands.Update;
using Application.Features.Manufacturs.Queries.GetById;
using Application.Features.Manufacturs.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.Manufacturs.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Manufactur, CreateManufacturCommand>().ReverseMap();
        CreateMap<Manufactur, CreatedManufacturResponse>().ReverseMap();
        CreateMap<Manufactur, UpdateManufacturCommand>().ReverseMap();
        CreateMap<Manufactur, UpdatedManufacturResponse>().ReverseMap();
        CreateMap<Manufactur, DeleteManufacturCommand>().ReverseMap();
        CreateMap<Manufactur, DeletedManufacturResponse>().ReverseMap();
        CreateMap<Manufactur, GetByIdManufacturResponse>().ReverseMap();
        CreateMap<Manufactur, GetListManufacturListItemDto>().ReverseMap();
        CreateMap<IPaginate<Manufactur>, GetListResponse<GetListManufacturListItemDto>>().ReverseMap();
    }
}