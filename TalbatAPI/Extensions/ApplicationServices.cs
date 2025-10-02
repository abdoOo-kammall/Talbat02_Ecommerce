using Microsoft.AspNetCore.Mvc;
using TalbatAPI.Errors;
using TalbatAPI.Mapping;
using TalbatCore.RepositoryContract;
using TalbatRepository;

namespace TalbatAPI.Extensions
{
    public static class  ApplicationServices
    {
        public static IServiceCollection addApplicationServices(this IServiceCollection services) {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(typeof(TalbatMapping));
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = (actionContext) =>
                {

                    var errors = actionContext.ModelState.Where(p => p.Value.Errors.Count() > 0)
                                                         .SelectMany(p => p.Value.Errors)
                                                         .Select(p => p.ErrorMessage)
                                                         .ToList();

                    var validatationError = new ApiValidationErrorResponse()
                    {
                        Errors = errors
                    };
                    return new BadRequestObjectResult(validatationError);
                };

            });
            return services;
        }
    }
}
