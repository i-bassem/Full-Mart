using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Database;
using FullMart.Data.Repositories;

using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FullMart.Core.Helper.AutoMapper;
using FullMart.Core.Helper.JWT;
using FullMart.Core.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;

using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http.Features;

namespace FullMart.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers()
                            .AddNewtonsoftJson(options =>
                                 options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "FULL Mart_E-COMMERCE",
                    Version = "v1"
                });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Description = "JWT Authorization header using the Bearer scheme",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                //c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
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
                            Array.Empty<string>()
                        }
                    });

            });

            //builder.Services.AddAuthentication(NegotiateDefaults.AuthenticationScheme)
            //    .AddNegotiate();

            //builder.Services.AddAuthorization(options =>
            //{
            //    // By default, all incoming requests will be authorized according to the default policy.
            //    options.FallbackPolicy = options.DefaultPolicy;
            //});

            #region AutoMapper

            builder.Services.AddAutoMapper(opt => opt.AddProfile(new MappingProfile()));

            #endregion

            #region Connection String

            builder.Services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            #endregion

            #region DI


            builder.Services.AddScoped<IUnitOfWork , UnitOfWork>();
            builder.Services.AddScoped<IAuthenticationRepo , AuthenticationRepo>();
            builder.Services.AddScoped<RoleManager<IdentityRole>>();

            #endregion

            #region Identity


            builder.Services.AddIdentity<AppUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()           
             .AddDefaultTokenProviders();
            #endregion


            #region Configuration of JWT

            builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));


            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
              .AddJwtBearer(o =>
              {
                     o.RequireHttpsMetadata = false;
                     o.SaveToken = false;
                     o.TokenValidationParameters = new TokenValidationParameters
                     {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience = builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                        ClockSkew = TimeSpan.Zero
                     };
            });



            #endregion



            #region CORS Policy
            builder.Services.AddCors(p => p.AddPolicy("corspolicy",
                   builder =>
                   {
                       builder.AllowAnyOrigin();
                       builder.AllowAnyMethod();
                       builder.AllowAnyHeader();
                   }
                   ));
            #endregion

            //UPLOADING FILES(prevent the multipart body length error)
            builder.Services.Configure<FormOptions>(o =>
            {
                o.ValueLengthLimit = int.MaxValue;
                o.MultipartBodyLengthLimit= int.MaxValue;
                o.MemoryBufferThreshold = int.MaxValue;
            });



            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler(
                    options =>
                    {

                        options.Run(async context =>
                        {
                            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                            var ex = context.Features.Get<IExceptionHandlerFeature>();

                            if (ex != null)
                            {
                                await context.Response.WriteAsync(ex.Error.Message);
                            }
                        });
                    });
            }

            app.UseHttpsRedirection();
            //All the files in (wwwroot) are servable for client apllications by adding this line
            app.UseStaticFiles();
            //Using CORS policy
            app.UseCors("corspolicy");

            app.UseAuthentication();
            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}