using Application.Dogs.GetBreeds;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[Route("api/v1/dogs")]
public sealed class DogsController(ISender sender) : ControllerBase
{
    private readonly ISender _sender = sender;

    [HttpGet("breeds", Name = "GetDogsBreeds")]
    [ProducesResponseType<IEnumerable<Breed>>(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetDogsBreedsAsync(
        [FromQuery] GetBreedsQueryData queryData,
        CancellationToken cancellationToken)
        => Ok(await _sender.Send(new GetBreedsQuery(queryData, cancellationToken)
            , cancellationToken));
}
