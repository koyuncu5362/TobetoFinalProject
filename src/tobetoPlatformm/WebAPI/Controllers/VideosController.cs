using Application.Features.Videos.Commands.Create;
using Application.Features.Videos.Commands.Delete;
using Application.Features.Videos.Commands.Update;
using Application.Features.Videos.Queries.GetById;
using Application.Features.Videos.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class VideosController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateVideoCommand createVideoCommand)
    {
        CreatedVideoResponse response = await Mediator.Send(createVideoCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateVideoCommand updateVideoCommand)
    {
        UpdatedVideoResponse response = await Mediator.Send(updateVideoCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedVideoResponse response = await Mediator.Send(new DeleteVideoCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdVideoResponse response = await Mediator.Send(new GetByIdVideoQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListVideoQuery getListVideoQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListVideoListItemDto> response = await Mediator.Send(getListVideoQuery);
        return Ok(response);
    }
}