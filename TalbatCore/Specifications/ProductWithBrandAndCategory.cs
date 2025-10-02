using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TalbatCore.Entites;

namespace TalbatCore.Specifications
{
    public class ProductWithBrandAndCategory : Specification<Product> 
    {
        public ProductWithBrandAndCategory(ProductSpecWithParams specWithParams) :
            base(p => ((!specWithParams.BrandId.HasValue || p.BrandId == specWithParams.BrandId) ) && ((!specWithParams.GategoryId.HasValue || p.CategoryId == specWithParams.GategoryId)))
        {
            addIncludes();

            if (!String.IsNullOrEmpty(specWithParams.Sort)) {

                switch (specWithParams.Sort) {
                    case "priceAsc":
                        OrderBy = p => p.Price; break;
                    case "priceDesc":
                        OrderByDece = p => p.Price; break;
                    default:
                        OrderBy = p => p.Name; break;
                }
            }
            applyPagaination((specWithParams.PageIndex - 1) * specWithParams.PageSize, specWithParams.PageSize);

        }

    

        public ProductWithBrandAndCategory(int id) : base (p => p.Id == id)
        {
            addIncludes();

        }

        private void addIncludes()
        {
            Includes.Add(p => p.Brand);
            Includes.Add(p => p.Category);
        }
    }
}
