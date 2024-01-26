using HealthCare.Core;
using HealthCare.WebApp.Services.Auth0;
using Auth0.AspNetCore.Authentication;
using HealthCare.Core.Context;
using Microsoft.EntityFrameworkCore;
using HealthCare.WebApp.Services;
using HealthCare.Core.Controllers;
using HealthCare.Core.Models;
using HealthCare.Core.Repositories;
using Blazored.LocalStorage;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorPages();

//builder.Services.AddRazorPages(options =>
//{
//    options.Conventions.AuthorizeFolder("/"); // Secures the root folder, requiring authorization by default
//});

//För att kunna spara UserId i localstorage
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<UserDataService>();

builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<Patient>();
builder.Services.AddScoped<UserAccessService>();
builder.Services.AddScoped<PatientController>();
builder.Services.AddScoped<IPatientRepository, PatientRepository>();
builder.Services.AddScoped<ICaregiverRepository, CaregiverRepository>();
builder.Services.AddScoped<IBookingRepository, BookingRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();

builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<TokenService>();
builder.Services.Configure<Auth0Settings>(builder.Configuration.GetSection(Auth0Settings.SectionName));
builder.Services.AddHttpClient();
builder.Services.AddDbContext<HealthcareContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("HealthcareConnection")));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddAuth0WebAppAuthentication(options => {
        options.Domain = builder.Configuration["Auth0:Domain"];
        options.ClientId = builder.Configuration["Auth0:ClientId"];
    });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");
app.MapControllers();

app.Run();