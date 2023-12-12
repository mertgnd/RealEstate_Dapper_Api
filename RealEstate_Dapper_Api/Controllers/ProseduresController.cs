using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Repositories.ProsedureRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProseduresController : ControllerBase
    {
        private readonly IProsedureRepository _prosedureRepository;

        public ProseduresController(IProsedureRepository prosedureRepository)
        {
            _prosedureRepository = prosedureRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProsedures()
        {
            var values = await _prosedureRepository.GetAllAsync();
            return Ok(values);
        }
    }
}