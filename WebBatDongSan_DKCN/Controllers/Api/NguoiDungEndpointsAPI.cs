using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class NguoiDungEndpointsAPI
{
    public static void MapNguoiDungEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/NguoiDung").WithTags(nameof(NguoiDung));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.NguoiDungs.ToListAsync();
        })
        .WithName("GetAllNguoiDungs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<NguoiDung>, NotFound>> (int iduser, BatDongSanDKCNContext db) =>
        {
            return await db.NguoiDungs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdUser == iduser)
                is NguoiDung model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetNguoiDungById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int iduser, NguoiDung nguoiDung, BatDongSanDKCNContext db) =>
        {
            var affected = await db.NguoiDungs
                .Where(model => model.IdUser == iduser)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdUser, nguoiDung.IdUser)
                    .SetProperty(m => m.TenTruyCap, nguoiDung.TenTruyCap)
                    .SetProperty(m => m.MatKhau, nguoiDung.MatKhau)
                    .SetProperty(m => m.HoTen, nguoiDung.HoTen)
                    .SetProperty(m => m.Sdt, nguoiDung.Sdt)
                    .SetProperty(m => m.Email, nguoiDung.Email)
                    .SetProperty(m => m.LoaiTaiKhoanId, nguoiDung.LoaiTaiKhoanId)
                    .SetProperty(m => m.NgayDangky, nguoiDung.NgayDangky)
                    .SetProperty(m => m.SoTien, nguoiDung.SoTien)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateNguoiDung")
        .WithOpenApi();

        group.MapPost("/", async (NguoiDung nguoiDung, BatDongSanDKCNContext db) =>
        {
            db.NguoiDungs.Add(nguoiDung);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/NguoiDung/{nguoiDung.IdUser}",nguoiDung);
        })
        .WithName("CreateNguoiDung")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int iduser, BatDongSanDKCNContext db) =>
        {
            var affected = await db.NguoiDungs
                .Where(model => model.IdUser == iduser)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteNguoiDung")
        .WithOpenApi();
    }
}
