using Application.Features.Missions.Commands.Create;
using Application.Features.Missions.Commands.Delete;
using Application.Features.Missions.Commands.Update;
using Application.Features.Missions.Queries.GetById;
using Application.Features.Missions.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MissionsController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateMissionCommand createMissionCommand)
    {
        CreatedMissionResponse response = await Mediator.Send(createMissionCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateMissionCommand updateMissionCommand)
    {
        UpdatedMissionResponse response = await Mediator.Send(updateMissionCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedMissionResponse response = await Mediator.Send(new DeleteMissionCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdMissionResponse response = await Mediator.Send(new GetByIdMissionQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListMissionQuery getListMissionQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListMissionListItemDto> response = await Mediator.Send(getListMissionQuery);
        return Ok(response);
    }
}