using HealthCare.Core;
using HealthCare.WebApp.Services.Auth0;
using Auth0.AspNetCore.Authentication;
using HealthCare.Core.Context;
using Microsoft.EntityFrameworkCore;
using HealthCare.WebApp.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<FeedbackService>();
builder.Services.AddScoped<AppointmentService>();
builder.Services.AddScoped<BookingService>();
builder.Services.AddScoped<UserDataService>();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddScoped<TokenService>();
builder.Services.Configure<Auth0Settings>(builder.Configuration.GetSection(Auth0Settings.SectionName));
builder.Services.AddHttpClient();
builder.Services.AddDbContext<HealthcareContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("HealthcareConnection")));

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

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();