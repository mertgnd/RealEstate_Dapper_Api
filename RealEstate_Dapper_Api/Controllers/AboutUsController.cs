using Microsoft.AspNetCore.Mvc;
using RealEstate_Dapper_Api.Dtos.AboutUsDtos;
using RealEstate_Dapper_Api.Dtos.CategoryDtos;
using RealEstate_Dapper_Api.Repositories.AboutUsRepositories;

namespace RealEstate_Dapper_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutUsController : ControllerBase
    {
        private readonly IAboutUsRepository _aboutUsRepository;

        public AboutUsController(IAboutUsRepository aboutUsRepository)
        {
            _aboutUsRepository = aboutUsRepository;
        }

        [HttpGet]
        public async Task<IActionResult> AboutUsList()
        {
            var values = await _aboutUsRepository.GetAllAboutUsAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAboutUs(CreateAboutUsDto createAboutUsDto)
        {
            _aboutUsRepository.CreateAboutUs(createAboutUsDto);
            return Ok("About Us has been created successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAboutUs(UpdateAboutUsDto updateAboutUsDto)
        {
            _aboutUsRepository.UpdateAboutUs(updateAboutUsDto);
            return Ok("About Us has been updated succesfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutUsById(int id)
        {
            var value = await _aboutUsRepository.GetAboutUsById(id);
            return Ok(value);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAboutUs(int id)
        {
            _aboutUsRepository.DeleteAboutUs(id);
            return Ok("About Us has been deleted successfully.");
        }
    }
}