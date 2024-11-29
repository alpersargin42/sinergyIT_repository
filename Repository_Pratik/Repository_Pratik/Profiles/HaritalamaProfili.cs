using Repository_Pratik.Databases.Models;
using Repository_Pratik.DTO;
using AutoMapper;

/*
 
HaritalamaProfili, AutoMapper kullanarak Urun ve UrunDTO sınıfları arasındaki dönüşüm işlemlerini tanımlar.
AutoMapper, veritabanı modelleri ile veri transfer nesneleri (DTO) arasında otomatik eşleştirmeyi sağlar.
Urun ve UrunDTO nesneleri arasında dönüşüm (map) işlemlerini tanımladım.

 */

namespace Repository_Pratik.Profiles
{
    public class HaritalamaProfili : Profile
    {
        // tam uyuşum sağlanmalı -> consistency
        public HaritalamaProfili()
        {
            // bu komut, veritabanındaki Urun nesnesi ile API'ye gönderilecek olan UrunDTO nesnesi arasında veri transferini sağlar.
            CreateMap<Urun, UrunDTO>();
            // bu komut, API'den gelen UrunDTO verilerinin veritabanına yazılması için gereklidir.
            CreateMap<UrunDTO, Urun>();
        }
    }
}
