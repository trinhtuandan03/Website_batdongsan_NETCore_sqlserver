using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class BinhLuanEndpointsAPI
{
    public static void MapBinhLuanEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/BinhLuan").WithTags(nameof(BinhLuan));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.BinhLuans.ToListAsync();
        })
        .WithName("GetAllBinhLuans")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<BinhLuan>, NotFound>> (int idbinhluan, BatDongSanDKCNContext db) =>
        {
            return await db.BinhLuans.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdBinhluan == idbinhluan)
                is BinhLuan model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetBinhLuanById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idbinhluan, BinhLuan binhLuan, BatDongSanDKCNContext db) =>
        {
            var affected = await db.BinhLuans
                .Where(model => model.IdBinhluan == idbinhluan)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdBinhluan, binhLuan.IdBinhluan)
                    .SetProperty(m => m.NoiDung, binhLuan.NoiDung)
                    .SetProperty(m => m.IdSanpham, binhLuan.IdSanpham)
                    .SetProperty(m => m.IdBaiviet, binhLuan.IdBaiviet)
                    .SetProperty(m => m.NgayTao, binhLuan.NgayTao)
                    .SetProperty(m => m.IdUser, binhLuan.IdUser)
                    .SetProperty(m => m.BinhLuanChaId, binhLuan.BinhLuanChaId)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateBinhLuan")
        .WithOpenApi();

        group.MapPost("/", async (BinhLuan binhLuan, BatDongSanDKCNContext db) =>
        {
            db.BinhLuans.Add(binhLuan);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/BinhLuan/{binhLuan.IdBinhluan}",binhLuan);
        })
        .WithName("CreateBinhLuan")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idbinhluan, BatDongSanDKCNContext db) =>
        {
            var affected = await db.BinhLuans
                .Where(model => model.IdBinhluan == idbinhluan)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteBinhLuan")
        .WithOpenApi();
    }
}
