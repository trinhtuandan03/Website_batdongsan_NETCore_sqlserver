using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class DuongPhoEndpointsAPI
{
    public static void MapDuongPhoEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/DuongPho").WithTags(nameof(DuongPho));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.DuongPhos.ToListAsync();
        })
        .WithName("GetAllDuongPhos")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<DuongPho>, NotFound>> (int idduongpho, BatDongSanDKCNContext db) =>
        {
            return await db.DuongPhos.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdDuongpho == idduongpho)
                is DuongPho model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetDuongPhoById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idduongpho, DuongPho duongPho, BatDongSanDKCNContext db) =>
        {
            var affected = await db.DuongPhos
                .Where(model => model.IdDuongpho == idduongpho)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdDuongpho, duongPho.IdDuongpho)
                    .SetProperty(m => m.TenDuongpho, duongPho.TenDuongpho)
                    .SetProperty(m => m.IdPhuongxa, duongPho.IdPhuongxa)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateDuongPho")
        .WithOpenApi();

        group.MapPost("/", async (DuongPho duongPho, BatDongSanDKCNContext db) =>
        {
            db.DuongPhos.Add(duongPho);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/DuongPho/{duongPho.IdDuongpho}",duongPho);
        })
        .WithName("CreateDuongPho")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idduongpho, BatDongSanDKCNContext db) =>
        {
            var affected = await db.DuongPhos
                .Where(model => model.IdDuongpho == idduongpho)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteDuongPho")
        .WithOpenApi();
    }
}
