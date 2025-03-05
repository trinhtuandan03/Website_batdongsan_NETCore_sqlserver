using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class BaiVietEndpointsAPI
{
    public static void MapBaiVietEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/BaiViet").WithTags(nameof(BaiViet));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.BaiViets.ToListAsync();
        })
        .WithName("GetAllBaiViets")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<BaiViet>, NotFound>> (int idbaiviet, BatDongSanDKCNContext db) =>
        {
            return await db.BaiViets.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdBaiviet == idbaiviet)
                is BaiViet model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetBaiVietById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idbaiviet, BaiViet baiViet, BatDongSanDKCNContext db) =>
        {
            var affected = await db.BaiViets
                .Where(model => model.IdBaiviet == idbaiviet)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdBaiviet, baiViet.IdBaiviet)
                    .SetProperty(m => m.TieuDe, baiViet.TieuDe)
                    .SetProperty(m => m.NoiDung, baiViet.NoiDung)
                    .SetProperty(m => m.NgayTao, baiViet.NgayTao)
                    .SetProperty(m => m.IdUser, baiViet.IdUser)
                    .SetProperty(m => m.IdLoaibaiviet, baiViet.IdLoaibaiviet)
                    .SetProperty(m => m.IdTrangthai, baiViet.IdTrangthai)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateBaiViet")
        .WithOpenApi();

        group.MapPost("/", async (BaiViet baiViet, BatDongSanDKCNContext db) =>
        {
            db.BaiViets.Add(baiViet);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/BaiViet/{baiViet.IdBaiviet}",baiViet);
        })
        .WithName("CreateBaiViet")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idbaiviet, BatDongSanDKCNContext db) =>
        {
            var affected = await db.BaiViets
                .Where(model => model.IdBaiviet == idbaiviet)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteBaiViet")
        .WithOpenApi();
    }
}
