using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class TinhThanhEndpointsAPI
{
    public static void MapTinhThanhEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/TinhThanh").WithTags(nameof(TinhThanh));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.TinhThanhs.ToListAsync();
        })
        .WithName("GetAllTinhThanhs")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<TinhThanh>, NotFound>> (int idtinhthanh, BatDongSanDKCNContext db) =>
        {
            return await db.TinhThanhs.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdTinhthanh == idtinhthanh)
                is TinhThanh model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTinhThanhById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idtinhthanh, TinhThanh tinhThanh, BatDongSanDKCNContext db) =>
        {
            var affected = await db.TinhThanhs
                .Where(model => model.IdTinhthanh == idtinhthanh)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdTinhthanh, tinhThanh.IdTinhthanh)
                    .SetProperty(m => m.TenTinhthanh, tinhThanh.TenTinhthanh)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTinhThanh")
        .WithOpenApi();

        group.MapPost("/", async (TinhThanh tinhThanh, BatDongSanDKCNContext db) =>
        {
            db.TinhThanhs.Add(tinhThanh);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/TinhThanh/{tinhThanh.IdTinhthanh}",tinhThanh);
        })
        .WithName("CreateTinhThanh")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idtinhthanh, BatDongSanDKCNContext db) =>
        {
            var affected = await db.TinhThanhs
                .Where(model => model.IdTinhthanh == idtinhthanh)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTinhThanh")
        .WithOpenApi();
    }
}
