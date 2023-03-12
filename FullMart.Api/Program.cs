using FullMart.Core.Models;
using FullMart.Core.UnitOfWork;
using FullMart.Data.Database;
using FullMart.Data.Repositories;

using Microsoft.AspNetCore.Authentication.Negotiate;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using FullMart.Core.Helper.AutoMapper;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

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
            builder.Services.AddSwaggerGen();

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

            #endregion

            #region Identity


            builder.Services.AddIdentity<AppUser, IdentityRole>()
             .AddEntityFrameworkStores<ApplicationDbContext>()           
             .AddDefaultTokenProviders();
            #endregion






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

            app.UseStaticFiles();


            app.UseAuthentication();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}