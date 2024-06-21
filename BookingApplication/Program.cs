using BA.Domain.Identity;
using BA.Repository;
using BA.Repository.Implementation;
using BA.Repository.Interface;
using BA.Service.Implementation;
using BA.Service.Interface;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using NuGet.Protocol.Core.Types;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
 //   options.UseSqlServer(connectionString , sqlServerOptionsAction: sqlOptions => { sqlOptions.EnableRetryOnFailure(); }));


builder.Services.AddDbContext<ApplicationDbContext>(options =>
           options.UseNpgsql(connectionString));

//builder.Services.AddDbContext<ApplicationDbContext>(options =>
//    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
//        sqlServerOptionsAction: sqlOptions =>
//        {
//            sqlOptions.EnableRetryOnFailure(
//                maxRetryCount: 1, // Number of retry attempts
//               maxRetryDelay: TimeSpan.FromSeconds(30), // Delay between retries
//                errorNumbersToAdd: null); // List of error numbers to consider transient (optional)
//        }));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();


//options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), sqlServerOptionsAction: sqlOptions =>
//{
//sqlOptions.EnableRetryOnFailure();
//  sqlOptions.UseCertificateStoreLocation(StoreLocation.LocalMachine);
//});


builder.Services.AddDefaultIdentity<BookingApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped(typeof(IUserRepository), typeof(UserRepository));

builder.Services.AddTransient<IApartmentService, ApartmentService>();
builder.Services.AddTransient<IReservationsServices, ReservationService>();
builder.Services.AddTransient<IBookingListService, BookingListService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
