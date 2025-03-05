using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LoaiTinEndpointsAPI
{
    public static void MapLoaiTinEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LoaiTin").WithTags(nameof(LoaiTin));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LoaiTins.ToListAsync();
        })
        .WithName("GetAllLoaiTins")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LoaiTin>, NotFound>> (int idloaitin, BatDongSanDKCNContext db) =>
        {
            return await db.LoaiTins.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdLoaitin == idloaitin)
                is LoaiTin model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLoaiTinById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idloaitin, LoaiTin loaiTin, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiTins
                .Where(model => model.IdLoaitin == idloaitin)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdLoaitin, loaiTin.IdLoaitin)
                    .SetProperty(m => m.TenLoaitin, loaiTin.TenLoaitin)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLoaiTin")
        .WithOpenApi();

        group.MapPost("/", async (LoaiTin loaiTin, BatDongSanDKCNContext db) =>
        {
            db.LoaiTins.Add(loaiTin);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LoaiTin/{loaiTin.IdLoaitin}",loaiTin);
        })
        .WithName("CreateLoaiTin")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idloaitin, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiTins
                .Where(model => model.IdLoaitin == idloaitin)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLoaiTin")
        .WithOpenApi();
    }
}
