using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class PhuongXaEndpointsAPI
{
    public static void MapPhuongXaEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PhuongXa").WithTags(nameof(PhuongXa));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.PhuongXas.ToListAsync();
        })
        .WithName("GetAllPhuongXas")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<PhuongXa>, NotFound>> (int idphuongxa, BatDongSanDKCNContext db) =>
        {
            return await db.PhuongXas.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPhuongxa == idphuongxa)
                is PhuongXa model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPhuongXaById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idphuongxa, PhuongXa phuongXa, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhuongXas
                .Where(model => model.IdPhuongxa == idphuongxa)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdPhuongxa, phuongXa.IdPhuongxa)
                    .SetProperty(m => m.TenPhuongxa, phuongXa.TenPhuongxa)
                    .SetProperty(m => m.IdQuanhuyen, phuongXa.IdQuanhuyen)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePhuongXa")
        .WithOpenApi();

        group.MapPost("/", async (PhuongXa phuongXa, BatDongSanDKCNContext db) =>
        {
            db.PhuongXas.Add(phuongXa);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/PhuongXa/{phuongXa.IdPhuongxa}",phuongXa);
        })
        .WithName("CreatePhuongXa")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idphuongxa, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhuongXas
                .Where(model => model.IdPhuongxa == idphuongxa)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePhuongXa")
        .WithOpenApi();
    }
}
