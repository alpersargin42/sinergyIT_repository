using System.Collections.Generic;
using Unit_Test.Concrate;


namespace Unit_Test.Abstract
{
    //kitap interfaces
    public interface IKitapRepository
    {
        Kitap Getir(int id);
        List<Kitap> TumunuGetir();
        void Ekle(Kitap kitap);
        void Guncelle(Kitap kitap);
        void Sil(int id);
    }
}
