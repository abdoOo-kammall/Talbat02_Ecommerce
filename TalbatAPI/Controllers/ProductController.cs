using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using TalbatAPI.Dtos;
using TalbatAPI.Errors;
using TalbatCore.Entites;
using TalbatCore.RepositoryContract;
using TalbatCore.Specifications;

namespace TalbatAPI.Controllers
{

    public class ProductController : BaseApiController
    {
        private readonly IGenericRepository<ProductCategory> _productGategoryRepo;
        private readonly IGenericRepository<Product> _productRepo;
        private readonly IGenericRepository<ProductBrand> _productBrandRepo;
        private readonly IMapper _mapper;

        public ProductController(IGenericRepository<ProductCategory> genericRepositoryProductGategory,IGenericRepository<Product> genericRepository , IGenericRepository<ProductBrand> genericRepositoryProductBrand , IMapper mapper)
        {
            _productGategoryRepo = genericRepositoryProductGategory;
            this._productRepo = genericRepository;
            this._productBrandRepo = genericRepositoryProductBrand;
            this._mapper = mapper;
        }


        [HttpGet]

        public async Task<ActionResult<IEnumerable<Product>>> getProducts([FromQuery] ProductSpecWithParams specWithParams) {

            var spec = new ProductWithBrandAndCategory(specWithParams);

            var products = await _productRepo.GetAllwithSpecAsync(spec);
            return Ok(_mapper.Map<IEnumerable<Product> , IEnumerable<ProductDto>>(products) );

        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> getProductById(int id ) { 
        
            var spec = new ProductWithBrandAndCategory(id);

            var product = await _productRepo.GetwithSpecAsync(spec);

            if (product == null) { return NotFound(new ApiResponse(400));  }
            return Ok(_mapper.Map<Product , ProductDto>(product));
        }

       
       
    }
}
