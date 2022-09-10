using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.DeleteCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.UpdateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Models;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetByIdCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetListCodingLanguage;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByCodingLanguageIdFramework;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.Controllers
{
    [Route("coding-languages")]
    [ApiController]
    public class CodingLanguagesController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListCodingLanguageQuery { PageRequest = pageRequest });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await Mediator.Send(new GetByIdCodingLanguageQuery { Id = id });
            return Ok(response);
        }

        [HttpGet("{id}/frameworks")]
        public async Task<IActionResult> GetFrameworkByCodingLanguageIdAsync([FromQuery] PageRequest pageRequest, int id)
        {
            var response = await Mediator.Send(new GetByCodingLanguageIdFrameworkQuery { CodingLanguageId = id, PageRequest = pageRequest });
            return Ok(response);
        }


        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateCodingLanguageCommand createCodingLanguageCommand)
        {
            CreatedCodingLanguageDto createdCodingLanguageDto = await Mediator.Send(createCodingLanguageCommand);
            return Created("", createdCodingLanguageDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateCodingLanguageCommand updateCodingLanguageCommand )
        {
            updateCodingLanguageCommand.Id = id;
            UpdatedCodingLanguageDto updatedCodingLanguageDto = await Mediator.Send(updateCodingLanguageCommand);
            return Ok(updatedCodingLanguageDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DeleteCodingLanguageCommand deleteCodingLanguageCommand = new DeleteCodingLanguageCommand
            {
                Id = id
            };

            DeletedCodingLanguageDto deletedCodingLanguageDto = await Mediator.Send(deleteCodingLanguageCommand);
            return Ok(deletedCodingLanguageDto);
        }
    }
}
