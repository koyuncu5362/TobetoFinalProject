using Application.Features.CourseRelations.Commands.Create;
using Application.Features.CourseRelations.Commands.Delete;
using Application.Features.CourseRelations.Commands.Update;
using Application.Features.CourseRelations.Queries.GetById;
using Application.Features.CourseRelations.Queries.GetList;
using AutoMapper;
using Core.Application.Responses;
using Domain.Entities;
using Core.Persistence.Paging;

namespace Application.Features.CourseRelations.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CourseRelation, CreateCourseRelationCommand>().ReverseMap();
        CreateMap<CourseRelation, CreatedCourseRelationResponse>().ReverseMap();
        CreateMap<CourseRelation, UpdateCourseRelationCommand>().ReverseMap();
        CreateMap<CourseRelation, UpdatedCourseRelationResponse>().ReverseMap();
        CreateMap<CourseRelation, DeleteCourseRelationCommand>().ReverseMap();
        CreateMap<CourseRelation, DeletedCourseRelationResponse>().ReverseMap();
        CreateMap<CourseRelation, GetByIdCourseRelationResponse>().ReverseMap();
        CreateMap<CourseRelation, GetListCourseRelationListItemDto>().ReverseMap();
        CreateMap<IPaginate<CourseRelation>, GetListResponse<GetListCourseRelationListItemDto>>().ReverseMap();
    }
}