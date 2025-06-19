using AutoMappers;
using CryptoExchange.Net.Authentication;
using IWantKnowNet.Api.Extensions;
using IWantKnowNet.Data.Database;
using IWantKnowNet.Data.Entity;
using IWantToKnowNet.Common.Utils;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.Google;
using Microsoft.AspNetCore.Identity;
using Microsoft.OpenApi.Models;
using Serilog;
using Services.Emails;

namespace IWantKnowNet.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Start projects!");
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddHealthChecks();
            builder.Services.AddAuthorization();

            var configuration = builder.Configuration;
            string? connectionString;

            builder.Services
                .AddOptions<SettingsOptions>()
                .Bind(configuration.GetSection(SettingsOptions.ConfigurationSectionName))
                .ValidateDataAnnotations();

            builder.Services.AddApplicationInsightsTelemetry();

            connectionString = configuration["DefaultConnection"];

            builder.Services.AddDbContextSetting(connectionString!);

            builder.Services
                .AddIdentityApiEndpoints<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.Configure<CookieAuthenticationOptions>(
                IdentityConstants.ApplicationScheme,
                x => x.Cookie.SameSite = SameSiteMode.None);

            //builder.Services.AddAuthentication(options =>
            //    {
            //        options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            //        options.DefaultChallengeScheme = GoogleDefaults.AuthenticationScheme;
            //    })
            //    .AddIdentityCookies()
            //    .ApplicationCookie!.Configure(opt => opt.Events = new CookieAuthenticationEvents()
            //    {
            //        OnRedirectToLogin = ctx =>
            //        {
            //            ctx.Response.StatusCode = 401;
            //            return Task.CompletedTask;
            //        }
            //    });
            //builder.Services.AddAuthorizationBuilder();

            //.AddCookie()
            //.AddGoogle(options =>
            //{
            //    options.CallbackPath = new PathString("/google-callback");
            //    options.ClientId = configuration["GoogleApiClientId"]!;
            //    options.ClientSecret = configuration["GoogleApiClientSecret"]!;
            //});
            var AllowOrigin = "AllowOrigin";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: "AllowOrigin",
                    builder =>
                    {
                        builder
#if DEBUG
                        .SetIsOriginAllowed(_ => true)
#endif
#if !DEBUG
                        .WithOrigins(
                            "https://iwanttoknow.net",
                            "https://www.iwanttoknow.net",
                            "https://victorious-bush-0dd245d1e.6.azurestaticapps.net/")
#endif
                        .AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowCredentials();
                    });
            });
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));

            builder.Services.AddAutomapperProfiles();
            builder.Services.AddRepositories();
            builder.Services.AddServices();
            builder.Services.AddCategoryHandlers();
            builder.Services.AddQuestionHandlers();
            builder.Services.AddCorrectAnswerHandlers();
            builder.Services.AddIncorrectAnswerHandlers();
            builder.Services.AddTestHandlers();
            builder.Services.AddAnalyticHandlers();
            builder.Services.AddStudyHandlers();
            builder.Services.AddPaymentsHandlers();
            builder.Services.AddBinance(options =>
            {
                options.ApiCredentials = new ApiCredentials(
                    configuration["BinanceApiKey"]!,
                    configuration["BinanceApiSecret"]!);
            });
            
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "IWantToKnow.Net",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                                {
                                    new OpenApiSecurityScheme
                                    {
                                        Reference = new OpenApiReference
                                        {
                                            Type = ReferenceType.SecurityScheme,
                                            Id = "Bearer"
                                        }
                                    },
                                    new string[] { }
                                }
                });
            });
            
            builder.Host.UseSerilog((context, loggerConfiguration) =>
                loggerConfiguration.ReadFrom.Configuration(context.Configuration));

            // builder.Services.BuildServiceProvider(validateScopes: true);
            builder.Services.AddTransient<IEmailSenderGrid, EmailSenderGrid>();


            var app = builder.Build();
            app.MapIdentityApi<ApplicationUser>();
            //app.UseHttpsRedirection();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseCors(AllowOrigin);


            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();
            app.UseSerilogRequestLogging();

            app.MapHealthChecks("/healthz");
            app.Run();
        }
    }
}