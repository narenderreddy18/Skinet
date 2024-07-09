using API.Errors;
using Core.Interfaces;
using Infrastracture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class APPServicesExtensions
    {
        public static IServiceCollection AddAppServices(this IServiceCollection services, IConfiguration config)
        {
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            services.AddSwaggerGen();
            services.AddDbContext<SkinetContext>(opt =>
            {
                opt.UseSqlServer(config.GetConnectionString("SqlConnection"));
            });
            services.AddScoped<IProductsRepository, ProductsRepository>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.InvalidModelStateResponseFactory = actioncontext =>
                {
                    var errors = actioncontext.ModelState
                                    .Where(e => e.Value.Errors.Count() > 0)
                                    .SelectMany(x => x.Value.Errors)
                                    .Select(y => y.ErrorMessage).ToArray();

                    var errorresponse = new APIValidationErrorResponse
                    {
                        Errors = errors
                    };

                    return new BadRequestObjectResult(errorresponse);
                };
            });
            return services;
        }
    }
}
