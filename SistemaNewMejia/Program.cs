using Microsoft.EntityFrameworkCore;
using SistemaNewMejia.DB;
using SistemaNewMejia.Repositorio;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<DbEntities>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("GrifoMejia"))
);

builder.Services.AddTransient<IDetalleValeRepositorio, DetalleValeRepositorio>();
builder.Services.AddTransient<IDetalleVentaRepositorio, DetalleVentaRepositorio>();
builder.Services.AddTransient<IEstadoValeRepositorio, EstadoValeRepositorio>();
builder.Services.AddTransient<IHistorialNroValesRepositorio, HistorialNroValesRepositorio>();
builder.Services.AddTransient<IPresentacionProductoRepositorio, PresentacionProductoRepositorio>();
builder.Services.AddTransient<IProductoRepositorio, ProductoRepositorio>();
builder.Services.AddTransient<ITipoComprobanteRepositorio, TipoComprobanteRepositorio>();
builder.Services.AddTransient<ITipoDescuentoRepositorio, TipoDescuentoRepositorio>();
builder.Services.AddTransient<ITipoPagoRepositorio, TipoPagoRepositorio>();
builder.Services.AddTransient<ITipoProductoRepositorio, TipoProductoRepositorio>();
builder.Services.AddTransient<IUsuarioRepositorio, UsuarioRepositorio>();
builder.Services.AddTransient<IValeRepositorio, ValeRepositorio>();
builder.Services.AddTransient<VentaRepositorio, VentaRepositorio>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Auth}/{action=Login}/{id?}");

app.Run();
