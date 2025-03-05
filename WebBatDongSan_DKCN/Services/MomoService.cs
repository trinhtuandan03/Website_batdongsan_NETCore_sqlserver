using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using RestSharp;
using WebBatDongSan_DKCN.Services;
using WebBatDongSan_DKCN.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;

namespace WebBatDongSan_DKCN.Services
{
    public class MomoService : IMomoService
    {
        private readonly IOptions<MomoOption> _options;
        private readonly BatDongSanDKCNContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public MomoService(IOptions<MomoOption> options, BatDongSanDKCNContext context, IHttpContextAccessor httpContextAccessor)
        {
            _options = options;
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }

        // Tạo yêu cầu thanh toán và lưu thông tin vào cơ sở dữ liệu
        public async Task<MomoCreatePaymentResponse> CreatePaymentAsync(ThongTinGiaoDichNapTien model)
        {

            // Lấy thông tin từ session và gán vào model
            var userId = _httpContextAccessor.HttpContext.Session.GetInt32("UserId");
            // Kiểm tra xem có thông tin người dùng trong session không
            if (!userId.HasValue)
            {
                throw new UnauthorizedAccessException("User is not logged in.");
            }
            model.IdUser = userId.Value;

            // 1. Tạo OrderId mới và cấu hình thông tin giao dịch
            model.OrderId = DateTime.UtcNow.Ticks.ToString();
            model.OrderInfo = "Khách hàng: " + model.FullName + ". Nội dung: " + model.OrderInfo;
            var rawData =
                $"partnerCode={_options.Value.PartnerCode}&accessKey={_options.Value.AccessKey}&requestId={model.OrderId}&amount={model.Amount}&orderId={model.OrderId}&orderInfo={model.OrderInfo}&returnUrl={_options.Value.ReturnUrl}&notifyUrl={_options.Value.NotifyUrl}&extraData=";

            var signature = ComputeHmacSha256(rawData, _options.Value.SecretKey);
            // 2. Tạo yêu cầu thanh toán với Momo API
            var client = new RestClient(_options.Value.MomoApiUrl);
            var request = new RestRequest() { Method = Method.Post };
            request.AddHeader("Content-Type", "application/json; charset=UTF-8");

            var requestData = new
            {
                accessKey = _options.Value.AccessKey,
                partnerCode = _options.Value.PartnerCode,
                requestType = _options.Value.RequestType,
                notifyUrl = _options.Value.NotifyUrl,
                returnUrl = _options.Value.ReturnUrl,
                orderId = model.OrderId,
                amount = model.Amount.ToString(),
                orderInfo = model.OrderInfo,
                requestId = model.OrderId,
                extraData = "",
                signature = signature
            };

            request.AddParameter("application/json", JsonConvert.SerializeObject(requestData), ParameterType.RequestBody);

            var response = await client.ExecuteAsync(request);

            // 3. Lưu thông tin phản hồi vào MomoCreatePaymentResponse
            var momoResponse = JsonConvert.DeserializeObject<MomoCreatePaymentResponse>(response.Content);
            momoResponse.CreatedAt = DateTime.UtcNow;
            momoResponse.IdUser = userId.Value;// Lưu IdUser
            _context.MomoCreatePaymentResponses.Add(momoResponse);

            

            // 4. Lưu thông tin vào bảng MomoOption
            var momoOption = new MomoOption
            {
                MomoApiUrl = _options.Value.MomoApiUrl,
                SecretKey = _options.Value.SecretKey,
                AccessKey = _options.Value.AccessKey,
                ReturnUrl = _options.Value.ReturnUrl,
                NotifyUrl = _options.Value.NotifyUrl,
                PartnerCode = _options.Value.PartnerCode,
                RequestType = _options.Value.RequestType,
                CreatedAt = DateTime.UtcNow,
                IdUser = userId.Value
            };
            _context.MomoOptions.Add(momoOption);

            // 5. Lưu thông tin vào bảng ThongTinGiaoDichNapTien
            _context.ThongTinGiaoDichNapTiens.Add(model);
            //-----------------------
            // 5. Cập nhật số tiền người dùng trong bảng NguoiDung     
            var user = await _context.NguoiDungs.FindAsync(model.IdUser);
            if (user == null)
            {
                throw new InvalidOperationException("Không tìm thấy người dùng với UserId: " + model.IdUser);
            }

            // Kiểm tra và cộng dồn số tiền vào số dư hiện tại
            if (user.SoTien == null)
            {
                user.SoTien = 0;  // Nếu chưa có số tiền, gán giá trị mặc định là 0
            }

            user.SoTien += model.Amount;

            // Đánh dấu đối tượng user là "Modified" để chắc chắn rằng các thay đổi được theo dõi
            _context.Entry(user).State = EntityState.Modified;

            // Lưu các thay đổi vào cơ sở dữ liệu
            await _context.SaveChangesAsync();

            //-----------------------


            // 6. Lưu thông tin vào bảng PhanHoiNapTienMomo ngay trong CreatePaymentAsync
            var phanHoiNapTienMomo = new PhanHoiNapTienMomo
            {
                OrderId = model.OrderId,
                OrderInfo = model.OrderInfo,
                Amount = model.Amount,
                CreatedAt = DateTime.UtcNow,
                IdUser = userId.Value  // Lưu IdUser
            };
            _context.PhanHoiNapTienMomos.Add(phanHoiNapTienMomo);

            await _context.SaveChangesAsync();
            return momoResponse;
        }

        public PhanHoiNapTienMomo PaymentExecuteAsync(IQueryCollection collection)
        {
            var amountString = collection.First(s => s.Key == "amount").Value;
            var orderInfo = collection.First(s => s.Key == "orderInfo").Value;
            var orderId = collection.First(s => s.Key == "orderId").Value;

            // Khai báo biến amount có kiểu nullable decimal
            decimal? amount = null;

           
            if (decimal.TryParse(amountString, out var parsedAmount))
            {
                amount = parsedAmount;
            }

            return new PhanHoiNapTienMomo()
            {
                Amount = amount,
                OrderId = orderId,
                OrderInfo = orderInfo
            };
        }


        private string ComputeHmacSha256(string message, string secretKey)
        {
            var keyBytes = Encoding.UTF8.GetBytes(secretKey);
            var messageBytes = Encoding.UTF8.GetBytes(message);

            byte[] hashBytes;

            using (var hmac = new HMACSHA256(keyBytes))
            {
                hashBytes = hmac.ComputeHash(messageBytes);
            }

            var hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            return hashString;
        }
    }
}
