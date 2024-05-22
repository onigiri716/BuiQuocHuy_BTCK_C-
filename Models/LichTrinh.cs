namespace BuiQuocHuy_BTCK_C_.Models
{
    public class LichTrinh : UserActivity
    {
        public int Id { get; set; }

        public DateTime NgayLamViec { get; set; }
        public DateTime NgayKetThuc { get; set; }
        public string MoTa { get; set; }
        public int PhongBanId { get; set; }
        public PhongBan PhongBan { get; set; }
    }
}
