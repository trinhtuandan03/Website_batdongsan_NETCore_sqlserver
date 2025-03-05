using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LienHeEndpointsAPI
{
    public static void MapLienHeEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LienHe").WithTags(nameof(LienHe));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LienHes.ToListAsync();
        })
        .WithName("GetAllLienHes")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LienHe>, NotFound>> (int idlienhe, BatDongSanDKCNContext db) =>
        {
            return await db.LienHes.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdLienHe == idlienhe)
                is LienHe model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLienHeById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idlienhe, LienHe lienHe, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LienHes
                .Where(model => model.IdLienHe == idlienhe)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdLienHe, lienHe.IdLienHe)
                    .SetProperty(m => m.TieuDe, lienHe.TieuDe)
                    .SetProperty(m => m.NoiDung, lienHe.NoiDung)
                    .SetProperty(m => m.ThoiGianGui, lienHe.ThoiGianGui)
                    .SetProperty(m => m.IdUser, lienHe.IdUser)
                    .SetProperty(m => m.HoTen, lienHe.HoTen)
                    .SetProperty(m => m.Email, lienHe.Email)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLienHe")
        .WithOpenApi();

        group.MapPost("/", async (LienHe lienHe, BatDongSanDKCNContext db) =>
        {
            db.LienHes.Add(lienHe);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LienHe/{lienHe.IdLienHe}",lienHe);
        })
        .WithName("CreateLienHe")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idlienhe, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LienHes
                .Where(model => model.IdLienHe == idlienhe)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLienHe")
        .WithOpenApi();
    }
}
