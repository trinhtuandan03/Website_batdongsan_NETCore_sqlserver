using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LichSuGiaoDichEndpointsAPI
{
    public static void MapLichSuGiaoDichEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LichSuGiaoDich").WithTags(nameof(LichSuGiaoDich));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LichSuGiaoDiches.ToListAsync();
        })
        .WithName("GetAllLichSuGiaoDiches")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LichSuGiaoDich>, NotFound>> (int idgiaodich, BatDongSanDKCNContext db) =>
        {
            return await db.LichSuGiaoDiches.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdGiaoDich == idgiaodich)
                is LichSuGiaoDich model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLichSuGiaoDichById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idgiaodich, LichSuGiaoDich lichSuGiaoDich, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LichSuGiaoDiches
                .Where(model => model.IdGiaoDich == idgiaodich)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdGiaoDich, lichSuGiaoDich.IdGiaoDich)
                    .SetProperty(m => m.IdUser, lichSuGiaoDich.IdUser)
                    .SetProperty(m => m.IdBaiviet, lichSuGiaoDich.IdBaiviet)
                    .SetProperty(m => m.IdSanpham, lichSuGiaoDich.IdSanpham)
                    .SetProperty(m => m.SoTien, lichSuGiaoDich.SoTien)
                    .SetProperty(m => m.LoaiGiaoDich, lichSuGiaoDich.LoaiGiaoDich)
                    .SetProperty(m => m.ThoiGianGiaoDich, lichSuGiaoDich.ThoiGianGiaoDich)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLichSuGiaoDich")
        .WithOpenApi();

        group.MapPost("/", async (LichSuGiaoDich lichSuGiaoDich, BatDongSanDKCNContext db) =>
        {
            db.LichSuGiaoDiches.Add(lichSuGiaoDich);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LichSuGiaoDich/{lichSuGiaoDich.IdGiaoDich}",lichSuGiaoDich);
        })
        .WithName("CreateLichSuGiaoDich")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idgiaodich, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LichSuGiaoDiches
                .Where(model => model.IdGiaoDich == idgiaodich)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLichSuGiaoDich")
        .WithOpenApi();
    }
}
