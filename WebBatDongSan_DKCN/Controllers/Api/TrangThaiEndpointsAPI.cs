using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class TrangThaiEndpointsAPI
{
    public static void MapTrangThaiEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/TrangThai").WithTags(nameof(TrangThai));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.TrangThais.ToListAsync();
        })
        .WithName("GetAllTrangThais")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<TrangThai>, NotFound>> (int idtrangthai, BatDongSanDKCNContext db) =>
        {
            return await db.TrangThais.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdTrangthai == idtrangthai)
                is TrangThai model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTrangThaiById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idtrangthai, TrangThai trangThai, BatDongSanDKCNContext db) =>
        {
            var affected = await db.TrangThais
                .Where(model => model.IdTrangthai == idtrangthai)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdTrangthai, trangThai.IdTrangthai)
                    .SetProperty(m => m.TenTrangthai, trangThai.TenTrangthai)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTrangThai")
        .WithOpenApi();

        group.MapPost("/", async (TrangThai trangThai, BatDongSanDKCNContext db) =>
        {
            db.TrangThais.Add(trangThai);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/TrangThai/{trangThai.IdTrangthai}",trangThai);
        })
        .WithName("CreateTrangThai")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idtrangthai, BatDongSanDKCNContext db) =>
        {
            var affected = await db.TrangThais
                .Where(model => model.IdTrangthai == idtrangthai)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTrangThai")
        .WithOpenApi();
    }
}
