using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.ProsedureDtos;
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
        public async Task<IActionResult> GetProsedureList()
        {
            var value = await _prosedureRepository.GetAllAsync();
            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProsedure(CreateProsedureDto createProsedureDto)
        {
            _prosedureRepository.CreateProsedure(createProsedureDto);
            return Ok("Prosedure has been created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProsedure(UpdateProsedureDto updateProsedureDto)
        {
            _prosedureRepository.UpdateProsedure(updateProsedureDto);
            return Ok("Prosedure has been updated succesfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProsedureById(int id)
        {
            var value = await _prosedureRepository.GetProsedureById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProsedure(int id)
        {
            _prosedureRepository.DeleteProsedure(id);
            return Ok("Prosedure has been deleted successfully.");
        }
    }
}