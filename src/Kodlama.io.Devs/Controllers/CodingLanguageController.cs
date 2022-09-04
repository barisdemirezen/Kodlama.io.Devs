using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Models;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetListCodingLanguage;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodingLanguageController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetCodingLanguageListAsync([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListCodingLanguageQuery { PageRequest = pageRequest });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateCodingLanguageCommand createCodingLanguageCommand)
        {
            CreatedCodingLanguageDto createdCodingLanguageDto = await Mediator.Send(createCodingLanguageCommand);
            return Created("", createdCodingLanguageDto);
        }
    }
}
