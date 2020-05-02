using System;
using System.IO.Compression;
using System.Reflection;
using GreenPipes.Configurators;
using HistoryService.API.Infrastructure.Repositories;
using HistoryService.API.Infrastructure.Services;
using HistoryService.API.IntegrationEvents.Handlers;
using MassTransit;
using MassTransit.AspNetCoreIntegration;
using MassTransit.ExtensionsDependencyInjectionIntegration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using MongoDB.Bson.Serialization.Conventions;
using ServiceStack.Redis;

namespace HistoryService.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllowSpecificOrigins = "DefaulCors";


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(AllowSpecificOrigins,
                    builder =>
                    {
                        builder.WithOrigins(Configuration["CORS"])
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddControllers()
                        .AddNewtonsoftJson(
                options => options.UseMemberCasing());
            services.Configure<HistorySettings>(Configuration);

            //Compression
            services.AddResponseCompression(options =>
            {
                options.Providers.Add<BrotliCompressionProvider>();
            });

            services.Configure<BrotliCompressionProviderOptions>(options =>
            {
                options.Level = CompressionLevel.Fastest;
            });

            services.AddScoped<IRecordsService, RecordsService>();
            services.AddScoped<IRecordEventsService, RecordEventsService>();
            services.AddScoped<IRecordRepository, RecordRepository>();

            // Register the Swagger generator, defining one or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            // Para Utilizar los modelos comenzando con mayuscula para MondoDB
            var conventionPack = new ConventionPack { new CamelCaseElementNameConvention() };
            ConventionRegistry.Register("camelCase", conventionPack, t => true);

            // Consumer dependencies should be scoped
            //services.AddScoped<SomeConsumerDependency>();

            // local function to create the bus
            // IBusControl CreateBus(IServiceProvider serviceProvider)
            // {
            //     return Bus.Factory.CreateUsingRabbitMq(cfg =>
            //     {
            //         cfg.Host(Configuration["RABBITMQ_URI"]);

            //         cfg.ClearMessageDeserializers();

            //         cfg.UseRawJsonSerializer();

            //         cfg.ReceiveEndpoint("history-service", ep =>
            //         {
            //             ep.PrefetchCount = 16;

            //             ep.ConfigureConsumer<RecordCreatedIntegrationEventHandler>(serviceProvider);
            //         });
            //     });
            // }

            // // local function to configure consumers
            // void ConfigureMassTransit(IServiceCollectionConfigurator configurator)
            // {
            //     configurator.AddConsumer<RecordCreatedIntegrationEventHandler>();
            // }

            // configures MassTransit to integrate with the built-in dependency injection
            // services.AddMassTransit(CreateBus, ConfigureMassTransit);

            services.AddDistributedRedisCache(option =>
            {
                option.Configuration = Configuration["redis:connection"];
                option.ConfigurationOptions.Password = Configuration["redis:password"];
                option.InstanceName = "master";
            });

            services.AddScoped<IRedisClient>(s => new RedisClient(Configuration["redis:connection"], int.Parse(Configuration["redis:port"]), password: Configuration["redis:password"]));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(AllowSpecificOrigins);

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "History Service");
            });

        }

    }
}
