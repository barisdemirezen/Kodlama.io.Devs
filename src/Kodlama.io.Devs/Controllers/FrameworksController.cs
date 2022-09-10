using Core.Application.Requests;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.CreateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.DeleteCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Commands.UpdateCodingLanguage;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Dtos;
using Kodlama.io.Devs.Application.Features.CodingLanguages.Queries.GetByIdCodingLanguage;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.CreateFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.DeleteFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Commands.UpdateFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Dtos;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByCodingLanguageIdFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetByIdFramework;
using Kodlama.io.Devs.Application.Features.Technologies.Queries.GetListFrameworkQuery;
using Microsoft.AspNetCore.Mvc;

namespace Kodlama.io.Devs.Controllers
{
    [Route("frameworks")]
    [ApiController]
    public class FrameworksController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] PageRequest pageRequest)
        {
            var response = await Mediator.Send(new GetListFrameworkQuery { PageRequest = pageRequest });
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var response = await Mediator.Send(new GetByIdFrameworkQuery { Id = id });
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync([FromBody] CreateFrameworkCommand createFrameworkCommand)
        {
            CreatedFrameworkDto createdFrameworkDto = await Mediator.Send(createFrameworkCommand);
            return Created("", createdFrameworkDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateFrameworkCommand updateFrameworkCommand )
        {
            updateFrameworkCommand.Id = id;
            UpdatedFrameworkDto updatedFrameworkDto = await Mediator.Send(updateFrameworkCommand);
            return Ok(updatedFrameworkDto);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            DeleteFrameworkCommand deleteFrameworkCommand = new DeleteFrameworkCommand
            {
                Id = id
            };

            DeletedFrameworkDto deletedFrameworkDto = await Mediator.Send(deleteFrameworkCommand);
            return Ok(deletedFrameworkDto);
        }
    }
}
