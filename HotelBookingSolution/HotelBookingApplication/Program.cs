using HotelBookingApplication.Contexts;
using HotelBookingApplication.Interfaces;
using HotelBookingApplication.Models;
using HotelBookingApplication.Repositories;
using HotelBookingApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace HotelBookingApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
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
                             new string[] {}

                     }
                 });
            });
            
            #region CORS
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("reactApp", opts =>
                {
                    opts.AllowAnyMethod().AllowAnyHeader().AllowAnyOrigin();
                });
            });
            #endregion
            
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
                        ValidateIssuerSigningKey = true
                    };
                });
            builder.Services.AddDbContext<BookingContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("bookingCon"));
            });
            builder.Logging.AddLog4Net();

            builder.Services.AddScoped<IRepository<string, User>, UserRepository>();
            builder.Services.AddScoped<IRepository<int, Hotel>, HotelRepository>();
            builder.Services.AddScoped<IRepository<int, Room>, RoomRepository>();
            builder.Services.AddScoped<IRepository<int, Review>, ReviewRepository>();
            builder.Services.AddScoped<IRepository<int, RoomAmenity>, RoomAmenityRepository>();
            builder.Services.AddScoped<IRepository<int, Booking>, BookingRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IRoomService, RoomService>();
            builder.Services.AddScoped<IHotelService, HotelService>();
            builder.Services.AddScoped<IReviewService, ReviewService>();   
            builder.Services.AddScoped<IBookingService, BookingService>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseCors("reactApp");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}