namespace Repository_Pratik.DTO
{
    // DATA TRANSFER OBJECT (ACID prensipleri gereğince urun modeli ile aynı olmalı= uyuşmalı(consistency))
    public class UrunDTO
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public decimal Fiyat { get; set; }
    }
}
