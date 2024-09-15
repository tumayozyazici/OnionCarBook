
using FluentValidation.AspNetCore;
using OnionCarBook.Application.Features.CQRS.Handlers.AboutHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.BannerHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.BrandHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.CarHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.CategoryHandlers;
using OnionCarBook.Application.Features.CQRS.Handlers.ContactHandlers;
using OnionCarBook.Application.Features.CQRS.Results.CarResults;
using OnionCarBook.Application.Features.RepositoryPattern;
using OnionCarBook.Application.Interfaces;
using OnionCarBook.Application.Interfaces.BlogInterfaces;
using OnionCarBook.Application.Interfaces.CarDescriptionInterfaces;
using OnionCarBook.Application.Interfaces.CarFeatureInterfaces;
using OnionCarBook.Application.Interfaces.CarInterfaces;
using OnionCarBook.Application.Interfaces.CarPricingInterfaces;
using OnionCarBook.Application.Interfaces.RentACarInterfaces;
using OnionCarBook.Application.Interfaces.ReviewInterfaces;
using OnionCarBook.Application.Interfaces.StatisticInterfaces;
using OnionCarBook.Application.Interfaces.TagCloudInterfaces;
using OnionCarBook.Application.Services;
using OnionCarBook.Persistence.Context;
using OnionCarBook.Persistence.Repositories;
using OnionCarBook.Persistence.Repositories.BlogRepositories;
using OnionCarBook.Persistence.Repositories.CarDescriptionRepositories;
using OnionCarBook.Persistence.Repositories.CarFeatureRepositories;
using OnionCarBook.Persistence.Repositories.CarPricingRepositories;
using OnionCarBook.Persistence.Repositories.CarRepositories;
using OnionCarBook.Persistence.Repositories.CommentRepositories;
using OnionCarBook.Persistence.Repositories.RentACarRepositories;
using OnionCarBook.Persistence.Repositories.ReviewRepository;
using OnionCarBook.Persistence.Repositories.StatisticRepositories;
using OnionCarBook.Persistence.Repositories.TagCloudRepositories;
using System.Reflection;

namespace OnionCarBook.WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            //Context
            builder.Services.AddScoped<CarBookContext>();

            //Repository
            builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            builder.Services.AddScoped(typeof(ICarRepository),typeof(CarRepository));
            builder.Services.AddScoped(typeof(ICarFeatureRepository),typeof(CarFeatureRepository));
            builder.Services.AddScoped(typeof(IStatisticRepository),typeof(StatisticRepository));
            builder.Services.AddScoped(typeof(ICarDescriptionRepository),typeof(CarDescriptionRepository));
            builder.Services.AddScoped(typeof(IReviewRepository),typeof(ReviewRepository));
            builder.Services.AddScoped(typeof(IRentACarRepository),typeof(RentACarRepository));
            builder.Services.AddScoped(typeof(IBlogRepository),typeof(BlogRepository));
            builder.Services.AddScoped(typeof(ITagCloudRepository),typeof(TagCloudRepository));
            builder.Services.AddScoped(typeof(ICarPricingRepository),typeof(CarPricingRepository));
            builder.Services.AddScoped(typeof(IGenericRepository<>),typeof(CommentRepository<>));

            //Abouts
            builder.Services.AddScoped<GetAboutQueryHandler>();
            builder.Services.AddScoped<GetAboutByIdQueryHandler>();
            builder.Services.AddScoped<CreateAboutCommandHandler>();
            builder.Services.AddScoped<UpdateAboutCommandHandler>();
            builder.Services.AddScoped<RemoveAboutCommandHandler>();

            //Banners
            builder.Services.AddScoped<GetBannerQueryHandler>();
            builder.Services.AddScoped<GetBannerByIdQueryHandler>();
            builder.Services.AddScoped<CreateBannerCommandHandler>();
            builder.Services.AddScoped<UpdateBannerCommandHandler>();
            builder.Services.AddScoped<RemoveBannerCommandHandler>();

            //Brands
            builder.Services.AddScoped<GetBrandQueryHandler>();
            builder.Services.AddScoped<GetBrandByIdQueryHandler>();
            builder.Services.AddScoped<CreateBrandCommandHandler>();
            builder.Services.AddScoped<UpdateBrandCommandHandler>();
            builder.Services.AddScoped<RemoveBrandCommandHandler>();

            //Cars
            builder.Services.AddScoped<GetCarQueryHandler>();
            builder.Services.AddScoped<GetCarByIdQueryHandler>();
            builder.Services.AddScoped<CreateCarCommandHandler>();
            builder.Services.AddScoped<UpdateCarCommandHandler>();
            builder.Services.AddScoped<RemoveCarCommandHandler>();
            builder.Services.AddScoped<GetCarWithBrandQueryHandler>();
            builder.Services.AddScoped<GetLast5CarsWithBrandsQueryHandler>();

            //Categories
            builder.Services.AddScoped<GetCategoryQueryHandler>();
            builder.Services.AddScoped<GetCategoryByIdQueryHandler>();
            builder.Services.AddScoped<CreateCategoryCommandHandler>();
            builder.Services.AddScoped<UpdateCategoryCommandHandler>();
            builder.Services.AddScoped<RemoveCategoryCommandHandler>();

            //Contacts
            builder.Services.AddScoped<GetContactQueryHandler>();
            builder.Services.AddScoped<GetContactByIdQueryHandler>();
            builder.Services.AddScoped<CreateContactCommandHandler>();
            builder.Services.AddScoped<UpdateContactCommandHandler>();
            builder.Services.AddScoped<RemoveContactCommandHandler>();

            //MediatR
            builder.Services.AddApplicationService(builder.Configuration);

            //Fluent Validation
            builder.Services.AddControllers().AddFluentValidation(x =>
            {
                x.RegisterValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            });

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
