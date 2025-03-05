using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class MomoOptionEndpointsAPI
{
    public static void MapMomoOptionEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/MomoOption").WithTags(nameof(MomoOption));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.MomoOptions.ToListAsync();
        })
        .WithName("GetAllMomoOptions")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MomoOption>, NotFound>> (int idmomooption, BatDongSanDKCNContext db) =>
        {
            return await db.MomoOptions.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdMomoOption == idmomooption)
                is MomoOption model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMomoOptionById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idmomooption, MomoOption momoOption, BatDongSanDKCNContext db) =>
        {
            var affected = await db.MomoOptions
                .Where(model => model.IdMomoOption == idmomooption)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdMomoOption, momoOption.IdMomoOption)
                    .SetProperty(m => m.MomoApiUrl, momoOption.MomoApiUrl)
                    .SetProperty(m => m.SecretKey, momoOption.SecretKey)
                    .SetProperty(m => m.AccessKey, momoOption.AccessKey)
                    .SetProperty(m => m.ReturnUrl, momoOption.ReturnUrl)
                    .SetProperty(m => m.NotifyUrl, momoOption.NotifyUrl)
                    .SetProperty(m => m.PartnerCode, momoOption.PartnerCode)
                    .SetProperty(m => m.RequestType, momoOption.RequestType)
                    .SetProperty(m => m.CreatedAt, momoOption.CreatedAt)
                    .SetProperty(m => m.IdUser, momoOption.IdUser)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMomoOption")
        .WithOpenApi();

        group.MapPost("/", async (MomoOption momoOption, BatDongSanDKCNContext db) =>
        {
            db.MomoOptions.Add(momoOption);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/MomoOption/{momoOption.IdMomoOption}",momoOption);
        })
        .WithName("CreateMomoOption")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idmomooption, BatDongSanDKCNContext db) =>
        {
            var affected = await db.MomoOptions
                .Where(model => model.IdMomoOption == idmomooption)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMomoOption")
        .WithOpenApi();
    }
}
