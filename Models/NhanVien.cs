using Newtonsoft.Json.Serialization;
using System.ComponentModel.DataAnnotations.Schema;

namespace BuiQuocHuy_BTCK_C_.Models
{
    public class NhanVien : UserActivity
    {
        public int Id { get; set; }
        public string MaNV { get; set; }
        public string Ho { get; set; }
        public string? TenDem { get; set; }
        public string Ten { get; set; }
    

        [PhoneNumberValidation]
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string DiaChi { get; set; }

  
        public DateTime NgaySinh { get; set; }


        public string ChucVu { get; set; }

        
    }
}
