using Application.Features.Languages.Commands.AddLanguage;
using Application.Features.Languages.Commands.DeleteLanguage;
using Application.Features.Languages.Commands.UpdateLanguage;
using Application.Features.Languages.Queries.GetLanguageById;
using Application.Features.Languages.Queries.GetList;
using Core.Application.Requests;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LanguagesController : BaseController
    {
        [HttpPost("AddLanguage")]
        public async Task<IActionResult> AddLanguage([FromQuery] AddLanguageCommandRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok("Dil eklendi");
        }

        [HttpPost("DeleteLanguage")]
        public async Task<IActionResult> DeleteLanguage([FromQuery] DeleteLanguageCommandRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result.Result);
        }

        [HttpPost("UpdateLanguage")]
        public async Task<IActionResult> UpdateLanguage([FromQuery] UpdateLanguageCommandRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result.Result);
        }

        [HttpGet("GetLanguageList")]
        public async Task<IActionResult> GetLanguageList([FromQuery] PageRequest request)
        {
            var getListLanguageRequest = new GetListLanguageQueryRequest() { PageRequest = request };
            var result = await Mediator.Send(getListLanguageRequest);
            return Ok(result);
        }

        [HttpGet("GetLanguageByIdRequest")]
        public async Task<IActionResult> GetLanguageById([FromQuery] GetLanguageByIdRequest request)
        {
            var result = await Mediator.Send(request);
            return Ok(result);
        }

    }
}
