using Microsoft.EntityFrameworkCore;
using WebBatDongSan_DKCN.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.DependencyInjection;
using WebBatDongSan_DKCN.ViewModels;
using WebBatDongSan_DKCN.Services;
using WebBatDongSan_DKCN.Data;
using WebBatDongSan_DKCN.Controllers.Api;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.Configure<MomoOption>(builder.Configuration.GetSection("MomoAPI"));
builder.Services.AddScoped<IMomoService, MomoService>();

builder.Services.AddRazorPages(); // Add Razor Pages support
builder.Services.AddDbContext<WebBatDongSan_DKCNContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("WebBatDongSan_DKCNContext") ?? throw new InvalidOperationException("Connection string 'WebBatDongSan_DKCNContext' not found.")));

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "PetStoreCookie";
        options.LoginPath = "/NguoiDungs/DangNhap";
    });



// Register session services
builder.Services.AddSession();

// Register IHttpContextAccessor
builder.Services.AddHttpContextAccessor();


//Seeding Data
var connectionString = builder.Configuration.GetConnectionString("WebBatDongSanConnection");
builder.Services.AddDbContext<BatDongSanDKCNContext>(options => options.UseSqlServer(connectionString));

// Add Swagger services
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
    {
        Title = "WebBatDongSan API",
        Version = "v1",
        Description = "API Documentation for WebBatDongSan",
        Contact = new Microsoft.OpenApi.Models.OpenApiContact
        {
            Name = "Hỗ trợ WebBatDongSan",
            Email = "support@webbatdongsan.com"
        }
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebBatDongSan API v1");
        c.RoutePrefix = "swagger"; // Swagger UI is available at /swagger
    });
}
else
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles(); // Serve static files from wwwroot

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
};

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();
app.UseSession();

// Explicitly remove default file mapping (e.g., index.html)
app.Use(async (context, next) =>
{
    if (context.Request.Path == "/index.html")
    {
        context.Response.Redirect("/");
        return;
    }
    await next();
});

app.MapRazorPages(); // Map Razor Pages

// Map controller routes
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "trang-chu",
        pattern: "trang-chu",
        defaults: new { controller = "Home", action = "Index" });

    endpoints.MapControllerRoute(
        name: "lien-he",
        pattern: "lien-he",
        defaults: new { controller = "LienHes", action = "LienHe" });

    endpoints.MapControllerRoute(
       name: "nha-dat-ban",
       pattern: "nha-dat-ban",
       defaults: new { controller = "SanPhams", action = "DanhSachSanPham" });

    endpoints.MapControllerRoute(
       name: "them-san-pham",
       pattern: "them-san-pham",
       defaults: new { controller = "SanPhams", action = "ThemSanPham" });

    endpoints.MapControllerRoute(
        name: "nha-dat-cho-thue",
        pattern: "nha-dat-cho-thue",
        defaults: new { controller = "SanPhams", action = "DanhSachSanPham" });

    endpoints.MapControllerRoute(
     name: "chi-tiet-San-Pham",
     pattern: "chi-tiet-San-Pham/{id?}",
     defaults: new { controller = "SanPhams", action = "ChiTietSanPham" });

    endpoints.MapControllerRoute(
        name: "bai-viet",
        pattern: "bai-viet",
        defaults: new { controller = "BaiViet", action = "DanhSachBaiViet" });

    endpoints.MapControllerRoute(
        name: "chi-tiet-bai-viet",
        pattern: "bai-viet/chi-tiet-bai-viet/{id?}",
        defaults: new { controller = "BaiViet", action = "ChiTietBaiViet" });

    endpoints.MapControllerRoute(
        name: "them- bai-viet",
        pattern: "them-bai-viet",
        defaults: new { controller = "BaiViet", action = "ThemBaiViet" });


    //--------------------------------------------NguoiDungs----------------------------
    endpoints.MapControllerRoute(
        name: "dang-nhap",
        pattern: "dang-nhap",
        defaults: new { controller = "NguoiDungs", action = "DangNhap" });

    endpoints.MapControllerRoute(
        name: "dang-ky",
        pattern: "dang-ky",
        defaults: new { controller = "NguoiDungs", action = "DangKy" });

    endpoints.MapControllerRoute(
        name: "thong-tin-nguoi-dung",
        pattern: "thong-tin-nguoi-dung",
        defaults: new { controller = "NguoiDungs", action = "ThongTinNguoiDung" });

    endpoints.MapControllerRoute(
      name: "dang-xuat",
      pattern: "dang-xuat",
      defaults: new { controller = "NguoiDungs", action = "Logout" });

    //--------------------------------------------Bình Luận----------------------------
 

    //-----------------------------------------------------------------------------------

    endpoints.MapControllerRoute(
        name: "thanh-toan-nap-tien",
        pattern: "thanh-toan-nap-tien",
        defaults: new { controller = "Home", action = "CreatePaymentUrl" });

    endpoints.MapControllerRoute(
               name: "thanh-toan-nap-tien-thanh-cong",
               pattern: "Home/PaymentCallBack",
               defaults: new { controller = "Home", action = "PaymentCallBack" });

    endpoints.MapControllerRoute(
          name: "thanh-vien-nhom",
          pattern: "thanh-vien-nhom",
          defaults: new { controller = "Home", action = "ThongTinThanhVien" });

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=ThongTinGiaoDichNapTiens}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=LichSuGiaoDiches}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=DSBaiVietSanPham}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=HomeAD}/{action=Index}/{id?}");

    endpoints.MapControllerRoute(
      name: "default",
      pattern: "{controller=Home}/{action=Index}/{id?}");


});

// Map API endpoints
app.MapSanPhamEndpoints();

app.MapBaiVietEndpoints();

app.MapNguoiDungEndpoints();

app.MapBinhLuanEndpoints();

app.MapDuongPhoEndpoints();

app.MapGiayToTaiLieuEndpoints();

app.MapLichSuGiaoDichEndpoints();

app.MapLienHeEndpoints();

app.MapLoaiBaiVietEndpoints();

app.MapLoaiBdEndpoints();

app.MapLoaiTaiKhoanUserEndpoints();

app.MapLoaiTinEndpoints();

app.MapMomoCreatePaymentResponseEndpoints();

app.MapMomoOptionEndpoints();

app.MapPhanHoiNapTienMomoEndpoints();

app.MapPhuongHuongEndpoints();

app.MapPhuongXaEndpoints();

app.MapQuanHuyenEndpoints();

app.MapTinhThanhEndpoints();

app.MapThongTinGiaoDichNapTienEndpoints();

app.MapTrangThaiEndpoints();


app.Run();
