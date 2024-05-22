using System.ComponentModel.DataAnnotations;

namespace BuiQuocHuy_BTCK_C_.Models
{
    public class ThongBao : UserActivity
    {
        public int Id { get; set; }
        [StringLength(150, MinimumLength = 20, ErrorMessage = "Tiêu đề bài đăng phải có độ dài từ 20 đến 150 ký tự")]
        public string TieuDe { get; set; }
        [StringLength(150, MinimumLength = 20, ErrorMessage = "Tiêu đề lịch trình phải có độ dài từ 20 đến 150 ký tự")]
        public string MoTa { get; set; }
        public int TheLoaiId { get; set; }
        public TheLoai TheLoai { get; set; }    
    }
}
