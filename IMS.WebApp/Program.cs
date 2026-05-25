using FluentValidation;
using IMS.CoreBusiness;
using IMS.CoreBusiness.Validations;
using IMS.Plugins.InMemory;
using IMS.UseCases.Inventories;
using IMS.UseCases.PluginInterfaces;
using IMS.UseCases.Products;
using IMS.WebApp;
using IMS.WebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IProductRepository, ProductRepository>();

builder.Services.AddScoped<IValidator<Inventory>, InventoryValidator>();
builder.Services.AddScoped<IValidator<Product>, ProductValidator>();

builder.Services.AddQueryHandler<GetInventoryByIdQuery, Inventory?, GetInventoryByIdQueryHandler>();
builder.Services
    .AddQueryHandler<ViewInventoriesByNameQuery, IEnumerable<Inventory>, ViewInventoriesByNameQueryHandler>();
builder.Services.AddQueryHandler<GetProductByIdQuery, Product?, GetProductByIdQueryHandler>();
builder.Services.AddQueryHandler<ViewProductsByNameQuery, IEnumerable<Product>, ViewProductsByNameQueryHandler>();

builder.Services.AddCommandHandler<AddInventoryCommand, AddInventoryCommandHandler>();
builder.Services.AddCommandHandler<EditInventoryCommand, EditInventoryCommandHandler>();
builder.Services.AddCommandHandler<DeleteInventoryByIdCommand, DeleteInventoryByIdCommandHandler>();
builder.Services.AddCommandHandler<AddProductCommand, AddProductCommandHandler>();
builder.Services.AddCommandHandler<EditProductCommand, EditProductCommandHandler>();
builder.Services.AddCommandHandler<DeleteProductByIdCommand, DeleteProductByIdCommandHandler>();

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