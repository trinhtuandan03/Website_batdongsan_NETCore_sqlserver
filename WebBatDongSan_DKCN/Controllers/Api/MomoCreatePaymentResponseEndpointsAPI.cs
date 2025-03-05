using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using WebBatDongSan_DKCN.Models;
namespace WebBatDongSan_DKCN.Controllers.Api;

public static class MomoCreatePaymentResponseEndpointsAPI
{
    public static void MapMomoCreatePaymentResponseEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/MomoCreatePaymentResponse").WithTags(nameof(MomoCreatePaymentResponse));

        group.MapGet("/", async (BatDongSanDKCNContext db) =>
        {
            return await db.MomoCreatePaymentResponses.ToListAsync();
        })
        .WithName("GetAllMomoCreatePaymentResponses")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<MomoCreatePaymentResponse>, NotFound>> (int idmomocreatepayment, BatDongSanDKCNContext db) =>
        {
            return await db.MomoCreatePaymentResponses.AsNoTracking()
                .FirstOrDefaultAsync(model => model.IdMomoCreatePayment == idmomocreatepayment)
                is MomoCreatePaymentResponse model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetMomoCreatePaymentResponseById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int idmomocreatepayment, MomoCreatePaymentResponse momoCreatePaymentResponse, BatDongSanDKCNContext db) =>
        {
            var affected = await db.MomoCreatePaymentResponses
                .Where(model => model.IdMomoCreatePayment == idmomocreatepayment)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.IdMomoCreatePayment, momoCreatePaymentResponse.IdMomoCreatePayment)
                    .SetProperty(m => m.RequestId, momoCreatePaymentResponse.RequestId)
                    .SetProperty(m => m.ErrorCode, momoCreatePaymentResponse.ErrorCode)
                    .SetProperty(m => m.OrderId, momoCreatePaymentResponse.OrderId)
                    .SetProperty(m => m.Message, momoCreatePaymentResponse.Message)
                    .SetProperty(m => m.LocalMessage, momoCreatePaymentResponse.LocalMessage)
                    .SetProperty(m => m.RequestType, momoCreatePaymentResponse.RequestType)
                    .SetProperty(m => m.PayUrl, momoCreatePaymentResponse.PayUrl)
                    .SetProperty(m => m.Signature, momoCreatePaymentResponse.Signature)
                    .SetProperty(m => m.QrCodeUrl, momoCreatePaymentResponse.QrCodeUrl)
                    .SetProperty(m => m.Deeplink, momoCreatePaymentResponse.Deeplink)
                    .SetProperty(m => m.DeeplinkWebInApp, momoCreatePaymentResponse.DeeplinkWebInApp)
                    .SetProperty(m => m.CreatedAt, momoCreatePaymentResponse.CreatedAt)
                    .SetProperty(m => m.IdUser, momoCreatePaymentResponse.IdUser)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateMomoCreatePaymentResponse")
        .WithOpenApi();

        group.MapPost("/", async (MomoCreatePaymentResponse momoCreatePaymentResponse, BatDongSanDKCNContext db) =>
        {
            db.MomoCreatePaymentResponses.Add(momoCreatePaymentResponse);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/MomoCreatePaymentResponse/{momoCreatePaymentResponse.IdMomoCreatePayment}",momoCreatePaymentResponse);
        })
        .WithName("CreateMomoCreatePaymentResponse")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int idmomocreatepayment, BatDongSanDKCNContext db) =>
        {
            var affected = await db.MomoCreatePaymentResponses
                .Where(model => model.IdMomoCreatePayment == idmomocreatepayment)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteMomoCreatePaymentResponse")
        .WithOpenApi();
    }
}
