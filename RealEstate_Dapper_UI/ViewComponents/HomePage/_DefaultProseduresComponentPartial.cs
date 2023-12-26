using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RealEstate_Dapper_UI.Dtos.ProseduresDtos;

namespace RealEstate_Dapper_UI.ViewComponents.HomePage
{
    public class _DefaultProseduresComponentPartial : ViewComponent
    {
        // Api Consume
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultProseduresComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            // Api Consume
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:44366/api/Prosedures");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProsedureDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}