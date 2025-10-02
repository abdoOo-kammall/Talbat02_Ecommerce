using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalbatAPI.Errors;
using TalbatCore.Entites;
using TalbatCore.RepositoryContract;

namespace TalbatAPI.Controllers
{
   
    public class BrandController : BaseApiController
    {
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;

        public BrandController(IGenericRepository<ProductBrand> genericRepository)
        {
            this._productBrandRepo = genericRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> getAllProductBrand()
        {
            var productBrands = await _productBrandRepo.GetAllAsync();
            return Ok(productBrands);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> getBrandById(int id)
        {

            var productBrand = await _productBrandRepo.GetAsync(id);
            if (productBrand == null)
                return NotFound(new ApiResponse(400, "Brand Not Found"));

            return Ok(productBrand);

        }
    }
}
