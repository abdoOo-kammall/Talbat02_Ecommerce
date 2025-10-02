using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TalbatAPI.Errors;
using TalbatCore.Entites;
using TalbatCore.RepositoryContract;

namespace TalbatAPI.Controllers
{
   
    public class GategoryController : BaseApiController
    {
        private readonly IGenericRepository<ProductCategory> _productGategoryRepo;

        public GategoryController(IGenericRepository<ProductCategory> genericRepository)
        {
            this._productGategoryRepo = genericRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductBrand>>> getAllProductBrand()
        {
            var productGategories = await _productGategoryRepo.GetAllAsync();
            return Ok(productGategories);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductBrand>> getBrandById(int id)
        {

            var productGategory = await _productGategoryRepo.GetAsync(id);
            if (productGategory == null)
                return NotFound(new ApiResponse(400, "Brand Not Found"));

            return Ok(productGategory   );

        }
    }
}
