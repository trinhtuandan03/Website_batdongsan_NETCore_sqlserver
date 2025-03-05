using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class PhanHoiNapTienMomoEndpointsAPI
{
    public static void MapPhanHoiNapTienMomoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/PhanHoiNapTienMomo").WithTags(nameof(PhanHoiNapTienMomo));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.PhanHoiNapTienMomos.ToListAsync();
        })
        .WithName("GetAllPhanHoiNapTienMomos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<PhanHoiNapTienMomo>, NotFound>> (int idphanhoinaptienmomo, BatDongSanDKCNContext db) =>
        {
            return await db.PhanHoiNapTienMomos.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdPhanHoiNapTienMomo == idphanhoinaptienmomo)
                is PhanHoiNapTienMomo model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetPhanHoiNapTienMomoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idphanhoinaptienmomo, PhanHoiNapTienMomo phanHoiNapTienMomo, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhanHoiNapTienMomos
                .Where(model => model.IdPhanHoiNapTienMomo == idphanhoinaptienmomo)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdPhanHoiNapTienMomo, phanHoiNapTienMomo.IdPhanHoiNapTienMomo)
                    .SetProperty(m => m.OrderId, phanHoiNapTienMomo.OrderId)
                    .SetProperty(m => m.OrderInfo, phanHoiNapTienMomo.OrderInfo)
                    .SetProperty(m => m.Amount, phanHoiNapTienMomo.Amount)
                    .SetProperty(m => m.CreatedAt, phanHoiNapTienMomo.CreatedAt)
                    .SetProperty(m => m.IdUser, phanHoiNapTienMomo.IdUser)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdatePhanHoiNapTienMomo")
        .WithOpenApi();

        group.MapPost("/", async (PhanHoiNapTienMomo phanHoiNapTienMomo, BatDongSanDKCNContext db) =>
        {
            db.PhanHoiNapTienMomos.Add(phanHoiNapTienMomo);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/PhanHoiNapTienMomo/{phanHoiNapTienMomo.IdPhanHoiNapTienMomo}",phanHoiNapTienMomo);
        })
        .WithName("CreatePhanHoiNapTienMomo")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idphanhoinaptienmomo, BatDongSanDKCNContext db) =>
        {
            var affected = await db.PhanHoiNapTienMomos
                .Where(model => model.IdPhanHoiNapTienMomo == idphanhoinaptienmomo)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeletePhanHoiNapTienMomo")
        .WithOpenApi();
    }
}
