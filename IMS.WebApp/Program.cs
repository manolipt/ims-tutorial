using FluentValidation;
using IMS.CoreBusiness;
using IMS.CoreBusiness.Validations;
using IMS.Plugins.InMemory;
using IMS.UseCases;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Repositories;
using IMS.WebApp;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<IValidator<Inventory>, InventoryValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

// builder.Services.AddInventoryFeatures();
// builder.Services.AddProductFeatures();
builder.Services.AddRepositoryFeaturesFor<Inventory, InventoryRepository>();
builder.Services.AddRepositoryFeaturesFor<Product, ProductRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();