using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TalbatCore.Entites;

namespace TalbatRepository.Data
{
    public static class StoreDbSeed
    {
        public async static Task seedAsync(StoreDbContext dbContext) {

            if (dbContext.Set<ProductBrand>().Count() == 0) {
                var productBrands = File.ReadAllText("../TalbatRepository/Data/DataSeed/brands.json");
                var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrands);

                if (brands?.Count() > 0)
                {
                    foreach (var brand in brands)
                    {

                        dbContext.Set<ProductBrand>().Add(brand);
                    }
                    await dbContext.SaveChangesAsync();
                }


            }

            if (dbContext.Set<ProductCategory>().Count() == 0)
            {
                var productCategory = File.ReadAllText("../TalbatRepository/Data/DataSeed/categories.json");
                var categories = JsonSerializer.Deserialize<List<ProductCategory>>(productCategory);

                if (categories?.Count() > 0)
                {
                    foreach (var category in categories)
                    {

                        dbContext.Set<ProductCategory>().Add(category);
                    }
                    await dbContext.SaveChangesAsync();
                }


            }

            if (dbContext.Set<Product>().Count() == 0)
            {
                var products = File.ReadAllText("../TalbatRepository/Data/DataSeed/products.json");
                var products01 = JsonSerializer.Deserialize<List<Product>>(products);

                if (products01?.Count() > 0)
                {
                    foreach (var product in products01)
                    {

                        dbContext.Set<Product>().Add(product);
                    }
                    await dbContext.SaveChangesAsync();
                }


            }

        }
    }
}
