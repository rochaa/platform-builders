using Microsoft.AspNetCore.Mvc;
using PBuilders.WebAPI.Models;
using PBuilders.Domain.Palindrome;

namespace PBuilders.WebAPI.Controllers
{
    [ApiController]
    [Route("v1/palindrome")]
    public class PalindromeController : ControllerBase
    {
        [Route("check")]
        [HttpPost]
        public ActionResult CheckPost([FromBody] IsPalindromeModelRequest model)
        {
            var isPalidrome = PalindromeService.IsPalidrome(model.Word);

            return Ok(new IsPalindromeModelResponse(model.Word, isPalidrome));
        }
    }
}