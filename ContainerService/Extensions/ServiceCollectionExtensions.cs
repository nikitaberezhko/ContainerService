using Asp.Versioning;
using FluentValidation;
using Infrastructure.Bus.Implementations;
using Infrastructure.Repositories.Implementations;
using Infrastructure.Settings;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using OpenTelemetry.Metrics;
using Persistence.EntityFramework;
using Services.Mapper;
using Services.Models.Request.Container;
using Services.Models.Request.Type;
using Services.Repositories.Interfaces;
using Services.Services.Implementations;
using Services.Services.Interfaces;
using Services.Validation.Container;
using Services.Validation.Container.Validators;
using Services.Validation.Type;
using Services.Validation.Type.Validators;
using WebApi.Mapper;
using ExceptionHandlerMiddleware = WebApi.Middlewares.ExceptionHandlerMiddleware;

namespace WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDataContext(this IServiceCollection services, 
        string connectionString)
    {
        services.AddDbContext<DataContext>(options =>
            options.UseNpgsql(connectionString));
        services.AddScoped<DbContext, DataContext>();
        
        return services;
    }
    
     public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();

        return services;
    }
    
    public static IServiceCollection AddValidation(this IServiceCollection services)
    {
        // Container
        services.AddScoped<IValidator<CreateContainerModel>, CreateContainerValidator>();
        services.AddScoped<IValidator<DeleteContainerModel>, DeleteContainerValidator>();
        services.AddScoped<IValidator<GetContainerByIdModel>, GetContainerByIdValidator>();
        services.AddScoped<IValidator<GetContainerByIsoModel>, GetContainerByIsoValidator>();
        services.AddScoped<IValidator<GetContainersByTypeIdModel>, GetContainersByTypeIdValidator>();
        services.AddScoped<IValidator<UpdateContainerModel>, UpdateContainerValidator>();

        services.AddScoped<ContainerValidator>();
        
        // Type
        services.AddScoped<IValidator<CreateTypeModel>, CreateTypeValidator>();
        services.AddScoped<IValidator<DeleteTypeModel>, DeleteTypeValidator>();
        services.AddScoped<IValidator<GetAllTypesModel>, GetAllTypesValidator>();
        services.AddScoped<IValidator<GetTypeByIdModel>, GetTypeByIdValidator>();
        services.AddScoped<IValidator<UpdateTypeModel>, UpdateTypeValidator>();

        services.AddScoped<TypeValidator>();
        

        return services;
    }
    
    public static IServiceCollection AddMappers(this IServiceCollection services)
    {
        services.AddAutoMapper(
            typeof(ServiceContainerMappingProfile),
            typeof(ServiceContainerTypeMappingProfile),
            typeof(ApiContainerMappingProfile),
            typeof(ApiTypeMappingProfile));
        
        return services;
    }
    
    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<IContainerService, Services.Services.Implementations.ContainerService>();
        services.AddScoped<ITypeService, TypeService>();
        
        return services;
    }
    
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IContainerRepository, ContainerRepository>();
        services.AddScoped<ITypeRepository, TypeRepository>();
        
        return services;
    }
    
    
    public static IServiceCollection AddVersioning(this IServiceCollection services)
    {
        services.AddApiVersioning(options =>
        {
            options.DefaultApiVersion = new ApiVersion(1);
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.ApiVersionReader = ApiVersionReader.Combine(
                new UrlSegmentApiVersionReader(),
                new HeaderApiVersionReader("X-Api-Version"));
        }).AddApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'V";
            options.SubstituteApiVersionInUrl = true;
        });

        return services;
    }
    
    public static IServiceCollection AddExceptionHandling(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerMiddleware>();
        
        return services;
    }
    
    public static IServiceCollection ConfigureMassTransit(this IServiceCollection services,
        IConfiguration configuration)
    {
        var rmqSettings = configuration.GetSection("RmqSettings").Get<RmqSettings>();
        
        services.AddMassTransit(options =>
        {
            options.AddConsumer<CreateOrderConsumer>();
            options.AddConsumer<UpdateOrderConsumer>();
            options.AddConsumer<DeleteOrderConsumer>();
            
            options.UsingRabbitMq((context, cfg) =>
            {
                cfg.Host(rmqSettings.Host, rmqSettings.Vhost, h =>
                {
                    h.Username(rmqSettings.Username);
                    h.Password(rmqSettings.Password);
                });

                cfg.ReceiveEndpoint("create-order", e =>
                {
                    e.ConfigureConsumer<CreateOrderConsumer>(context);
                    e.ExchangeType = "fanout";  
                });
                
                cfg.ReceiveEndpoint("update-order", e =>
                {
                    e.ConfigureConsumer<UpdateOrderConsumer>(context);
                    e.ExchangeType = "fanout";  
                });
                
                cfg.ReceiveEndpoint("delete-order", e =>
                {
                    e.ConfigureConsumer<DeleteOrderConsumer>(context);
                    e.ExchangeType = "fanout";  
                });
            });

        });
        
        return services;
    }
    
    public static IServiceCollection AddTelemetry(this IServiceCollection services)
    {
        services.AddOpenTelemetry()
            .WithMetrics(builder =>
            {
                builder.AddPrometheusExporter();

                builder.AddMeter("Microsoft.AspNetCore.Hosting",
                    "Microsoft.AspNetCore.Server.Kestrel");
                builder.AddView("http.server.request.duration",
                    new ExplicitBucketHistogramConfiguration
                    {
                        Boundaries = [ 0, 0.005, 0.01, 0.025, 0.05,
                            0.075, 0.1, 0.25, 0.5, 0.75, 1, 2.5, 5, 7.5, 10 ]
                    });
            });
        
        return services;
    }
}