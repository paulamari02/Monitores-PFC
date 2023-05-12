using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using MonitoresTFC.Contexts;
using MonitoresTFC.Data;

var builder = WebApplication.CreateBuilder(args);


//Connection
string connection = builder.Configuration.GetConnectionString("MonitoresConnection");

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<IRepository, Repository>();

builder.Services.AddDbContext<MonitContext>(options => options.UseMySql(connection, ServerVersion.AutoDetect(connection)), ServiceLifetime.Scoped);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseStaticFiles();
app.UseHttpsRedirection();


app.UseRouting();

app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();


/*** SCAFFOLDING ***/
/*
 dotnet ef dbcontext scaffold "server=127.0.0.1; uid=root; pwd=Admin; database=monitores; Port=3306" Pomelo.EntityFrameworkCore.MySql -c TempContext -o "./Models/Monitors" --context-dir Contexts -t listadoarticulos --force

    - ListadoArticulos
    - ListadoClientes
    - ListadoPedidos
    - ListadoProductos 
    - ListadoProveedores
 */
