using WebBatDongSan_DKCN.Models;

namespace WebBatDongSan_DKCN.Services;

public interface IMomoService
{
    // interface cho dịch vụ Momo, nơi bạn có thể định nghĩa các phương thức mà lớp dịch vụ thực hiện.
    Task<MomoCreatePaymentResponse> CreatePaymentAsync(ThongTinGiaoDichNapTien model);
    // Xử lý phản hồi thanh toán từ Momo
    PhanHoiNapTienMomo PaymentExecuteAsync(IQueryCollection collection);
}
