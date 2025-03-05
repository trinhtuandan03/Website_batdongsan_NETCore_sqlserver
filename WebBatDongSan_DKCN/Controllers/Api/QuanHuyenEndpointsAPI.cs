using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class QuanHuyenEndpointsAPI
{
    public static void MapQuanHuyenEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/QuanHuyen").WithTags(nameof(QuanHuyen));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.QuanHuyens.ToListAsync();
        })
        .WithName("GetAllQuanHuyens")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<QuanHuyen>, NotFound>> (int idquanhuyen, BatDongSanDKCNContext db) =>
        {
            return await db.QuanHuyens.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdQuanhuyen == idquanhuyen)
                is QuanHuyen model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetQuanHuyenById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idquanhuyen, QuanHuyen quanHuyen, BatDongSanDKCNContext db) =>
        {
            var affected = await db.QuanHuyens
                .Where(model => model.IdQuanhuyen == idquanhuyen)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdQuanhuyen, quanHuyen.IdQuanhuyen)
                    .SetProperty(m => m.TenQuanhuyen, quanHuyen.TenQuanhuyen)
                    .SetProperty(m => m.IdTinhthanh, quanHuyen.IdTinhthanh)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateQuanHuyen")
        .WithOpenApi();

        group.MapPost("/", async (QuanHuyen quanHuyen, BatDongSanDKCNContext db) =>
        {
            db.QuanHuyens.Add(quanHuyen);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/QuanHuyen/{quanHuyen.IdQuanhuyen}",quanHuyen);
        })
        .WithName("CreateQuanHuyen")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idquanhuyen, BatDongSanDKCNContext db) =>
        {
            var affected = await db.QuanHuyens
                .Where(model => model.IdQuanhuyen == idquanhuyen)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteQuanHuyen")
        .WithOpenApi();
    }
}
