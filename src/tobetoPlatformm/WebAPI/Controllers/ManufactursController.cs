using Application.Features.Manufacturs.Commands.Create;
using Application.Features.Manufacturs.Commands.Delete;
using Application.Features.Manufacturs.Commands.Update;
using Application.Features.Manufacturs.Queries.GetById;
using Application.Features.Manufacturs.Queries.GetList;
using Core.Application.Requests;
using Core.Application.Responses;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ManufactursController : BaseController
{
    [HttpPost]
    public async Task<IActionResult> Add([FromBody] CreateManufacturCommand createManufacturCommand)
    {
        CreatedManufacturResponse response = await Mediator.Send(createManufacturCommand);

        return Created(uri: "", response);
    }

    [HttpPut]
    public async Task<IActionResult> Update([FromBody] UpdateManufacturCommand updateManufacturCommand)
    {
        UpdatedManufacturResponse response = await Mediator.Send(updateManufacturCommand);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        DeletedManufacturResponse response = await Mediator.Send(new DeleteManufacturCommand { Id = id });

        return Ok(response);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] Guid id)
    {
        GetByIdManufacturResponse response = await Mediator.Send(new GetByIdManufacturQuery { Id = id });
        return Ok(response);
    }

    [HttpGet]
    public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest)
    {
        GetListManufacturQuery getListManufacturQuery = new() { PageRequest = pageRequest };
        GetListResponse<GetListManufacturListItemDto> response = await Mediator.Send(getListManufacturQuery);
        return Ok(response);
    }
}