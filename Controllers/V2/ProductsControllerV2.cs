using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreAPI.DTO.V2;
using System.Text.Json;

namespace StoreAPI.Controllers.V2
{
    [ApiVersion("2.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    //[Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private const string _url = "https://fakestoreapi.com/products";
        private readonly HttpClient _httpClient;

        public ProductsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [MapToApiVersion("2.0")]
        [HttpGet(Name = "GetProductsData")]
        public async Task<IActionResult> GetProductsDataAsync()
        {
            _httpClient.DefaultRequestHeaders.Clear();

            var response = await _httpClient.GetStreamAsync(_url);
            var listPrducts = await JsonSerializer.DeserializeAsync<List<ProductV2>>(response);
            var productsData = new List<ProductV2ResponseData>();
            foreach(var value in listPrducts)
            {
                productsData.Add(new ProductV2ResponseData
                {
                    InternalId = value.InternalId.ToString(),
                    id = value.id,
                    title = value.title,
                    description = value.description,
                    category = value.category,
                    price = value.price,
                    image = value.image
                });

            }
            return Ok(productsData);
        }
    }
}

