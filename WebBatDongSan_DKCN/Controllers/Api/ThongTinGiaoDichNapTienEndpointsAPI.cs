using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class ThongTinGiaoDichNapTienEndpointsAPI
{
    public static void MapThongTinGiaoDichNapTienEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/ThongTinGiaoDichNapTien").WithTags(nameof(ThongTinGiaoDichNapTien));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.ThongTinGiaoDichNapTiens.ToListAsync();
        })
        .WithName("GetAllThongTinGiaoDichNapTiens")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<ThongTinGiaoDichNapTien>, NotFound>> (int idthongtingiaodichnaptien, BatDongSanDKCNContext db) =>
        {
            return await db.ThongTinGiaoDichNapTiens.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdThongTinGiaoDichNapTien == idthongtingiaodichnaptien)
                is ThongTinGiaoDichNapTien model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetThongTinGiaoDichNapTienById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idthongtingiaodichnaptien, ThongTinGiaoDichNapTien thongTinGiaoDichNapTien, BatDongSanDKCNContext db) =>
        {
            var affected = await db.ThongTinGiaoDichNapTiens
                .Where(model => model.IdThongTinGiaoDichNapTien == idthongtingiaodichnaptien)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdThongTinGiaoDichNapTien, thongTinGiaoDichNapTien.IdThongTinGiaoDichNapTien)
                    .SetProperty(m => m.FullName, thongTinGiaoDichNapTien.FullName)
                    .SetProperty(m => m.OrderId, thongTinGiaoDichNapTien.OrderId)
                    .SetProperty(m => m.OrderInfo, thongTinGiaoDichNapTien.OrderInfo)
                    .SetProperty(m => m.Amount, thongTinGiaoDichNapTien.Amount)
                    .SetProperty(m => m.CreatedAt, thongTinGiaoDichNapTien.CreatedAt)
                    .SetProperty(m => m.IdUser, thongTinGiaoDichNapTien.IdUser)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateThongTinGiaoDichNapTien")
        .WithOpenApi();

        group.MapPost("/", async (ThongTinGiaoDichNapTien thongTinGiaoDichNapTien, BatDongSanDKCNContext db) =>
        {
            db.ThongTinGiaoDichNapTiens.Add(thongTinGiaoDichNapTien);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/ThongTinGiaoDichNapTien/{thongTinGiaoDichNapTien.IdThongTinGiaoDichNapTien}",thongTinGiaoDichNapTien);
        })
        .WithName("CreateThongTinGiaoDichNapTien")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idthongtingiaodichnaptien, BatDongSanDKCNContext db) =>
        {
            var affected = await db.ThongTinGiaoDichNapTiens
                .Where(model => model.IdThongTinGiaoDichNapTien == idthongtingiaodichnaptien)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteThongTinGiaoDichNapTien")
        .WithOpenApi();
    }
}
