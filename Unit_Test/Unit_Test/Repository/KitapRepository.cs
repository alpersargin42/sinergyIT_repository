using System.Collections.Generic;
using System.Linq;
using Unit_Test.Abstract;
using Unit_Test.Concrate;

namespace Unit_Test.Repository
{
    //repository
    public class KitapRepository:IKitapRepository
    {
        private readonly List<Kitap> _kitaplar = new();

        public Kitap Getir(int id) => _kitaplar.FirstOrDefault(k => k.Id == id);

        public List<Kitap> TumunuGetir() => _kitaplar;

        public void Ekle(Kitap kitap) => _kitaplar.Add(kitap);

        public void Guncelle(Kitap kitap)
        {
            var mevcutKitap = Getir(kitap.Id);
            if (mevcutKitap != null)
            {
                mevcutKitap.Ad = kitap.Ad;
                mevcutKitap.Yazar = kitap.Yazar;
                mevcutKitap.YayinYili = kitap.YayinYili;
            }
        }

        public void Sil(int id) => _kitaplar.RemoveAll(k => k.Id == id);
    }
}
