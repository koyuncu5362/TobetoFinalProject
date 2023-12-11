using Application.Features.CourseRelations.Commands.Create;
using Application.Features.CourseRelations.Commands.Delete;
using Application.Features.CourseRelations.Commands.Update;
using Application.Features.CourseRelations.Queries.GetById;
using Application.Features.CourseRelations.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CourseRelationsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateCourseRelationCommand createCourseRelationCommand)
    {
        CreatedCourseRelationResponse response = await Mediator.Send(createCourseRelationCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateCourseRelationCommand updateCourseRelationCommand)
    {
        UpdatedCourseRelationResponse response = await Mediator.Send(updateCourseRelationCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedCourseRelationResponse response = await Mediator.Send(new DeleteCourseRelationCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdCourseRelationResponse response = await Mediator.Send(new GetByIdCourseRelationQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListCourseRelationQuery getListCourseRelationQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListCourseRelationListItemDto> response = await Mediator.Send(getListCourseRelationQuery);
        return Ok(response);
    }
}