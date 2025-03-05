using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class SanPhamEndpointsAPI
{
    public static void MapSanPhamEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/SanPham").WithTags(nameof(SanPham));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.SanPhams.ToListAsync();
        })
        .WithName("GetAllSanPhams")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<SanPham>, NotFound>> (int idsanpham, BatDongSanDKCNContext db) =>
        {
            return await db.SanPhams.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdSanpham == idsanpham)
                is SanPham model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetSanPhamById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idsanpham, SanPham sanPham, BatDongSanDKCNContext db) =>
        {
            var affected = await db.SanPhams
                .Where(model => model.IdSanpham == idsanpham)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdSanpham, sanPham.IdSanpham)
                    .SetProperty(m => m.TieuDeSanpham, sanPham.TieuDeSanpham)
                    .SetProperty(m => m.MoTaSanpham, sanPham.MoTaSanpham)
                    .SetProperty(m => m.GiaSanPham, sanPham.GiaSanPham)
                    .SetProperty(m => m.DienTich, sanPham.DienTich)
                    .SetProperty(m => m.NgayDang, sanPham.NgayDang)
                    .SetProperty(m => m.Img1, sanPham.Img1)
                    .SetProperty(m => m.Img2, sanPham.Img2)
                    .SetProperty(m => m.Img3, sanPham.Img3)
                    .SetProperty(m => m.Img4, sanPham.Img4)
                    .SetProperty(m => m.Img5, sanPham.Img5)
                    .SetProperty(m => m.IdUser, sanPham.IdUser)
                    .SetProperty(m => m.IdGiaytoTailieu, sanPham.IdGiaytoTailieu)
                    .SetProperty(m => m.IdLoaitin, sanPham.IdLoaitin)
                    .SetProperty(m => m.IdLoaibds, sanPham.IdLoaibds)
                    .SetProperty(m => m.IdTinhthanh, sanPham.IdTinhthanh)
                    .SetProperty(m => m.IdQuanhuyen, sanPham.IdQuanhuyen)
                    .SetProperty(m => m.IdPhuongxa, sanPham.IdPhuongxa)
                    .SetProperty(m => m.Chieungang, sanPham.Chieungang)
                    .SetProperty(m => m.Chieudai, sanPham.Chieudai)
                    .SetProperty(m => m.SoLau, sanPham.SoLau)
                    .SetProperty(m => m.SoPhongNgu, sanPham.SoPhongNgu)
                    .SetProperty(m => m.PhongAn, sanPham.PhongAn)
                    .SetProperty(m => m.NhaBep, sanPham.NhaBep)
                    .SetProperty(m => m.SanThuong, sanPham.SanThuong)
                    .SetProperty(m => m.ChoDeXeHoi, sanPham.ChoDeXeHoi)
                    .SetProperty(m => m.DiaChi, sanPham.DiaChi)
                    .SetProperty(m => m.IdDuongpho, sanPham.IdDuongpho)
                    .SetProperty(m => m.IdPhuonghuong, sanPham.IdPhuonghuong)
                    .SetProperty(m => m.IdTrangthai, sanPham.IdTrangthai)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateSanPham")
        .WithOpenApi();

        group.MapPost("/", async (SanPham sanPham, BatDongSanDKCNContext db) =>
        {
            db.SanPhams.Add(sanPham);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/SanPham/{sanPham.IdSanpham}",sanPham);
        })
        .WithName("CreateSanPham")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idsanpham, BatDongSanDKCNContext db) =>
        {
            var affected = await db.SanPhams
                .Where(model => model.IdSanpham == idsanpham)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteSanPham")
        .WithOpenApi();
    }
}
