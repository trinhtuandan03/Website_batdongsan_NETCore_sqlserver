using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LoaiBdEndpointsAPI
{
    public static void MapLoaiBdEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LoaiBd").WithTags(nameof(LoaiBd));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LoaiBds.ToListAsync();
        })
        .WithName("GetAllLoaiBds")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LoaiBd>, NotFound>> (int idloaibds, BatDongSanDKCNContext db) =>
        {
            return await db.LoaiBds.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdLoaibds == idloaibds)
                is LoaiBd model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLoaiBdById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idloaibds, LoaiBd loaiBd, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiBds
                .Where(model => model.IdLoaibds == idloaibds)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdLoaibds, loaiBd.IdLoaibds)
                    .SetProperty(m => m.TenLoaibds, loaiBd.TenLoaibds)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLoaiBd")
        .WithOpenApi();

        group.MapPost("/", async (LoaiBd loaiBd, BatDongSanDKCNContext db) =>
        {
            db.LoaiBds.Add(loaiBd);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LoaiBd/{loaiBd.IdLoaibds}",loaiBd);
        })
        .WithName("CreateLoaiBd")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idloaibds, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiBds
                .Where(model => model.IdLoaibds == idloaibds)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLoaiBd")
        .WithOpenApi();
    }
}
