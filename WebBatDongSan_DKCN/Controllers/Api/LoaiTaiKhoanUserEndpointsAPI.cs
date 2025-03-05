using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class LoaiTaiKhoanUserEndpointsAPI
{
    public static void MapLoaiTaiKhoanUserEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/LoaiTaiKhoanUser").WithTags(nameof(LoaiTaiKhoanUser));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.LoaiTaiKhoanUsers.ToListAsync();
        })
        .WithName("GetAllLoaiTaiKhoanUsers")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<LoaiTaiKhoanUser>, NotFound>> (int idloaitk, BatDongSanDKCNContext db) =>
        {
            return await db.LoaiTaiKhoanUsers.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdLoaitk == idloaitk)
                is LoaiTaiKhoanUser model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetLoaiTaiKhoanUserById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idloaitk, LoaiTaiKhoanUser loaiTaiKhoanUser, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiTaiKhoanUsers
                .Where(model => model.IdLoaitk == idloaitk)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdLoaitk, loaiTaiKhoanUser.IdLoaitk)
                    .SetProperty(m => m.TenLoaitk, loaiTaiKhoanUser.TenLoaitk)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateLoaiTaiKhoanUser")
        .WithOpenApi();

        group.MapPost("/", async (LoaiTaiKhoanUser loaiTaiKhoanUser, BatDongSanDKCNContext db) =>
        {
            db.LoaiTaiKhoanUsers.Add(loaiTaiKhoanUser);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/LoaiTaiKhoanUser/{loaiTaiKhoanUser.IdLoaitk}",loaiTaiKhoanUser);
        })
        .WithName("CreateLoaiTaiKhoanUser")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idloaitk, BatDongSanDKCNContext db) =>
        {
            var affected = await db.LoaiTaiKhoanUsers
                .Where(model => model.IdLoaitk == idloaitk)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteLoaiTaiKhoanUser")
        .WithOpenApi();
    }
}
