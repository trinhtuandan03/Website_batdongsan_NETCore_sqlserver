using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class PhuongHuongEndpointsAPI
{
    public static void MapPhuongHuongEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PhuongHuong").WithTags(nameof(PhuongHuong));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.PhuongHuongs.ToListAsync();
        })
        .WithName("GetAllPhuongHuongs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<PhuongHuong>, NotFound>> (int idphuonghuong, BatDongSanDKCNContext db) =>
        {
            return await db.PhuongHuongs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPhuonghuong == idphuonghuong)
                is PhuongHuong model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPhuongHuongById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idphuonghuong, PhuongHuong phuongHuong, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhuongHuongs
                .Where(model => model.IdPhuonghuong == idphuonghuong)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdPhuonghuong, phuongHuong.IdPhuonghuong)
                    .SetProperty(m => m.TenPhuonghuong, phuongHuong.TenPhuonghuong)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePhuongHuong")
        .WithOpenApi();

        group.MapPost("/", async (PhuongHuong phuongHuong, BatDongSanDKCNContext db) =>
        {
            db.PhuongHuongs.Add(phuongHuong);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/PhuongHuong/{phuongHuong.IdPhuonghuong}",phuongHuong);
        })
        .WithName("CreatePhuongHuong")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idphuonghuong, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhuongHuongs
                .Where(model => model.IdPhuonghuong == idphuonghuong)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePhuongHuong")
        .WithOpenApi();
    }
}
