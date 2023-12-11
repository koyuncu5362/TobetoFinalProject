using Application.Features.StreamVideos.Commands.Create;
using Application.Features.StreamVideos.Commands.Delete;
using Application.Features.StreamVideos.Commands.Update;
using Application.Features.StreamVideos.Queries.GetById;
using Application.Features.StreamVideos.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StreamVideosController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateStreamVideoCommand createStreamVideoCommand)
    {
        CreatedStreamVideoResponse response = await Mediator.Send(createStreamVideoCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateStreamVideoCommand updateStreamVideoCommand)
    {
        UpdatedStreamVideoResponse response = await Mediator.Send(updateStreamVideoCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedStreamVideoResponse response = await Mediator.Send(new DeleteStreamVideoCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdStreamVideoResponse response = await Mediator.Send(new GetByIdStreamVideoQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListStreamVideoQuery getListStreamVideoQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListStreamVideoListItemDto> response = await Mediator.Send(getListStreamVideoQuery);
        return Ok(response);
    }
}