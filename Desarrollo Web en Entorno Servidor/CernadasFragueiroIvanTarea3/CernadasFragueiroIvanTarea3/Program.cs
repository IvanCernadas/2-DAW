using CernadasFragueiroIvanTarea3.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<EstudiantesContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionMontecastelo")));

builder.Services.AddDbContext<AsignaturasContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionMontecastelo")));

builder.Services.AddDbContext<ProfesoresContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionMontecastelo")));

// Add services to the container.
builder.Services.AddControllersWithViews();

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
    name: "home",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapControllerRoute(
    name: "detallesProfesores",
    pattern: "{controller=Profesores}/{action=Detalles}/{id}");

app.MapControllerRoute(
    name: "listaProfesores",
    pattern: "{controller=Profesores}/{action=Lista}");

app.MapControllerRoute(
    name: "detallesEstudiantes",
    pattern: "{controller=Estudiantes}/{action=Detalles}/{id}");

app.MapControllerRoute(
    name: "listaEstudiantes",
    pattern: "{controller=Estudiantes}/{action=Lista}");

app.MapControllerRoute(
    name: "listaAsignaturas",
    pattern: "{controller=Asignaturas}/{action=Lista}");

app.MapControllerRoute(
    name: "detallesAsignataturas",
    pattern: "{controller=Asignaturas}/{action=Detalles}/{id}");

app.MapControllerRoute(
    name: "verMiCV",
    pattern: "{controller=MiCurriculum}/{action=Index}");

app.Run();
