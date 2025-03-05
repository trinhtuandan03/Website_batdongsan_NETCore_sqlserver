using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class GiayToTaiLieuEndpointsAPI
{
    public static void MapGiayToTaiLieuEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/GiayToTaiLieu").WithTags(nameof(GiayToTaiLieu));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.GiayToTaiLieus.ToListAsync();
        })
        .WithName("GetAllGiayToTaiLieus")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<GiayToTaiLieu>, NotFound>> (int idgiaytotailieu, BatDongSanDKCNContext db) =>
        {
            return await db.GiayToTaiLieus.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdGiaytoTailieu == idgiaytotailieu)
                is GiayToTaiLieu model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetGiayToTaiLieuById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idgiaytotailieu, GiayToTaiLieu giayToTaiLieu, BatDongSanDKCNContext db) =>
        {
            var affected = await db.GiayToTaiLieus
                .Where(model => model.IdGiaytoTailieu == idgiaytotailieu)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdGiaytoTailieu, giayToTaiLieu.IdGiaytoTailieu)
                    .SetProperty(m => m.TenGiaytoTailieu, giayToTaiLieu.TenGiaytoTailieu)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateGiayToTaiLieu")
        .WithOpenApi();

        group.MapPost("/", async (GiayToTaiLieu giayToTaiLieu, BatDongSanDKCNContext db) =>
        {
            db.GiayToTaiLieus.Add(giayToTaiLieu);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/GiayToTaiLieu/{giayToTaiLieu.IdGiaytoTailieu}",giayToTaiLieu);
        })
        .WithName("CreateGiayToTaiLieu")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idgiaytotailieu, BatDongSanDKCNContext db) =>
        {
            var affected = await db.GiayToTaiLieus
                .Where(model => model.IdGiaytoTailieu == idgiaytotailieu)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteGiayToTaiLieu")
        .WithOpenApi();
    }
}
