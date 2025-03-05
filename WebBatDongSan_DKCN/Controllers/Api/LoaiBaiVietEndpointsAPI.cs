using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LoaiBaiVietEndpointsAPI
{
    public static void MapLoaiBaiVietEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LoaiBaiViet").WithTags(nameof(LoaiBaiViet));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LoaiBaiViets.ToListAsync();
        })
        .WithName("GetAllLoaiBaiViets")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LoaiBaiViet>, NotFound>> (int idloaibaiviet, BatDongSanDKCNContext db) =>
        {
            return await db.LoaiBaiViets.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdLoaibaiviet == idloaibaiviet)
                is LoaiBaiViet model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLoaiBaiVietById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idloaibaiviet, LoaiBaiViet loaiBaiViet, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiBaiViets
                .Where(model => model.IdLoaibaiviet == idloaibaiviet)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdLoaibaiviet, loaiBaiViet.IdLoaibaiviet)
                    .SetProperty(m => m.Tenloaibaiviet, loaiBaiViet.Tenloaibaiviet)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLoaiBaiViet")
        .WithOpenApi();

        group.MapPost("/", async (LoaiBaiViet loaiBaiViet, BatDongSanDKCNContext db) =>
        {
            db.LoaiBaiViets.Add(loaiBaiViet);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LoaiBaiViet/{loaiBaiViet.IdLoaibaiviet}",loaiBaiViet);
        })
        .WithName("CreateLoaiBaiViet")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idloaibaiviet, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiBaiViets
                .Where(model => model.IdLoaibaiviet == idloaibaiviet)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLoaiBaiViet")
        .WithOpenApi();
    }
}
